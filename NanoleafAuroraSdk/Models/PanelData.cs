using System.Drawing;

namespace NanoleafAuroraSdk.Models
{
    public class PanelData
    {
        public PanelData(int id)
        {
            this.Id = id;
        }

        public PanelData(int id, Color c)
        {

        }

        public PanelData(int id, int red, int green, int blue)
        {
            this.Id = id;
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public int Id { get; set; }

        public int NumberOfFrames { get; set; } = 1;

        public int Red { get; set; } = 0;

        public int Green { get; set; } = 0;

        public int Blue { get; set; } = 0;

        /// <summary>
        /// According to Nanoleaf's documentation: "Note that the W; element is currently ignored. The white LED is 
        /// used automatically during white balancing by Panels based on its internal calibrations."
        /// </summary>
        private int W => 0;

        /// <summary>
        /// To avoid lengthy initial transitions that may not look visually pleasing, we introduce the concept of a 
        /// start frame. If T is set to -1, it is considered a start frame which is initialized instantaneously. 
        /// For logical consistency, a start frame can ONLY occur for the first frame of every panel. Start frames are
        /// not included if the effect is set to loop, which is why T=-1 is used instead of T=0.
        /// </summary>
        public int T { get; set; } = 0;

        public override string ToString()
        {
            return $"{Id} {NumberOfFrames} {Red} {Green} {Blue} {W} {T}";
        }
    }
}
