using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp_project_freelance_platform_api.ViewModels
{
    public class ApplicantsVm
    {
        [JsonProperty("userModelID")]
        public int UserModelID { get; set; }
        [JsonProperty("jobID")]
        public int JobID { get; set; }
    }
}
