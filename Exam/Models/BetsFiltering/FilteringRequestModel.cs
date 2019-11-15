using Newtonsoft.Json;

namespace Exam.Models.Filtering
{
    public class FilteringRequestModel
    {
        [JsonProperty(PropertyName = "inFilter")]
        public InFilterModel InFilter { get; set; }

        [JsonProperty(PropertyName = "oDataFilter")]
        public string ODataFilter { get; set; }

        [JsonProperty(PropertyName = "take")]
        public int Take { get; set; }
    }
}