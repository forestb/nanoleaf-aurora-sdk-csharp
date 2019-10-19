namespace NanoleafAuroraSdk.Models.Effects
{
    public class Write
    {
        /// <summary>
        /// required, Command type: add, request, delete, display, rename, requestAll
        /// </summary>
        public string command { get; set; }

        /// <summary>
        /// required, effect type: random, flow, wheel, fade, highlight, custom, static
        /// </summary>
        public string animType { get; set; }

        /// <summary>
        /// not required, Rendered effect data: only needed for custom and static types
        /// </summary>
        public string animData { get; set; }

        /// <summary>
        /// required
        /// </summary>
        public bool loop { get; set; }
    }

    public class WriteEffectsRequest
    {
        public Write write { get; set; }
    }
}
