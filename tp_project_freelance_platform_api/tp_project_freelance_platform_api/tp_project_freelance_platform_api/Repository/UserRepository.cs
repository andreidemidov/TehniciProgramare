using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;
using TP_PROJECT_FreeLancePlatform_Api.Model;

namespace tp_project_freelance_platform_api.Repository
{
    public class UserRepository: GenericRepository<UserModel>
    {
        private FreeLancePlatformContext _context;
        public UserRepository(FreeLancePlatformContext context): base(context)
        {
            _context = context;
        }


        public void CreateUser(UserModel entity)
        {
            if(entity != null)
            {
                base.Insert(entity);
                base.Save();
            }
        }
    }
}
