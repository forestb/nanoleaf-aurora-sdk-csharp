using NanoleafAuroraSdk.ConsoleApp.Helpers;
using NanoleafAuroraSdk.Models;
using NanoleafAuroraSdk.Models.PanelLayout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace NanoleafAuroraSdk.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NanoleafAuroraClient client = new NanoleafAuroraClient(
                EnvironmentVariables.HostAddress, 
                EnvironmentVariables.ApiKey);

            client.TurnLightsOn();

            PanelLayoutResponse panelLayoutResponse = client.GetPanelLayout();

            List<PanelData> panelDataList = new List<PanelData>();
            List<Color> colors = new List<Color>() { Color.Red, Color.Green, Color.Blue };

            new Task(() =>
            {
                while (true)
                {
                    foreach (Color c in colors)
                    {
                        foreach (PositionData panel in panelLayoutResponse.positionData)
                        {
                            client.PaintPanel(new PanelData(panel.panelId, c.R, c.G, c.B));
                            Thread.Sleep(100);
                        }
                    }
                }
                
            }).Start();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
