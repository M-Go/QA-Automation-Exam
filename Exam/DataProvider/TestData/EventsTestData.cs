using NUnit.Framework;
using System.Collections.Generic;

namespace Exam.DataProvider.TestData
{
    public static class EventsTestData
    {
        public static IEnumerable<TestCaseData> GetEventsData()
        {
            yield return new TestCaseData(new EventProvider());
        }
    }
}