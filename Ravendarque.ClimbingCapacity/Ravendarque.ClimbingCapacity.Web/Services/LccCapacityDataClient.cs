using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.Services;

public class LccCapacityDataClient : CapacityDataClient
{
    private const string CapacityUri =
        "https://portal.rockgympro.com/portal/public/a67951f8b19504c3fd14ef92ef27454d/occupancy?&iframeid=occupancyCounter&fId=2010";

    public LccCapacityDataClient(IHttpClientFactory httpClientFactory) : base(
        httpClientFactory,
        new Uri(CapacityUri),
        new RockGymProHtmlParser<LccCapacity>()
    ) { }

    public LccCapacityDataClient(IHttpClientFactory httpClientFactory, ICapacityDataParser<ICapacity> parser) : base(
        httpClientFactory,
        new Uri(CapacityUri),
        parser
    )
    { }
}