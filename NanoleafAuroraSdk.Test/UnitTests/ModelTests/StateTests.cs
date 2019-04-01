using NUnit;
using NUnit.Framework;
using NanoleafAuroraSdk.Test.SampleRequests;
using Newtonsoft.Json;
using NanoleafAuroraSdk.Models.State;

namespace NanoleafAuroraSdk.Test.UnitTests.ModelTests
{
    [TestFixture]
    public class StateTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void LightsOn()
        {
            // arrange
            StateOnRequest stateOnRequest = null;

            // act
            stateOnRequest = JsonConvert.DeserializeObject<StateOnRequest>(SampleRequestBodies.LightsOn);

            // assert
            Assert.IsTrue(stateOnRequest.on.value);
        }

        [Test]
        public void LightsOff()
        {
            // arrange
            StateOnRequest stateOnRequest = null;

            // act
            stateOnRequest = JsonConvert.DeserializeObject<StateOnRequest>(SampleRequestBodies.LightsOff);

            // assert
            Assert.IsFalse(stateOnRequest.on.value);
        }
    }
}