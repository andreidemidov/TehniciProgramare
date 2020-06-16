using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace tp_project_freelance_platform_api.Repository.Interfaces
{
    public interface IDetail
    {
        string CreateFile(string fileName, byte[] bytes);
    }
}
