using NUnit;
using NUnit.Framework;
using NanoleafAuroraSdk.Test.SampleRequests;
using Newtonsoft.Json;
using NanoleafAuroraSdk.Models.Requests;

namespace NanoleafAuroraSdk.Test.UnitTests.ModelTests
{
    public class StatusTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void LightsOn()
        {
            // arrange
            StateOnRequest obj = null;

            // act
            obj = JsonConvert.DeserializeObject<StateOnRequest>(SampleRequestBodies.LightsOn);

            // assert
            Assert.IsTrue(obj.on.value);
        }

        [Test]
        public void LightsOff()
        {
            // arrange
            StateOnRequest obj = null;

            // act
            obj = JsonConvert.DeserializeObject<StateOnRequest>(SampleRequestBodies.LightsOff);

            // assert
            Assert.IsFalse(obj.on.value);
        }
    }
}