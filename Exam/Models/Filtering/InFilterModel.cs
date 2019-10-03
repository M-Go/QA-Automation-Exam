using System.Collections.Generic;

namespace Exam.Models.Filtering
{
    //TODO
    public class InFilterModel
    {
        public List<string> Sports { get; set; }
        public List<string> CategoryIds { get; set; }
        public List<string> TournamentIds { get; set; }
        public List<string> BetTypes { get; set; }
        public List<string> SegmentIds { get; set; }
        public List<string> Currencies { get; set; }
        public List<string> PlayerIds { get; set; }
        public List<string> ResultIds { get; set; }
        public List<string> AfsIds { get; set; }
        public List<string> TraderIds { get; set; }
        public List<string> Channels { get; set; }
    }
}