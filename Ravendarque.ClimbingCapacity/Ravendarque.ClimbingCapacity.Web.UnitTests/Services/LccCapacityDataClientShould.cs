using System.IO;
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
            const int dummyMaxValue = 100;
            const int dummyCurrentValue = 10;
            var expectedCapacity = new Capacity("DummyOrg", "DummyLocation", dummyMaxValue, dummyCurrentValue);

            var fakeHttpResponseMessage = BuildFakeHttpResponseMessage();
            var mockHttpMessageHandler = BuildMockHttpMessageHandler(fakeHttpResponseMessage);
            var testHttpClient = new HttpClient(mockHttpMessageHandler.Object);
            var mockHttpClientFactory = BuildMockHttpClientFactory(testHttpClient);
            var mockParser = BuildMockParser(expectedCapacity);

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

        private static HttpResponseMessage BuildFakeHttpResponseMessage()
        {
            var fakeHttpResponseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(GetTestData())
            };
            return fakeHttpResponseMessage;
        }

        private static Mock<HttpMessageHandler> BuildMockHttpMessageHandler(HttpResponseMessage responseMessage)
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                                  .Setup<Task<HttpResponseMessage>>(
                                      SendAsyncMethodName,
                                      ItExpr.IsAny<HttpRequestMessage>(),
                                      ItExpr.IsAny<CancellationToken>()
                                  )
                                  .ReturnsAsync(responseMessage);

            return mockHttpMessageHandler;
        }

        private static Mock<IHttpClientFactory> BuildMockHttpClientFactory(HttpClient mockHttpClient)
        {
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>()))
                                 .Returns(mockHttpClient);

            return mockHttpClientFactory;
        }

        private static Mock<ICapacityDataParser> BuildMockParser(Capacity expectedCapacity)
        {
            var mockParser = new Mock<ICapacityDataParser>();
            mockParser.Setup(x => x.Parse(It.IsAny<string>()))
                      .Returns(Enumerable.Repeat(expectedCapacity, 1));

            return mockParser;
        }

        private static string GetTestData()
        {
            var testRunPath = TestContext.CurrentContext.TestDirectory;
            var testDataFile = Path.Combine(testRunPath, "../../../TestData", "FakeHttpResponseMessageContent.html");

            return File.ReadAllText(testDataFile);
        }
    }
}