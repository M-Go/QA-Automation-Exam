using Newtonsoft.Json;
using System.Collections.Generic;

namespace Exam.Models
{
    public class LoginRequestModel
    {
        [JsonProperty(PropertyName = "includeAttributes")]
        public IEnumerable<string> IncludeAttributes { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}