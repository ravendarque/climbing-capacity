using System.Collections.ObjectModel;

using Microsoft.AspNetCore.Mvc.RazorPages;

using NuGet.Packaging;

using Ravendarque.ClimbingCapacity.Web.Clients;
using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IEnumerable<ICapacityDataClient> _capacityDataClients;

        public IEnumerable<ICapacity> CapacityData { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IEnumerable<ICapacityDataClient> capacityDataClients)
        {
            _logger = logger;
            _capacityDataClients = capacityDataClients;
            CapacityData = Enumerable.Empty<ICapacity>();
        }

        public async Task OnGet()
        {
            CapacityData = await GetCapacityData();
        }

        private async Task<IEnumerable<ICapacity>> GetCapacityData()
        {
            ICollection<ICapacity> aggregatedCapacityData = new Collection<ICapacity>();
            foreach (var client in _capacityDataClients)
            {
                //TODO: move this down so we don't need to handle null checks here
                IEnumerable<ICapacity>? capacityData = null;
                try
                {
                    capacityData = await client.Fetch();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Exception fetching capacity data from client: {client.GetType()}");
                }

                if (capacityData == null)
                {
                    _logger.LogError($"Received null result from capacity data client: {client.GetType()}");
                    continue;
                }

                aggregatedCapacityData.AddRange(capacityData);
            }

            return aggregatedCapacityData;
        }
    }
}