using AndcultureCode.ZoomClient.Models.Meetings;
using AndcultureCode.ZoomClient.Models.Reports;
using AndcultureCode.ZoomClient.Models.Users;

namespace AndcultureCode.ZoomClient.Interfaces
{
    public interface IZoomClient
    {
        /// <summary>
        /// List meetings for a user. https://zoom.github.io/api/#list-meetings
        /// </summary>
        /// <param name="userId">Can be userId or user email address</param>
        /// <returns></returns>
        ListMeetings GetMeetings(string userId, MeetingListTypes type = MeetingListTypes.Live, int pageSize = 30, int pageNumber = 1);

        /// <summary>
        /// Create a new user on your account. https://zoom.github.io/api/#create-a-user
        /// </summary>
        /// <param name="createUser">User object</param>
        /// <returns></returns>
        User CreateUser(CreateUser createUser);

        /// <summary>
        /// Get meeting participants report. https://zoom.github.io/api/#retrieve-meeting-participants-report
        /// </summary>
        /// <returns></returns>
        MeetingParticipantsReport GetMeetingParticipantsReport(string meetingId, int pageSize = 30, string nextPageToken = null);

        /// <summary>
        /// List users on your account. https://zoom.github.io/api/#list-users
        /// </summary>
        /// <returns></returns>
        ListUsers GetUsers(UserStatuses status = UserStatuses.Active, int pageSize = 30, int pageNumber = 1);
    }
}
