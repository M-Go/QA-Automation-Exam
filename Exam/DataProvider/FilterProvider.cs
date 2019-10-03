using System;

namespace Exam.DataProvider
{
    //TODO
    public class FilterProvider
    {
        public string PlayerId => "929297369";

        public string Date => "27.08.2019 00:00:00";

        public DateTime AcceptTimeFiltering = new DateTime(2019, 08, 26, 21, 00, 00);

        public string FilteringBodyInSettlementMonitor => "{\"inFilter\":{\"segmentIds\":[0],\"channels\":[\"MOBILE_WEB\"]},\"oDataFilter\":\"(eventId eq '520012') and (acceptTime ge 2019-08-26T21:00:00.000Z) and (acceptTime lt 2019-09-13T11:00:53.672Z) and (betBaseAmount ge 1)\",\"take\":50}";

        public string FilteringBodyInBetsMonitor => "{\"inFilter\":{\"playerIds\":[\"929297369\"]},\"oDataFilter\":\"(acceptTime ge 2019-08-26T21:00:00.000Z)\",\"take\":50}";

    }
}