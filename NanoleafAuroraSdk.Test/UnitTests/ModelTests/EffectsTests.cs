using NanoleafAuroraSdk.Models.Effects;
using NanoleafAuroraSdk.Test.SampleRequests;
using NanoleafAuroraSdk.Test.SampleResponses;
using Newtonsoft.Json;
using NUnit.Framework;

/// <summary>
/// Validates that the expected responses and requests serialize and deserialize from/to the models.
/// </summary>
namespace NanoleafAuroraSdk.Test.UnitTests.ModelTests
{
    [TestFixture]
    public class EffectsTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Deserialize_EffectsListResponse_IsStringArray()
        {
            // arrange
            SelectEffectsListResponse effectsListResponse = null;

            // act
            effectsListResponse = JsonConvert.DeserializeObject<SelectEffectsListResponse>(SampleResponseBodies.EffectsListResponse);

            // assert
            Assert.IsNotNull(effectsListResponse);
            Assert.IsTrue(effectsListResponse.Count > 0);
        }

        [Test]
        public void Serialize_EffectsRequest_IsValidJson()
        {
            // arrange
            SelectEffectsListRequest request = null;

            // act
            request = JsonConvert.DeserializeObject<SelectEffectsListRequest>(SampleRequestBodies.Effects);

            // assert
            Assert.IsNotNull(request);
            Assert.IsTrue(request.select == "Lonely");
        }
    }
}
