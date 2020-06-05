using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp_project_freelance_platform_api.Entities;
using TP_PROJECT_FreeLancePlatform_Api.Model;

namespace TP_PROJECT_FreeLancePlatform_Api.Helpers
{
    public class FreeLancePlatformContext : DbContext
    {
        public FreeLancePlatformContext(DbContextOptions<FreeLancePlatformContext> options) : base(options) { }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<Job> Job { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasOne<UserModel>(e => e.User).WithMany(e => e.Jobs).HasForeignKey(e => e.EmployeerId);
        }

    }
}
