using NanoleafAuroraSdk.Helpers;
using NanoleafAuroraSdk.Models;
using NanoleafAuroraSdk.Models.Effects;
using NanoleafAuroraSdk.Models.PanelLayout;
using NanoleafAuroraSdk.Models.State;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace NanoleafAuroraSdk
{
    public class NanoleafAuroraClient
    {
        public NanoleafAuroraClient(string hostAddress, string apiKey)
        {
            RestClient = new RestWrapper(hostAddress, apiKey);
        }

        private RestWrapper RestClient { get; set; }

        public PanelLayoutResponse GetPanelLayout()
        {
            const string relativeUrl = "/panelLayout/layout";

            IRestResponse restResponse = RestClient.SubmitRequest(Method.GET, relativeUrl, null);

            return restResponse.IsSuccessful ?
                JsonConvert.DeserializeObject<PanelLayoutResponse>(restResponse.Content) :
                null;
        }

        public StateOnResponse TurnLightsOn()
        {
            const string relativeUrl = "/state";

            StateOnRequest request = new StateOnRequest() { on = new On() { value = true } };

            IRestResponse restResponse = RestClient.SubmitRequest(Method.PUT, relativeUrl, JsonConvert.SerializeObject(request));

            return restResponse.IsSuccessful ?
                new StateOnResponse() { StatusCode = restResponse.StatusCode } :
                null;
        }

        public StateOnResponse TurnLightsOff()
        {
            const string relativeUrl = "/state";

            StateOnRequest request = new StateOnRequest() { on = new On() { value = false } };

            IRestResponse restResponse = RestClient.SubmitRequest(Method.PUT, relativeUrl, JsonConvert.SerializeObject(request));

            return restResponse.IsSuccessful ?
                new StateOnResponse() { StatusCode = restResponse.StatusCode } :
                null;
        }

        public WriteEffectsResponse PaintPanel(PanelData panelData)
        {
            const string relativeUrl = "/effects";

            WriteEffectsRequest request = new WriteEffectsRequest()
            {
                write = new Write()
                {
                    command = "display",
                    animType = "static",
                    loop = false
                }
            };

            const int numberOfPanels = 1;

            request.write.animData = $"{numberOfPanels} {panelData}";

            IRestResponse restResponse = RestClient.SubmitRequest(Method.PUT, relativeUrl, JsonConvert.SerializeObject(request));

            return restResponse.IsSuccessful ?
                new WriteEffectsResponse() { StatusCode = restResponse.StatusCode } :
                null;
        }

        public WriteEffectsResponse PaintPanels(List<PanelData> panelDataList)
        {
            const string relativeUrl = "/effects";

            WriteEffectsRequest request = new WriteEffectsRequest()
            {
                write = new Write()
                {
                    command = "display",
                    animType = "static",
                    loop = false
                }
            };

            request.write.animData += panelDataList.Count;
            panelDataList.ForEach(panelData => request.write.animData += $" {panelData}");

            IRestResponse restResponse = RestClient.SubmitRequest(Method.PUT, relativeUrl, JsonConvert.SerializeObject(request));

            return restResponse.IsSuccessful ?
                new WriteEffectsResponse() { StatusCode = restResponse.StatusCode } :
                null;
        }

        public SelectEffectsListResponse GetListOfEffects()
        {
            const string relativeUrl = "/effects/effectsList";

            SelectEffectsListRequest request = new SelectEffectsListRequest();

            IRestResponse restResponse = RestClient.SubmitRequest(Method.GET, relativeUrl, JsonConvert.SerializeObject(request));

            return restResponse.IsSuccessful ?
                JsonConvert.DeserializeObject<SelectEffectsListResponse>(restResponse.Content) :
                null;
        }

        public SelectEffectResponse SetEffect(string effect)
        {
            const string relativeUrl = "/effects";

            SelectEffectRequest request = new SelectEffectRequest() { select = effect };

            IRestResponse restResponse = RestClient.SubmitRequest(Method.PUT, relativeUrl, JsonConvert.SerializeObject(request));

            return restResponse.IsSuccessful ?
                new SelectEffectResponse() { StatusCode = restResponse.StatusCode } :
                null;
        }
    }
}
