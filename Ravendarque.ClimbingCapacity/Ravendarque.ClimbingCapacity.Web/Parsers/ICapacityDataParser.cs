using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.Parsers;

public interface ICapacityDataParser<out T> where T : ICapacity
{
    IEnumerable<T> Parse(string content);
}