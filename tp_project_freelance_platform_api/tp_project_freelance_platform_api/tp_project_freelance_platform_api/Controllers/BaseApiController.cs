using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IenApi.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected ILogger _logger;

        protected BaseApiController()
        {
            _logger = new NLogLogger(GetType());
        }
    }
}