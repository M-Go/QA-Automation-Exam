using Newtonsoft.Json;

namespace Exam.Models
{
    public class LanguageRequestModel
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}