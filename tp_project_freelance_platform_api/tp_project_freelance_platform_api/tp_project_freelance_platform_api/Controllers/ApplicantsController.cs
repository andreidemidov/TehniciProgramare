using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helpers;
using IenApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tp_project_freelance_platform_api.Entities;
using tp_project_freelance_platform_api.Repository.Interfaces;
using tp_project_freelance_platform_api.ViewModels;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;
using TP_PROJECT_FreeLancePlatform_Api.Interface;

namespace tp_project_freelance_platform_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public ApplicantsController(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authService = authService;
        }

        [HttpPost]
        public object Post([FromBody] ApplicantsVm applicantVm)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = _authService.GetClaim(identity);

            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                var user = _authService.AuthorizeUser(Convert.ToInt32(userClaim[4].Value));
                if (user != null)
                {
                    var applicant = _mapper.Map<Applicant>(applicantVm);
                    _unitOfWork.Applicants.Insert(applicant);
                    _unitOfWork.Applicants.Save();

                    return Ok(new { message = "Success" });
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