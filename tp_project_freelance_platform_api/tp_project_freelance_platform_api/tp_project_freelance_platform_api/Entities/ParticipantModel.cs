using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TP_PROJECT_FreeLancePlatform_Api.Model;

namespace tp_project_freelance_platform_api.Entities
{
    public class ParticipantModel
    {
        [Key]
        public int Id { get; set; }
        public int UserModelID { get; set; }
        public UserModel UserModel { get; set; }
        public int JobID { get; set; }
        public Job Job { get; set; }
    }
}
