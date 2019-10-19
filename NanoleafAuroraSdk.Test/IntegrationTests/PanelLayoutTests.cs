using NanoleafAuroraSdkNanoleafAuroraSdk.Test.Helpers;
using NUnit.Framework;

namespace NanoleafAuroraSdk.Test.IntegrationTests
{
    [TestFixture]
    public class PanelLayoutTests
    {
        private NanoleafAuroraClient ApiClient { get; set; }

        [SetUp]
        public void Setup()
        {
            Assert.IsNotNull(EnvironmentVariables.ApiKey);
            Assert.IsNotNull(EnvironmentVariables.HostAddress);

            ApiClient = new NanoleafAuroraClient(EnvironmentVariables.HostAddress, EnvironmentVariables.ApiKey);
        }

        [Test]
        [Explicit]
        public void GetPanelLayout_NanoleafAuroraFound_PanelCountGreaterThanZero()
        {
            // arrange

            // act
            var response = ApiClient.GetPanelLayout();

            // assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.numPanels > 0);

            TestContext.Out.WriteLine($"numPanels: {response.numPanels}");
        }
    }
}
