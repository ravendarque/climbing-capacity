using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.Clients;

public interface ICapacityDataClient
{
    Task<IEnumerable<ICapacity>> Fetch();
}