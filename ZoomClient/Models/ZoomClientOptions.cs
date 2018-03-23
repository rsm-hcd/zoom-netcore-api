namespace AndcultureCode.ZoomClient.Models
{
    public class ZoomClientOptions
    {
        /// <summary>
        /// Base Url for api requests. Defaults to "https://api.zoom.us/v2/"
        /// </summary>
        public string ZoomApiBaseUrl { get; set; }

        /// <summary>
        /// Api key for zoom account. https://developer.zoom.us/me/#api
        /// </summary>
        public string ZoomApiKey     { get; set; }

        /// <summary>
        /// Api secret for zoom account. https://developer.zoom.us/me/#api
        /// </summary>
        public string ZoomApiSecret  { get; set; }
    }
}
