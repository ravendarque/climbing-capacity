using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;

using NUnit.Framework;

using Ravendarque.ClimbingCapacity.Web.Models;
using Ravendarque.ClimbingCapacity.Web.Services;

namespace Ravendarque.ClimbingCapacity.Web.UnitTests.Services
{
    internal class RockGymProHtmlParserShould
    {
        [Test]
        public void ParseCapacityDataFromHtml()
        {
            const int dummyMaxValue = 100;
            const int dummyCurrentValue = 10;

            var expectedCapacity = new Capacity("DummyOrg", "DummyLocation", dummyMaxValue, dummyCurrentValue);

            var testParser = new RockGymProHtmlParser();
            var testContent = GetTestData();

            var actualCapacityData = testParser.Parse(testContent);
            actualCapacityData.Should()
                              .HaveCount(1)
                              .And.ContainEquivalentOf(expectedCapacity);
        }

        private static string GetTestData()
        {
            var testRunPath = TestContext.CurrentContext.TestDirectory;
            var testDataFile = Path.Combine(testRunPath, "../../../TestData", "FakeHttpResponseMessageContent.html");

            return File.ReadAllText(testDataFile);
        }
    }
}
