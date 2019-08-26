using AndcultureCode.ZoomClient.Interfaces;
using AndcultureCode.ZoomClient.Models;
using RestSharp;
using RestSharp.Serializers;
using System;

namespace AndcultureCode.ZoomClient
{
    public class ZoomClient : IZoomClient
    {
        #region Constants

        protected const string BASE_URL = "https://api.zoom.us/v2/";

        #endregion

        #region Properties

        ZoomClientOptions Options   { get; }
        RestClient        WebClient { get; }

        public IZoomGroupsClient   Groups   { get; }
        public IZoomMeetingsClient Meetings { get; }
        public IZoomReportsClient  Reports  { get; }
        public IZoomUsersClient    Users    { get; }
        public IZoomWebhookClient  Webhooks { get; }

        #endregion

        #region Constructor

        public ZoomClient(ZoomClientOptions options)
        {
            if (options == null)
            {
                throw new Exception("No options provided for zoom client");
            }

            if (string.IsNullOrWhiteSpace(options.ZoomApiKey))
            {
                throw new Exception("No api key provided for zoom client");
            }

            if (string.IsNullOrWhiteSpace(options.ZoomApiSecret))
            {
                throw new Exception("No api secret provided for zoom client");
            }

            Options = options;
            if (string.IsNullOrWhiteSpace(Options.ZoomApiBaseUrl))
            {
                Options.ZoomApiBaseUrl = BASE_URL;
            }

            WebClient = new RestClient(options.ZoomApiBaseUrl);

            // Override with Newtonsoft JSON Handler
            WebClient.AddHandler("application/json", () => NewtonsoftJsonSerializer.Default);
            WebClient.AddHandler("text/json", () => NewtonsoftJsonSerializer.Default);
            WebClient.AddHandler("text/x-json", () => NewtonsoftJsonSerializer.Default);
            WebClient.AddHandler("text/javascript", () => NewtonsoftJsonSerializer.Default);
            WebClient.AddHandler("*+json", () => NewtonsoftJsonSerializer.Default);

            Groups   = new ZoomGroupsClient(Options, WebClient);
            Meetings = new ZoomMeetingsClient(Options, WebClient);
            Reports  = new ZoomReportsClient(Options, WebClient);
            Users    = new ZoomUsersClient(Options, WebClient);
            Webhooks = new ZoomWebhookClient(Options, WebClient);
        }

        #endregion
    }
}
