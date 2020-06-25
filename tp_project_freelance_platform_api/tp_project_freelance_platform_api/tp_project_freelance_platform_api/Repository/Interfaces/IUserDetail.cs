using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp_project_freelance_platform_api.Entities;
using tp_project_freelance_platform_api.ViewModels;

namespace tp_project_freelance_platform_api.Repository.Interfaces
{
    public interface IUserDetail
    {
        UserDetailVm GetById(int id);
    }
}
