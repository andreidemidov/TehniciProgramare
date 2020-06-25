using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Helpers;
using IenApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;
using TP_PROJECT_FreeLancePlatform_Api.Interface;
using TP_PROJECT_FreeLancePlatform_Api.Model;
using TP_PROJECT_FreeLancePlatform_Api.ModelVm;

namespace TP_PROJECT_FreeLancePlatform_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseApiController
    {
        private readonly IConfiguration _config;
        private readonly IAuthService _authService;

        public LoginController(IConfiguration config, IAuthService authService)
        {
            _config = config;
            _authService = authService;         
        }

        [HttpPost]
        public object Login([FromBody]UserVm userVm)
        {
            IActionResult response = Unauthorized();
            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                UserModel login = new UserModel();
                login.EmailAddress = userVm.EmailAddress;
                login.Password = userVm.Password;

                var user = _authService.AuthenticateUser(login);
                if (user != null)
                {
                    var tokenResponse = _authService.GenerateJSONWebToken(user);
                    return response = Ok(new { token = tokenResponse, status = "success" });
                }
            }
            catch (AppException ex)
            {
                _logger.LogError($"{MethodInfoHelper.GetCurrentMethodName()} failed.", ex);
                throw;
            }
            finally
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} ended.");
            }


            return new { message = "Email address or password are not valid!!!" };
        }


        [HttpGet("GetUser")]
        [Authorize]
        public UserModel GetUser()
        {
            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                IList<Claim> claim = GetClaim();
                var user = new UserModel
                {
                    EmailAddress = claim[0].Value,
                    Role = claim[1].Value,
                    FirstName = claim[2].Value,
                    LastName = claim[3].Value,
                    Id = Convert.ToInt32(claim[4].Value)
                };

                return user;

            }
            catch (AppException ex)
            {
                _logger.LogError($"{MethodInfoHelper.GetCurrentMethodName()} failed.", ex);
                throw;
            }
            finally
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} ended.");
            }
        }

        private IList<Claim> GetClaim()
        {
            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IList<Claim> claim = identity.Claims.ToList();
                return claim;
            }
            catch (AppException ex)
            {
                _logger.LogError($"{MethodInfoHelper.GetCurrentMethodName()} failed.", ex);
                throw;
            }
            finally
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} ended.");
            }

        }
    }
}