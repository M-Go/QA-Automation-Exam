using Newtonsoft.Json;
using System.Collections.Generic;

namespace Exam.Models.Filtering
{
    public class InFilterModel
    {
        [JsonProperty(PropertyName = "segmentIds")]
        public IEnumerable<int> SegmentIds { get; set; }

        [JsonProperty(PropertyName = "playerIds")]
        public IEnumerable<string> PlayerIds { get; set; }

        [JsonProperty(PropertyName = "channels")]
        public IEnumerable<string> Channels { get; set; }
    }
}