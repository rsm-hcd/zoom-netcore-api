using AndcultureCode.ZoomClient.Interfaces;
using RestSharp;
using System;
using AndcultureCode.ZoomClient.Models;
using AndcultureCode.ZoomClient.Extensions;
using AndcultureCode.ZoomClient.Models.Reports;

namespace AndcultureCode.ZoomClient
{
    public class ZoomReportsClient : IZoomReportsClient
    {
        #region Constants

        protected const string GET_MEETING_PARTICIPANTS = "report/meetings/{meetingId}/participants";

        #endregion

        #region Properties

        protected ZoomClientOptions Options { get; set; }
        protected RestClient WebClient { get; set; }

        #endregion

        #region Constructor

        internal ZoomReportsClient(ZoomClientOptions options, RestClient webClient)
        {
            Options = options;
            WebClient = webClient;
        }

        #endregion

        #region IZoomReportsClient Implementation

        public MeetingParticipantsReport GetMeetingParticipantsReport(string meetingId, int pageSize = 30, string nextPageToken = null)
        {
            if (pageSize > 300)
            {
                throw new Exception("GetMeetingParticipantsReport page size max 300");
            }

            var request = BuildRequestAuthorization(GET_MEETING_PARTICIPANTS, Method.GET);
            request.AddParameter("meetingId", meetingId, ParameterType.UrlSegment);
            request.AddParameter("page_size", pageSize, ParameterType.QueryString);
            if (!string.IsNullOrWhiteSpace(nextPageToken))
            {
                request.AddParameter("next_page_token", nextPageToken, ParameterType.QueryString);
            }

            var response = WebClient.Execute<MeetingParticipantsReport>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return null;
        }

        #endregion

        #region Private Methods

        RestRequest BuildRequestAuthorization(string resource, Method method)
        {
            return WebClient.BuildRequestAuthorization(Options, resource, method);
        }

        #endregion
    }
}
