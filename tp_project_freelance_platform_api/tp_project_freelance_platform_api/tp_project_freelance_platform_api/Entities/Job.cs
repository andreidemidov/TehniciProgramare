using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TP_PROJECT_FreeLancePlatform_Api.Model;

namespace tp_project_freelance_platform_api.Entities
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        [Column(TypeName = "int")]
        public int Salary { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Study { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Level { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Occupation { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Industry { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Department { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ForeignLanguage { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedDate { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CompanyName { get; set; }
        public int EmployeerId { get; set; }
        public UserModel User { get; set; }

        public ICollection<ParticipantModel> Participants { get; set; }
    }
}
