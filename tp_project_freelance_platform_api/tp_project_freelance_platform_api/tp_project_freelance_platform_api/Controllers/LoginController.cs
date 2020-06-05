using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TP_PROJECT_FreeLancePlatform_Api.Interface;
using TP_PROJECT_FreeLancePlatform_Api.Model;
using TP_PROJECT_FreeLancePlatform_Api.ModelVm;

namespace TP_PROJECT_FreeLancePlatform_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
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
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }


            return new { message = "Email address or password are not valid!!!" };
        }


        [HttpGet("GetUser")]
        [Authorize]
        public UserModel GetUser()
        {
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

        private IList<Claim> GetClaim()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            return claim;
        }
    }
}