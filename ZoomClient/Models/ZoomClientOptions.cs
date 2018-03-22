namespace AndcultureCode.ZoomClient.Models
{
    public class ZoomClientOptions
    {
        /**
         * Defaults to "https://api.zoom.us/v2/"
         */
        public string ZoomApiBaseUrl { get; set; }
        public string ZoomApiKey     { get; set; }
        public string ZoomApiSecret  { get; set; }
    }
}
