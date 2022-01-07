using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.Services;

public interface ICapacityDataParser
{
    IEnumerable<Capacity> Parse(string content);
}