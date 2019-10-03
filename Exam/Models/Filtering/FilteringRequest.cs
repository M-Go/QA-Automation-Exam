namespace Exam.Models.Filtering
{
    public class FilteringRequest
    {
        public InFilterModel InFilter { get; set; }
        public string ODataFilter { get; set; }
        public int Take { get; set; }
    }
}