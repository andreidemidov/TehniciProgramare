using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp_project_freelance_platform_api.Entities;

namespace tp_project_freelance_platform_api.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Job> Jobs { get; }

        IGenericRepository<UserDetail> Employees { get; }

        IGenericRepository<Applicant> Applicants { get; }

        IGenericRepository<UserDetail> UserDetails { get; }
        void Commit();
    }
}
