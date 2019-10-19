using NUnit.Framework;
using NanoleafAuroraSdkNanoleafAuroraSdk.Test.Helpers;
using NanoleafAuroraSdk.Models.State;

namespace NanoleafAuroraSdk.Test.IntegrationTests
{
    [TestFixture]
    public class StateTests
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
        public void TurnLightsOn_NanoleafAuroraFound_Returns204()
        {
            // arrange

            // act
            StateOnResponse response = ApiClient.TurnLightsOn();

            // assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        [Test]
        [Explicit]
        public void TurnLightsOff_NanoleafAuroraFound_Returns204()
        {
            // arrange

            // act
            StateOnResponse response = ApiClient.TurnLightsOff();

            // assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }
    }
}
