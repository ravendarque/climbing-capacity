using System.Collections.ObjectModel;

using FluentAssertions;

using NUnit.Framework;

using Ravendarque.ClimbingCapacity.Web.Models;
using Ravendarque.ClimbingCapacity.Web.Parsers;

namespace Ravendarque.ClimbingCapacity.Web.UnitTests.Parsers;

internal class RockGymProHtmlParserForClimbingHangarShould : RockGymProHtmlParserTestBase
{
    protected override string TestDataFileName => "ClimbingHangarTestHttpResponseMessageContent.html";

    [Test]
    public override void ParseCapacityDataFromHtml()
    {
        var expectedCapacity = new Collection<ICapacity>
        {
            new ClimbingHangarCapacity { Location = "AAA", Max = 60, Current = 6 }
        };

        var testParser = new RockGymProHtmlParser<ClimbingHangarCapacity>();
        var testContent = GetTestData(TestDataFileName);

        var actualCapacityData = testParser.Parse(testContent);
        actualCapacityData.Should()
                          .BeEquivalentTo(expectedCapacity)
                          .And.Satisfy(
                              c => c.Location == "AAA" && c.LocationName == "Climbing Hangar"
                          );
    }
}