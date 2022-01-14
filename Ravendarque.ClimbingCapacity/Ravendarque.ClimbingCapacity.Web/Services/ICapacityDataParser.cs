using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.Services;

public interface ICapacityDataParser<out T> where T : ICapacity
{
    IEnumerable<T> Parse(string content);
}