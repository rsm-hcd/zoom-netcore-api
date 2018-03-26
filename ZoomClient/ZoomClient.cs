using AndcultureCode.ZoomClient.Interfaces;
using AndcultureCode.ZoomClient.Models;
using AndcultureCode.ZoomClient.Models.Meetings;
using AndcultureCode.ZoomClient.Models.Reports;
using AndcultureCode.ZoomClient.Models.Users;
using Jose;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndcultureCode.ZoomClient
{
    public class ZoomClient : IZoomClient
    {
        #region Constants

        const string BASE_URL = "https://api.zoom.us/v2/";

        const string DELETE_SUBACCOUNT         = "accounts/{accountId}";

        const string GET_LIST_ACCOUNTS         = "accounts";
        const string GET_LIST_MEETINGS         = "users/{userId}/meetings";
        const string GET_LIST_USERS            = "users";
        const string GET_MEETING_PARTICIPANTS  = "report/meetings/{meetingId}/participants";
        const string GET_SUBACCOUNT            = "accounts/{accountId}";
        const string GET_SUBACCOUNT_SETTINGS   = "accounts/{accountId}/settings";

        const string PATCH_SUBACCOUNT          = "accounts/{accountId}/options";
        const string PATCH_SUBACCOUNT_SETTINGS = "accounts/{accountId}/settings";

        const string POST_ACCOUNT              = "accounts";
        const string POST_CREATE_USER          = "users";

        #endregion

        #region Properties
        ZoomClientOptions Options   { get; set; }
        RestClient    WebClient { get; set; }

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
        }

        #endregion

        #region IZoomClient Implementation

        public ListMeetings GetMeetings(string userId, MeetingListTypes type = MeetingListTypes.Live, int pageSize = 30, int pageNumber = 1)
        {
            if (pageSize > 300)
            {
                throw new Exception("GetMeetings page size max 300");
            }

            var request = BuildRequestAuthorization(GET_LIST_MEETINGS, Method.GET);
            request.AddParameter("userId", userId, ParameterType.UrlSegment);
            request.AddParameter("type", type.ToString().ToLowerInvariant(), ParameterType.QueryString);
            request.AddParameter("page_size", pageSize, ParameterType.QueryString);
            request.AddParameter("page_number", pageNumber, ParameterType.QueryString);

            var response = WebClient.Execute<ListMeetings>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }

            throw new Exception(response.ErrorMessage);
        }

        public User CreateUser(CreateUser createUser)
        {
            var validateResult = createUser.Validate();
            if (validateResult.Count > 0)
            {
                throw new Exception($"CreateUser request does not pass validation. {string.Join(" :: ", validateResult)}");
            }

            var request = BuildRequestAuthorization(POST_CREATE_USER, Method.POST);
            request.AddBody(createUser);

            var response = WebClient.Execute<User>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }

            throw new Exception(response.ErrorMessage);
        }

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

            throw new Exception(response.ErrorMessage);
        }

        public ListUsers GetUsers(UserStatuses status = UserStatuses.Active, int pageSize = 30, int pageNumber = 1)
        {
            if (pageSize > 300)
            {
                throw new Exception("GetUsers page size max 300");
            }

            var request = BuildRequestAuthorization(GET_LIST_USERS, Method.GET);
            request.AddParameter("status", status.ToString().ToLowerInvariant(), ParameterType.QueryString);
            request.AddParameter("page_size", pageSize, ParameterType.QueryString);
            request.AddParameter("page_number", pageNumber, ParameterType.QueryString);

            var response = WebClient.Execute<ListUsers>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }

            throw new Exception(response.ErrorMessage);
        }

        #endregion

        #region Private Methods

        RestRequest BuildRequestAuthorization(string resource, Method method)
        {
            var request = new RestRequest(resource, method);

            var payload = new Dictionary<string, object>()
            {
                { "iss", Options.ZoomApiKey },
                { "exp", new DateTimeOffset(DateTime.UtcNow.AddMinutes(1)).ToUnixTimeSeconds() }
            };

            WebClient.Authenticator = new JwtAuthenticator(JWT.Encode(payload, Encoding.UTF8.GetBytes(Options.ZoomApiSecret), JwsAlgorithm.HS256));
            return request;
        }

        #endregion
    }
}
