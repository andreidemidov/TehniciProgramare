using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp_project_freelance_platform_api.Repository.Interfaces;

namespace tp_project_freelance_platform_api.Repository
{
    public class DetailRepository : IDetail
    {
        private readonly IMapper _mapper;
        private FreeLancePlatformContext _context;
        public DetailRepository()
        {
                    
        }

        public string CreateFile(string fileName, byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}
