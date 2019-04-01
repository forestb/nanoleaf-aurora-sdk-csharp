using NUnit;
using NUnit.Framework;
using NanoleafAuroraSdk.Test.SampleRequests;
using Newtonsoft.Json;
using NanoleafAuroraSdk.Models.Requests;
using System;
using NanoleafAuroraSdkNanoleafAuroraSdk.Test.Helpers;
using RestSharp;

namespace NanoleafAuroraSdk.Test.IntegrationTests
{
    [TestFixture, Explicit]
    public class StatusTests
    {
        [SetUp]
        public void Setup()
        {
            Assert.IsNotNull(EnvironmentVariables.ApiKey);
            Assert.IsNotNull(EnvironmentVariables.HostAddress);
        }

        [Test]
        public void LightsOn()
        {
            // arrange
            StateOnRequest obj = null;

            // act
            obj = JsonConvert.DeserializeObject<StateOnRequest>(SampleRequestBodies.LightsOn);

            var client = new RestClient($"http://{EnvironmentVariables.HostAddress}/api/v1/{EnvironmentVariables.ApiKey}/state");
            var request = new RestRequest(Method.PUT);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddJsonBody(SampleRequestBodies.LightsOn);

            IRestResponse response = client.Execute(request);

            // assert
            Assert.Pass();
        }

        [Test]
        public void LightsOff()
        {
            // arrange
            StateOnRequest obj = null;

            // act
            obj = JsonConvert.DeserializeObject<StateOnRequest>(SampleRequestBodies.LightsOn);

            var client = new RestClient($"http://{EnvironmentVariables.HostAddress}/api/v1/{EnvironmentVariables.ApiKey}/state");
            var request = new RestRequest(Method.PUT);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddJsonBody(SampleRequestBodies.LightsOff);

            IRestResponse response = client.Execute(request);

            // assert
            Assert.Pass();
        }
    }
}
