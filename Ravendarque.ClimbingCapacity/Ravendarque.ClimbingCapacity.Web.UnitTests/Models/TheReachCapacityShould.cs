using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;

using NUnit.Framework;

using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.UnitTests.Models;

internal class TheReachCapacityShould
{
    [TestCase("AAA", "The Reach")]
    [TestCase("", "Unknown")]
    [TestCase(null, "Unknown")]
    public void MapLocationToLocationName(string testLocation, string expectedLocationName)
    {
        const int dummyMaxValue = 1;
        const int dummyCurrentValue = 1;

        var testLccCapacity = new TheReachCapacity() { Location = testLocation, Max = dummyMaxValue, Current = dummyCurrentValue };

        var actualLocationName = testLccCapacity.LocationName;

        actualLocationName.Should().Be(expectedLocationName);
    }
}