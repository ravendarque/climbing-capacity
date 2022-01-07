using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.Services
{
    public interface ICapacityDataClient
    {
        Task<IEnumerable<Capacity>> Fetch();
    }
}
