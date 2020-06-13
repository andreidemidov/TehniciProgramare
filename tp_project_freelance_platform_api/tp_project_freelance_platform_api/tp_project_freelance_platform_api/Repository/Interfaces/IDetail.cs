using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp_project_freelance_platform_api.Repository.Interfaces
{
    public interface IDetail
    {
        public string CreateFile(string fileName, byte[] bytes);
    }
}
