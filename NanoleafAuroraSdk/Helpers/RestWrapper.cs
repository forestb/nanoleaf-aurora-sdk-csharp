using RestSharp;

namespace NanoleafAuroraSdk.Helpers
{
    internal class RestWrapper
    {
        public RestWrapper(string hostAddress, string apiKey)
        {
            HostAddress = hostAddress;
            ApiKey = apiKey;
        }

        private string HostAddress { get; set; }

        private string ApiKey { get; set; }

        public IRestResponse SubmitRequest(Method method, string relativeUrl, string jsonBody)
        {
            RestClient restCleint = BuildRestClient(HostAddress, ApiKey, relativeUrl);

            RestRequest restRequest = BuildRestRequest(method, jsonBody);

            return ExecuteRestRequest(restCleint, restRequest);
        }

        private RestClient BuildRestClient(string host, string apiKey, string relativeUrl)
        {
            bool shouldRemoveStartingCharacter = relativeUrl.StartsWith("/");

            if (shouldRemoveStartingCharacter)
            {
                relativeUrl = relativeUrl.Substring(1, relativeUrl.Length - 1);
            }

            var client = new RestClient($"http://{host}:16021/api/v1/{apiKey}/{relativeUrl}");

            return client;
        }

        private RestRequest BuildRestRequest(Method method, string jsonBody)
        {
            var request = new RestRequest(method);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddJsonBody(jsonBody);

            return request;
        }

        private IRestResponse ExecuteRestRequest(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }
    }
}
