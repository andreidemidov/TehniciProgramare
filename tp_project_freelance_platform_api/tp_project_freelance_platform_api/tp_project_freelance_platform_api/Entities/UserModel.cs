using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using tp_project_freelance_platform_api.Entities;

namespace TP_PROJECT_FreeLancePlatform_Api.Model
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string EmailAddress { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(9)")] 
        public string Role { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public UserDetail UserDetail { get; set; }

        public ICollection<Applicant> Participants { get; set; }
    }
}
