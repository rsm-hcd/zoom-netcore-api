using AndcultureCode.ZoomClient.Interfaces;
using AndcultureCode.ZoomClient.Models;
using RestSharp;
using System;

namespace AndcultureCode.ZoomClient
{
    public class ZoomClient : IZoomClient
    {
        #region Constants

        protected const string BASE_URL = "https://api.zoom.us/v2/";

        #endregion

        #region Properties

        ZoomClientOptions Options   { get; set; }
        RestClient        WebClient { get; set; }

        public IZoomMeetingsClient Meetings { get; set; }
        public IZoomReportsClient  Reports { get; set; }
        public IZoomUsersClient    Users { get; set; }

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

            Meetings = new ZoomMeetingsClient(Options, WebClient);
            Reports = new ZoomReportsClient(Options, WebClient);
            Users = new ZoomUsersClient(Options, WebClient);
        }

        #endregion
    }
}
