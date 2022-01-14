using System.Collections.ObjectModel;
using System.IO;

using FluentAssertions;

using NUnit.Framework;

using Ravendarque.ClimbingCapacity.Web.Models;
using Ravendarque.ClimbingCapacity.Web.Parsers;

namespace Ravendarque.ClimbingCapacity.Web.UnitTests.Parsers;

internal class RockGymProHtmlParserForLccShould : RockGymProHtmlParserTestBase
{
    protected override string TestDataFileName => "LccTestHttpResponseMessageContent.html";

    [Test]
    public override void ParseCapacityDataFromHtml()
    {
        var expectedCapacity = new Collection<ICapacity>
        {
            new LccCapacity { Location = "VWS", Max = 130, Current = 13},
            new LccCapacity { Location = "VES", Max = 120, Current = 4},
            new LccCapacity { Location = "HAR", Max = 300, Current = 0},
            new LccCapacity { Location = "CRO", Max = 120, Current = 10},
            new LccCapacity { Location = "RAV", Max = 130, Current = 5},
            new LccCapacity { Location = "CNW", Max = 80,  Current = 0},
            new LccCapacity { Location = "BWG", Max = 130, Current = 4}
        };

        var testParser = new RockGymProHtmlParser<LccCapacity>();
        var testContent = GetTestData(TestDataFileName);

        var actualCapacityData = testParser.Parse(testContent);
        actualCapacityData.Should()
                          .BeEquivalentTo(expectedCapacity);
    }
}