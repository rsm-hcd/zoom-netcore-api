using AndcultureCode.ZoomClient.Models.Meetings;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Interfaces
{
    public interface IZoomMeetingsClient
    {
        /// <summary>
        /// List meetings for a user. https://zoom.github.io/api/#list-meetings
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        ListMeetings GetMeetings(string userId, MeetingListTypes type = MeetingListTypes.Live, int pageSize = 30, int pageNumber = 1);

        /// <summary>
        /// Create a meeting for a user. https://zoom.github.io/api/#create-a-meeting
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="meeting"></param>
        /// <returns></returns>
        Meeting CreateMeeting(string userId, Meeting meeting);

        /// <summary>
        /// Retrieve a meeting’s details. https://zoom.github.io/api/#retrieve-a-meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        Meeting GetMeeting(string meetingId);

        /// <summary>
        /// Update a meeting’s details. https://zoom.github.io/api/#update-a-meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="meeting"></param>
        /// <returns></returns>
        bool UpdateMeeting(string meetingId, Meeting meeting);

        /// <summary>
        /// Delete a meeting. https://zoom.github.io/api/#delete-a-meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="occurrenceId"></param>
        /// <returns></returns>
        bool DeleteMeeting(string meetingId, string occurrenceId = null);

        /// <summary>
        /// End a meeting. https://zoom.github.io/api/#update-a-meetings-status
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        bool EndMeeting(string meetingId);

        /// <summary>
        /// List registrants of a meeting. https://zoom.github.io/api/#list-a-meetings-registrants
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="status"></param>
        /// <param name="occurrenceId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        ListMeetingRegistrants GetMeetingRegistrants(string meetingId, string status = "approved", string occurrenceId = null, int pageSize = 30, int pageNumber = 1);

        /// <summary>
        /// Register a participant for a meeting. https://zoom.github.io/api/#add-a-meeting-registrant
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="meetingRegistrant"></param>
        /// <param name="occurrenceIds"></param>
        /// <returns></returns>
        MeetingRegistrant CreateMeetingRegistrant(string meetingId, CreateMeetingRegistrant meetingRegistrant, string occurrenceIds = null);

        /// <summary>
        /// Update a meeting registrant’s status. https://zoom.github.io/api/#update-a-meeting-registrants-status
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="registrants"></param>
        /// <param name="status"></param>
        /// <param name="occurrenceId"></param>
        /// <returns></returns>
        bool UpdateMeetingRegistrant(string meetingId, List<UpdateMeetingRegistrant> registrants, string status, string occurrenceId = null);
    }
}
