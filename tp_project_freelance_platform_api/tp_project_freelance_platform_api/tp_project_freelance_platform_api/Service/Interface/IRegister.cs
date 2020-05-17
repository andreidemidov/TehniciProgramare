using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_PROJECT_FreeLancePlatform_Api.Model;
using TP_PROJECT_FreeLancePlatform_Api.ModelVm;

namespace TP_PROJECT_FreeLancePlatform_Api.Interface
{
    public interface IRegister
    {
        UserVm CreateUser(UserVm user);
        string HashPassword(string password);
    }
}
