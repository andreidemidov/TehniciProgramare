using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helpers;
using IenApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tp_project_freelance_platform_api.Repository.Interfaces;
using tp_project_freelance_platform_api.ViewModels;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;
using TP_PROJECT_FreeLancePlatform_Api.Interface;

namespace tp_project_freelance_platform_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IUserDetail _userDetail;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public UsersController(IUserDetail userDetail, IMapper mapper, IAuthService authService)
        {
            _userDetail = userDetail;
            _mapper = mapper;
            _authService = authService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public object Get(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = _authService.GetClaim(identity);
            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                if (Convert.ToInt32(userClaim[4].Value) != 0)
                {
        
                    return new { message = "Success", user = _userDetail.GetById(id) };
                }
                else
                {
                    return new { message = "Unauthorize" };
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

        }

    }
}