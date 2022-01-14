using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;

using Moq;
using Moq.Protected;

using NUnit.Framework;

using Ravendarque.ClimbingCapacity.Web.Models;
using Ravendarque.ClimbingCapacity.Web.Services;

namespace Ravendarque.ClimbingCapacity.Web.UnitTests.Services
{
    public class LccCapacityDataClientShould
    {
        private const string SendAsyncMethodName = "SendAsync";

        [Test]
        public async Task ReturnCapacityData()
        {
            var mockHttpMessageHandler = BuildMockHttpMessageHandler();
            var testHttpClient = new HttpClient(mockHttpMessageHandler.Object);
            var mockHttpClientFactory = BuildMockHttpClientFactory(testHttpClient);
            var mockParser = BuildMockParser();

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

        private static Mock<HttpMessageHandler> BuildMockHttpMessageHandler()
        {
            var dummyHttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                                  .Setup<Task<HttpResponseMessage>>(
                                      SendAsyncMethodName,
                                      ItExpr.IsAny<HttpRequestMessage>(),
                                      ItExpr.IsAny<CancellationToken>()
                                  )
                                  .ReturnsAsync(dummyHttpResponseMessage);

            return mockHttpMessageHandler;
        }

        private static Mock<IHttpClientFactory> BuildMockHttpClientFactory(HttpClient mockHttpClient)
        {
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>()))
                                 .Returns(mockHttpClient);

            return mockHttpClientFactory;
        }

        private static Mock<ICapacityDataParser<ICapacity>> BuildMockParser()
        {
            var dummyCapacity = Enumerable.Empty<LccCapacity>();
            var mockParser = new Mock<ICapacityDataParser<ICapacity>>();
            mockParser.Setup(x => x.Parse(It.IsAny<string>()))
                      .Returns(dummyCapacity);

            return mockParser;
        }
    }
}