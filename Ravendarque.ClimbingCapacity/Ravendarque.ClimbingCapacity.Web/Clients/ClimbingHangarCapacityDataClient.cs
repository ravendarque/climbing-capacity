using Ravendarque.ClimbingCapacity.Web.Models;
using Ravendarque.ClimbingCapacity.Web.Parsers;

namespace Ravendarque.ClimbingCapacity.Web.Clients;

public class ClimbingHangarCapacityDataClient : CapacityDataClient
{
    private const string CapacityUri =
        "https://portal.rockgympro.com/portal/public/8c5066575c2799fbf67b829828001c50/occupancy?&iframeid=occupancyCounter&fId=";

    public ClimbingHangarCapacityDataClient(IHttpClientFactory httpClientFactory) : base(
        httpClientFactory,
        new Uri(CapacityUri),
        new RockGymProHtmlParser<ClimbingHangarCapacity>()
    ) { }

    public ClimbingHangarCapacityDataClient(
        IHttpClientFactory httpClientFactory,
        ICapacityDataParser<ICapacity> parser) : base(
        httpClientFactory,
        new Uri(CapacityUri),
        parser
    ) { }
}