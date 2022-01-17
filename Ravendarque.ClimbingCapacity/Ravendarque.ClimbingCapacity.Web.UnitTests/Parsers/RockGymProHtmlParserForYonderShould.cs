using System.Collections.ObjectModel;

using FluentAssertions;

using NUnit.Framework;

using Ravendarque.ClimbingCapacity.Web.Models;
using Ravendarque.ClimbingCapacity.Web.Parsers;

namespace Ravendarque.ClimbingCapacity.Web.UnitTests.Parsers;

internal class RockGymProHtmlParserForYonderShould : RockGymProHtmlParserTestBase
{
    protected override string TestDataFileName => "YonderTestHttpResponseMessageContent.html";

    [Test]
    public override void ParseCapacityDataFromHtml()
    {
        var expectedCapacity = new Collection<ICapacity>
        {
            new YonderCapacity { Location = "AAA", Max = 120, Current = 10 }
        };

        var testParser = new RockGymProHtmlParser<YonderCapacity>();
        var testContent = GetTestData(TestDataFileName);

        var actualCapacityData = testParser.Parse(testContent);
        actualCapacityData.Should()
                          .BeEquivalentTo(expectedCapacity)
                          .And.Satisfy(
                              c => c.Location == "AAA" && c.LocationName == "Yonder"
                          );
    }
}