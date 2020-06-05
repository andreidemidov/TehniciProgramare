using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp_project_freelance_platform_api.ViewModels
{
    public class JobVm
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("employeerId")]
        public int EmployeerId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("salary")]
        public string Salary { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("study")]
        public string Study { get; set; }
        [JsonProperty("level")]
        public string Level { get; set; }
        [JsonProperty("occupation")]
        public string Occupation { get; set; }
        [JsonProperty("industry")]
        public string Industry { get; set; }
        [JsonProperty("department")]
        public string Department { get; set; }
        [JsonProperty("foreignLanguage")]
        public string ForeignLanguage { get; set; }
        [JsonProperty("addedDate")]
        public string addedDate { get; set; }
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

    }
}
