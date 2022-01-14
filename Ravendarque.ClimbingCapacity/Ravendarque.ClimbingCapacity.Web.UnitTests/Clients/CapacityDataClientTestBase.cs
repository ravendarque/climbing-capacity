using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Moq;
using Moq.Protected;

using Ravendarque.ClimbingCapacity.Web.Models;
using Ravendarque.ClimbingCapacity.Web.Parsers;

namespace Ravendarque.ClimbingCapacity.Web.UnitTests.Clients
{
    public class CapacityDataClientTestBase
    {
        protected const string SendAsyncMethodName = "SendAsync";

        protected static Mock<IHttpClientFactory> BuildMockHttpClientFactory(HttpClient mockHttpClient)
        {
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>()))
                                 .Returns(mockHttpClient);

            return mockHttpClientFactory;
        }

        protected static Mock<HttpMessageHandler> BuildMockHttpMessageHandler()
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

        protected static Mock<ICapacityDataParser<T>> BuildMockParser<T>()
            where T : ICapacity
        {
            var dummyCapacity = Enumerable.Empty<T>();
            var mockParser = new Mock<ICapacityDataParser<T>>();
            mockParser.Setup(x => x.Parse(It.IsAny<string>()))
                      .Returns(dummyCapacity);

            return mockParser;
        }
    }
}