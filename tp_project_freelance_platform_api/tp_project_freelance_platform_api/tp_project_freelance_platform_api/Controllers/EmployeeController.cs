using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
    public class EmployeeController : BaseApiController
    {
        private readonly IDetail _employeeDetail;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        public EmployeeController(IDetail employeeDetail, IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
        {
            _employeeDetail = employeeDetail;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authService = authService;
        }

        // POST: api/Employee
        [HttpPost]
        public object Post([FromBody] UserDetailVm userDetailVm)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = _authService.GetClaim(identity);

            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                var user = _authService.AuthorizeUser(Convert.ToInt32(userClaim[4].Value));
                if (user != null)
                {
                    var file = userDetailVm.SelectedFile.Replace("data:application/pdf;base64,", String.Empty);
                    var data = Convert.FromBase64String(file);
                    var stream = new MemoryStream(data);
                    userDetailVm.SelectedFile = _employeeDetail.CreateFile(userDetailVm.SelectedFileName,data);

                    var employeeDetail = _mapper.Map<UserDetail>(userDetailVm);
                    if (employeeDetail != null)
                    {
                        _unitOfWork.Employees.Insert(employeeDetail);
                        _unitOfWork.Employees.Save();
                    }
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
