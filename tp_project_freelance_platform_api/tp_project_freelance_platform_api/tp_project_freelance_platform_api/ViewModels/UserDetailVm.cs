using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp_project_freelance_platform_api.ViewModels
{
    public class UserDetailVm
    {
        [JsonProperty("userModelId")]
        public int UserModelId { get; set; }
        [JsonProperty("position")]
        public string Position { get; set; }
        [JsonProperty("county")]
        public string County { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }     
        [JsonProperty("personalDescription")]
        public string PersonalDescription { get; set; }
        [JsonProperty("selectedFileName")]
        public string SelectedFileName { get; set; }
        [JsonProperty("selectedFile")]
        public string SelectedFile { get; set; }
    }
}
