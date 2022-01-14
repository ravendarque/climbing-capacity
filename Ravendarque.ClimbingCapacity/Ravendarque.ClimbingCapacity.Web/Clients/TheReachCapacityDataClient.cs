using Ravendarque.ClimbingCapacity.Web.Models;
using Ravendarque.ClimbingCapacity.Web.Parsers;

namespace Ravendarque.ClimbingCapacity.Web.Clients
{
    public class TheReachCapacityDataClient : CapacityDataClient
    {
        private const string CapacityUri =
            "https://portal.rockgympro.com/portal/public/be94788ef672908b57b32977c18452dc/occupancy?&iframeid=occupancyCounter&fId=";

        public TheReachCapacityDataClient(IHttpClientFactory httpClientFactory) : base(
            httpClientFactory,
            new Uri(CapacityUri),
            new RockGymProHtmlParser<TheReachCapacity>()
        ) { }

        public TheReachCapacityDataClient(
            IHttpClientFactory httpClientFactory,
            ICapacityDataParser<ICapacity> parser) : base(
            httpClientFactory,
            new Uri(CapacityUri),
            parser
        ) { }
    }
}