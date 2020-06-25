using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp_project_freelance_platform_api.Entities;
using tp_project_freelance_platform_api.Repository.Interfaces;
using tp_project_freelance_platform_api.ViewModels;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;
using TP_PROJECT_FreeLancePlatform_Api.Model;

namespace tp_project_freelance_platform_api.Repository
{
    
    public class JobRepository: IJobRepository
    {
        private readonly IMapper _mapper;
        private FreeLancePlatformContext _context;
        public JobRepository(FreeLancePlatformContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<JobVm> GetAll(int id)
        {
            var jobList = _context.Job.ToList();
            var jobVm = new JobVm();
            var jobVmlist = new List<JobVm>();

            foreach (var item in jobList)
            {
                if (item.EmployeerId == id)
                {
                    var userApplicantIds = _context.Applicant.Where(el => el.JobID == item.Id).ToList();
                    List<UserModel> userApplicants = new List<UserModel>();
                    foreach (var i in userApplicantIds)
                    {
                        userApplicants = _context.UserModels.Where(el => el.Id == i.UserModelID).ToList();
                    }
                    item.Users = userApplicants;
                    jobVm = _mapper.Map<JobVm>(item);
                    jobVmlist.Add(jobVm);
                }
                
            }

            return jobVmlist;
        }

        public void UpdateJob(int id, string value)
        {
            var user = _context.UserModels.SingleOrDefault(x => x.Id == id);
            if(user != null)
            {
                
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
