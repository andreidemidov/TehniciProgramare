using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp_project_freelance_platform_api.Entities;
using tp_project_freelance_platform_api.Repository.Interfaces;
using tp_project_freelance_platform_api.ViewModels;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;

namespace tp_project_freelance_platform_api.Repository
{
    public class UserDetailRepository : IUserDetail
    {

        private readonly IMapper _mapper;
        private FreeLancePlatformContext _context;
        public UserDetailRepository(FreeLancePlatformContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UserDetailVm GetById(int id)
        {
            var user = _context.UserDetail.SingleOrDefault(el => el.UserModelId == id);
            var userVm = _mapper.Map<UserDetailVm>(user);
            return userVm;
        }
    }
}
