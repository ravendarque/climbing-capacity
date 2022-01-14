using System.Collections.ObjectModel;

using FluentAssertions;

using NUnit.Framework;

using Ravendarque.ClimbingCapacity.Web.Models;
using Ravendarque.ClimbingCapacity.Web.Parsers;

namespace Ravendarque.ClimbingCapacity.Web.UnitTests.Parsers
{
    internal class RockGymProHtmlParserForTheReachShould : RockGymProHtmlParserTestBase
    {
        protected override string TestDataFileName => "TheReachTestHttpResponseMessageContent.html";

        [Test]
        public override void ParseCapacityDataFromHtml()
        {
            var expectedCapacity = new Collection<ICapacity>
            {
                new TheReachCapacity { Location = "AAA", Max = 325, Current = 25 }
            };

            var testParser = new RockGymProHtmlParser<TheReachCapacity>();
            var testContent = GetTestData(TestDataFileName);

            var actualCapacityData = testParser.Parse(testContent);
            actualCapacityData.Should()
                              .BeEquivalentTo(expectedCapacity);
        }
    }
}