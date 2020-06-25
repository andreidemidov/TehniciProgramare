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
        private GenericRepository<UserDetail> _userDetail;
        private GenericRepository<Applicant> _applicant;
        private GenericRepository<UserDetail> _users;

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

        public IGenericRepository<UserDetail> Employees
        {
            get
            {
                return _userDetail ??
                (_userDetail = new GenericRepository<UserDetail>(_context));
            }
        }

        public IGenericRepository<Applicant> Applicants
        {
            get
            {
                return _applicant ??
                (_applicant = new GenericRepository<Applicant>(_context));
            }
        }

        public IGenericRepository<UserDetail> UserDetails
        {
            get
            {
                return _users ??
                (_users = new GenericRepository<UserDetail>(_context));
            }
        }


        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
