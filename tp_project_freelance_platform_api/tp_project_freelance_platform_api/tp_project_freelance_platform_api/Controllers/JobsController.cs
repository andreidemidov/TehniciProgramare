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
using tp_project_freelance_platform_api.Entities;
using tp_project_freelance_platform_api.Repository;
using tp_project_freelance_platform_api.Repository.Interfaces;
using tp_project_freelance_platform_api.ViewModels;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;
using TP_PROJECT_FreeLancePlatform_Api.Interface;

namespace tp_project_freelance_platform_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobRepository;
        private readonly IAuthService _authService;

        public JobsController(IUnitOfWork unitOfWork, IMapper mapper, IJobRepository jobRepository, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jobRepository = jobRepository;
            _authService = authService;
        }
        // GET: api/Jobs
        [HttpGet]
        [Authorize]
        public object Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = _authService.GetClaim(identity);

            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                var user = _authService.AuthorizeUser(Convert.ToInt32(userClaim[4].Value));
                if(user != null)
                {
                    var jobs = _unitOfWork.Jobs.GetAll();
                    return new { message = "Success" , jobs = _unitOfWork.Jobs.GetAll() };
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


        // GET: api/Jobs/5
        [HttpGet("{id}", Name = "Get")]
        [Authorize]
        public object Get(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = _authService.GetClaim(identity);
            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                if (Convert.ToInt32(userClaim[4].Value) == id)
                {
                    return new { message = "Success", jobs = _jobRepository.GetAll(id) };
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

        // POST: api/Jobs
        [HttpPost]
        [Authorize]
        public object Post([FromBody] JobVm jobVm)
        {
            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                var job = _mapper.Map<Job>(jobVm);
                if (job != null)
                {
                    _unitOfWork.Jobs.Insert(job);
                    _unitOfWork.Jobs.Save();
                }

                return Ok(new { message = "Success" });
            }
            catch (AppException ex)
            {
                return new { message = "Something went wrong please try again" };
            }
            
        }

        [HttpPost("Update")]
        [Authorize]
        public object Update([FromBody] JobVm jobVm)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = _authService.GetClaim(identity);
            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                var user = _authService.AuthorizeUser(Convert.ToInt32(userClaim[4].Value));
                if(user != null)
                {
                    var job = _mapper.Map<Job>(jobVm);
                    _unitOfWork.Jobs.Update(job);
                    _unitOfWork.Jobs.Save();
                    return new { message = "Success" };
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public object Delete(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = _authService.GetClaim(identity);
            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                var user = _authService.AuthorizeUser(Convert.ToInt32(userClaim[4].Value));
                if (user != null)
                {
                    _unitOfWork.Jobs.Delete(id);
                    _unitOfWork.Jobs.Save();
                    return new { message = "Success"};
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
