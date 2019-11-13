using Newtonsoft.Json;
using System.Collections.Generic;

namespace Exam.Models.Filtering
{
    public class InFilterModel
    {
        //public IEnumerable<string> Sports { get; set; }
        //public IEnumerable<string> CategoryIds { get; set; }
        //public IEnumerable<string> TournamentIds { get; set; }
        //public IEnumerable<string> BetTypes { get; set; }

        [JsonProperty(PropertyName = "segmentIds")]
        public IEnumerable<int> SegmentIds { get; set; }

        //public IEnumerable<string> Currencies { get; set; }

        [JsonProperty(PropertyName = "playerIds")]
        public IEnumerable<string> PlayerIds { get; set; }

        //public IEnumerable<string> ResultIds { get; set; }
        //public IEnumerable<string> AfsIds { get; set; }
        //public IEnumerable<string> TraderIds { get; set; }

        [JsonProperty(PropertyName = "channels")]
        public IEnumerable<string> Channels { get; set; }
    }
}