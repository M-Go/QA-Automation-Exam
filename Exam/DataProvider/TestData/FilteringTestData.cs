using NUnit.Framework;
using System.Collections.Generic;

namespace Exam.DataProvider.TestData
{
    public static class FilteringTestData
    {
        public static IEnumerable<TestCaseData> GetFilteringData()
        {
            yield return new TestCaseData(new FilterProvider());
        }
    }
}