using Ravendarque.ClimbingCapacity.Web.Models;
using Ravendarque.ClimbingCapacity.Web.Parsers;

namespace Ravendarque.ClimbingCapacity.Web.Clients;

public class YonderCapacityDataClient : CapacityDataClient
{
    private const string CapacityUri =
        "https://portal.rockgympro.com/portal/public/51b34d29708b17d6270dbfee783f7375/occupancy?&iframeid=occupancyCounter&fId=";

    public YonderCapacityDataClient(IHttpClientFactory httpClientFactory) : base(
        httpClientFactory,
        new Uri(CapacityUri),
        new RockGymProHtmlParser<YonderCapacity>()
    ) { }

    public YonderCapacityDataClient(IHttpClientFactory httpClientFactory, ICapacityDataParser<ICapacity> parser) : base(
        httpClientFactory,
        new Uri(CapacityUri),
        parser
    ) { }
}