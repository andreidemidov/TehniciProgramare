using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp_project_freelance_platform_api.Entities;
using tp_project_freelance_platform_api.Repository.Interfaces;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;

namespace tp_project_freelance_platform_api.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private FreeLancePlatformContext _context;
        private GenericRepository<Job> _jobs;

        public UnitOfWork(FreeLancePlatformContext context)
        {
            _context = context;
        }

        public IGenericRepository<Job> Jobs
        {
            get
            {
                return _jobs ??
                (_jobs = new GenericRepository<Job>(_context));
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
