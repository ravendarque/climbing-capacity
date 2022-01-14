using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.Services;

public abstract class CapacityDataClient : ICapacityDataClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Uri _capacityUri;
    private readonly ICapacityDataParser<ICapacity> _parser;

    protected CapacityDataClient(IHttpClientFactory httpClientFactory, Uri capacityUri, ICapacityDataParser<ICapacity> parser)
    {
        _httpClientFactory = httpClientFactory;
        _capacityUri = capacityUri;
        _parser = parser;
    }

    public virtual async Task<IEnumerable<ICapacity>> Fetch()
    {
        var httpClient = _httpClientFactory.CreateClient();

        var capacityRequest = new HttpRequestMessage(HttpMethod.Get, _capacityUri);
        var capacityResponse = await httpClient.SendAsync(capacityRequest);
        var htmlContent = await capacityResponse.Content.ReadAsStringAsync();

        return _parser.Parse(htmlContent);
    }
}