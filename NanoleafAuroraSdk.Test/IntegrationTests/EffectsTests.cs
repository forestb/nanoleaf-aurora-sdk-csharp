using NanoleafAuroraSdk.Models;
using NanoleafAuroraSdk.Models.PanelLayout;
using NanoleafAuroraSdkNanoleafAuroraSdk.Test.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoleafAuroraSdk.Test.IntegrationTests
{
    [TestFixture]
    public class EffectsTests
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
        public void PaintPanel_MakeFirstPanelWhite_WhenPanelGroupFound()
        {
            // arrange
            PanelLayoutResponse panelLayoutResponse = ApiClient.GetPanelLayout();

            var firstPanel = panelLayoutResponse.positionData.FirstOrDefault();

            PanelData panelData = new PanelData(firstPanel.panelId, Color.White.R, Color.White.G, Color.White.B);

            // act
            var response = ApiClient.PaintPanel(panelData);

            // assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        [Test]
        //[Ignore("Integration test")]
        public void PaintPanels_MakeAllPanelsWhite_WhenPanelGroupFound()
        {
            // arrange
            PanelLayoutResponse panelLayoutResponse = ApiClient.GetPanelLayout();

            List<PanelData> panelDataList = new List<PanelData>();

            foreach(PositionData panel in panelLayoutResponse.positionData)
            {
                panelDataList.Add(new PanelData(panel.panelId, Color.White.R, Color.White.G, Color.White.B));
            }

            // act
            var response = ApiClient.PaintPanels(panelDataList);

            // assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        [Test]
        [Explicit]
        public void PaintPanels_MakeAllPanelsYellow_WhenPanelGroupFound()
        {
            // arrange
            PanelLayoutResponse panelLayoutResponse = ApiClient.GetPanelLayout();

            List<PanelData> panelDataList = new List<PanelData>();

            foreach (PositionData panel in panelLayoutResponse.positionData)
            {
                panelDataList.Add(new PanelData(panel.panelId, Color.Yellow.R, Color.Yellow.G, Color.Yellow.B));
            }

            // act
            var response = ApiClient.PaintPanels(panelDataList);

            // assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        [Test]
        public void GetListOfEffects_ReturnsMoreThanOne_WhenPanelGroupFoudn()
        {
            // arrange

            // act
            var response = ApiClient.GetListOfEffects();

            TestContext.Out.WriteLine($"effects count: {response.Count}");

            // assert
            Assert.IsTrue(response.Count > 0);
        }

        [Test]
        //[Explicit]
        public void SetEffect_Returns204_WhenFirstAvailableEffectSelected()
        {
            // arrange
            var firstEffect = ApiClient.GetListOfEffects().FirstOrDefault();

            // act
            var response = ApiClient.SetEffect(firstEffect);

            TestContext.Out.WriteLine($"effect: {firstEffect}");

            // assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        [Test]
        //[Explicit]
        public void SetEffect_Returns204_WhenLastAvailableEffectSelected()
        {
            // arrange
            var lastEffect = ApiClient.GetListOfEffects().LastOrDefault();

            // act
            var response = ApiClient.SetEffect(lastEffect);

            TestContext.Out.WriteLine($"effect: {lastEffect}");

            // assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }
    }
}
