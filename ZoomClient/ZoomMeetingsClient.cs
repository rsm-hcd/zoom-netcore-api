using AndcultureCode.ZoomClient.Interfaces;
using RestSharp;
using System;
using AndcultureCode.ZoomClient.Models;
using AndcultureCode.ZoomClient.Extensions;
using AndcultureCode.ZoomClient.Models.Meetings;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient
{
    public class ZoomMeetingsClient : IZoomMeetingsClient
    {
        #region Constants

        const string DELETE_MEETING = "meetings/{meetingId}";

        const string GET_MEETING = "meetings/{meetingId}";
        const string GET_LIST_MEETINGS = "users/{userId}/meetings";
        const string GET_MEETING_REGISTRANTS = "meetings/{meetingId}/registrants";

        const string PATCH_MEETING = "meetings/{meetingId}";
        const string PATCH_MEETING_REGISTRANTS = "meetings/{meetingId}/registrants";

        const string POST_MEETING = "users/{userId}/meetings";
        const string POST_MEETING_REGISTRANTS = "meetings/{meetingId}/registrants";
        const string POST_MEETING_REGISTRANTS_STATUS = "meetings/{meetingId}/registrants/status";

        const string PUT_MEETING = "meetings/{meetingId}/status";
        const string PUT_MEETING_REGISTRANTS = "meetings/{meetingId}/registrants";

        #endregion

        #region Properties

        ZoomClientOptions Options { get; set; }
        RestClient WebClient { get; set; }

        #endregion

        #region Constructor

        internal ZoomMeetingsClient(ZoomClientOptions options, RestClient webClient)
        {
            Options = options;
            WebClient = webClient;
        }

        #endregion

        #region IZoomMeetingsClient Implementation

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

        public Meeting CreateMeeting(string userId, Meeting meeting)
        {
            var request = BuildRequestAuthorization(POST_MEETING, Method.POST);
            request.AddParameter("userId", userId, ParameterType.UrlSegment);
            request.AddJsonBody(meeting);

            var response = WebClient.Execute<Meeting>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.Created)
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

        public Meeting GetMeeting(string meetingId)
        {
            var request = BuildRequestAuthorization(GET_MEETING, Method.GET);
            request.AddParameter("meetingId", meetingId, ParameterType.UrlSegment);

            var response = WebClient.Execute<Meeting>(request);

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

        public bool UpdateMeeting(string meetingId, Meeting meeting)
        {
            var request = BuildRequestAuthorization(PATCH_MEETING, Method.PATCH);
            request.AddParameter("meetingId", meetingId, ParameterType.UrlSegment);
            request.AddJsonBody(meeting);

            var response = WebClient.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return false;
        }

        public bool DeleteMeeting(string meetingId, string occurrenceId = null)
        {
            var request = BuildRequestAuthorization(DELETE_MEETING, Method.DELETE);
            request.AddParameter("meetingId", meetingId, ParameterType.UrlSegment);
            if (!string.IsNullOrWhiteSpace(occurrenceId))
            {
                request.AddParameter("occurrence_id", occurrenceId, ParameterType.QueryString);
            }

            var response = WebClient.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return false;
        }

        public bool EndMeeting(string meetingId)
        {
            var request = BuildRequestAuthorization(PUT_MEETING, Method.PUT);
            request.AddParameter("meetingId", meetingId, ParameterType.UrlSegment);
            request.AddJsonBody(new { action = "end" });

            var response = WebClient.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return false;
        }

        public ListMeetingRegistrants GetMeetingRegistrants(string meetingId, string status = "approved", string occurrenceId = null, int pageSize = 30, int pageNumber = 1)
        {
            if (pageSize > 300)
            {
                throw new Exception("GetMeetingRegistrants page size max 300");
            }

            if (!status.Equals(MeetingRegistrantStatuses.Approved, StringComparison.InvariantCultureIgnoreCase) &&
                !status.Equals(MeetingRegistrantStatuses.Denied, StringComparison.InvariantCultureIgnoreCase) &&
                !status.Equals(MeetingRegistrantStatuses.Pending, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"GetMeetingRegistrants status allowed values are [{MeetingRegistrantStatuses.Approved},{MeetingRegistrantStatuses.Denied},{MeetingRegistrantStatuses.Pending}]");
            }

            var request = BuildRequestAuthorization(GET_MEETING_REGISTRANTS, Method.GET);
            request.AddParameter("meetingId", meetingId, ParameterType.UrlSegment);
            request.AddParameter("status", status, ParameterType.QueryString);
            request.AddParameter("page_size", pageSize, ParameterType.QueryString);
            request.AddParameter("page_number", pageNumber, ParameterType.QueryString);
            if (!string.IsNullOrWhiteSpace(occurrenceId))
            {
                request.AddParameter("occurrence_id", occurrenceId, ParameterType.QueryString);
            }

            var response = WebClient.Execute<ListMeetingRegistrants>(request);

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

        public MeetingRegistrant CreateMeetingRegistrant(string meetingId, CreateMeetingRegistrant meetingRegistrant, string occurrenceIds = null)
        {
            var request = BuildRequestAuthorization(POST_MEETING_REGISTRANTS, Method.POST);
            request.AddParameter("meetingId", meetingId, ParameterType.UrlSegment);
            if (!string.IsNullOrWhiteSpace(occurrenceIds))
            {
                request.AddParameter("occurrence_ids", occurrenceIds, ParameterType.QueryString);
            }
            request.AddJsonBody(meetingRegistrant);

            var response = WebClient.Execute<MeetingRegistrant>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.Created)
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

        public bool UpdateMeetingRegistrant(string meetingId, List<UpdateMeetingRegistrant> registrants, string status, string occurrenceId = null)
        {
            if (!status.Equals(UpdateMeetingRegistrantStatuses.Approve, StringComparison.InvariantCultureIgnoreCase) &&
                !status.Equals(UpdateMeetingRegistrantStatuses.Deny, StringComparison.InvariantCultureIgnoreCase) &&
                !status.Equals(UpdateMeetingRegistrantStatuses.Cancel, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"UpdateMeetingRegistrant status allowed values are [{UpdateMeetingRegistrantStatuses.Approve},{UpdateMeetingRegistrantStatuses.Deny},{UpdateMeetingRegistrantStatuses.Cancel}]");
            }

            var request = BuildRequestAuthorization(POST_MEETING_REGISTRANTS_STATUS, Method.PUT);
            request.AddParameter("meetingId", meetingId, ParameterType.UrlSegment);
            if (!string.IsNullOrWhiteSpace(occurrenceId))
            {
                request.AddParameter("occurrence_id", occurrenceId, ParameterType.QueryString);
            }
            request.AddJsonBody(new { action = status, registrants });

            var response = WebClient.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return false;
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
