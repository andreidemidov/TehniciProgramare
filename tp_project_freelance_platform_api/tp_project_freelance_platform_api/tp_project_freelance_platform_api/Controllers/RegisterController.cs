﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Helpers;
using IenApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;
using TP_PROJECT_FreeLancePlatform_Api.Interface;
using TP_PROJECT_FreeLancePlatform_Api.Model;
using TP_PROJECT_FreeLancePlatform_Api.ModelVm;

namespace TP_PROJECT_FreeLancePlatform_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegisterController : BaseApiController
    {
        private readonly IRegister _registerService;
        private readonly IMapper _mapper;

        public RegisterController(IRegister registerService, IMapper mapper)
        {
         
            _registerService = registerService;
            _mapper = mapper;
        }

        [HttpPost]
        public object Register([FromBody]UserVm userVm)
        {
            try
            {
                _logger.LogInfo($"{MethodInfoHelper.GetCurrentMethodName()} started.");
                var userConfirmation = _registerService.CreateUser(userVm);

                if (!string.IsNullOrEmpty(userConfirmation.EmailAddress))
                {
                    return Ok(new { message = "User was succesfully recorded!" });
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

            return new { message = "Something went wrong please try again" };
        }
    }
}
