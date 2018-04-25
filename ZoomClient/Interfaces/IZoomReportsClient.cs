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
    }
}
