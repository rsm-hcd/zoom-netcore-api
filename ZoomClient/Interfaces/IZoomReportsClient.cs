using AndcultureCode.ZoomClient.Models.Reports;

namespace AndcultureCode.ZoomClient.Interfaces
{
    public interface IZoomReportsClient
    {
        /// <summary>
        /// Retrieve ended meeting participants report. https://zoom.github.io/api/#retrieve-meeting-participants-report
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="pageSize"></param>
        /// <param name="nextPageToken"></param>
        /// <returns></returns>
        MeetingParticipantsReport GetMeetingParticipantsReport(string meetingId, int pageSize = 30, string nextPageToken = null);

        /// <summary>
        /// Retrieve  on a past meeting for a specified period of time. https://marketplace.zoom.us/docs/api-reference/zoom-api/reports/reportmeetings
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="type"></param>
        /// <param name="pageSize"></param>
        /// <param name="nextPageToken"></param>
        /// <returns></returns>
        MeetingReport GetMeetingReport(string userId, string from, string to, MeetingReportTypes type = MeetingReportTypes.Past, int pageSize = 30, string nextPageToken = null);
    }
}
