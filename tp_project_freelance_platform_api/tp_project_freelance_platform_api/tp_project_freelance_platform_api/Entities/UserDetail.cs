using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TP_PROJECT_FreeLancePlatform_Api.Model;

namespace tp_project_freelance_platform_api.Entities
{
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Position { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string County { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string PersonalDescription { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string SelectedFileName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string SelectedFile { get; set; }

        public int UserModelId { get; set; }
        public UserModel UserModel { get; set; }
    }
}
