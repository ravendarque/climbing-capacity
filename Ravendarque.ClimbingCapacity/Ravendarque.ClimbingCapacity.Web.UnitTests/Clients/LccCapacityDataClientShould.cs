using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Moq;
using Moq.Protected;

using NUnit.Framework;

using Ravendarque.ClimbingCapacity.Web.Clients;
using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.UnitTests.Clients;

public class LccCapacityDataClientShould : CapacityDataClientTestBase
{
    [Test]
    public async Task ReturnCapacityData()
    {
        var mockHttpMessageHandler = BuildMockHttpMessageHandler();
        var testHttpClient = new HttpClient(mockHttpMessageHandler.Object);
        var mockHttpClientFactory = BuildMockHttpClientFactory(testHttpClient);
        var mockParser = BuildMockParser<LccCapacity>();

        var testCapacityDataClient = new LccCapacityDataClient(mockHttpClientFactory.Object, mockParser.Object);

        await testCapacityDataClient.Fetch();

        mockHttpClientFactory.Verify(m => m.CreateClient(It.IsAny<string>()), Times.Once);
        mockHttpMessageHandler.Protected()
                              .Verify(
                                  SendAsyncMethodName,
                                  Times.Once(),
                                  ItExpr.IsAny<HttpRequestMessage>(),
                                  ItExpr.IsAny<CancellationToken>()
                              );
        mockParser.Verify(m => m.Parse(It.IsAny<string>()));
    }
}