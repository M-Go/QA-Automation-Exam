using Exam.Session;
using NUnit.Framework;

namespace Exam.Tests
{
    public class _BaseUITest
    {
        [SetUp]
        public void InitTest()
        {
            var browser = new Browser();
            var driver = browser.Build();
            DriverManager.SetDriver(driver);
        }

        [TearDown]
        public void GeneralAfterTest()
        {
            var driver = DriverManager.GetDriver();
            if (driver != null)
            {
                driver.Close();
            }
        }
    }
}