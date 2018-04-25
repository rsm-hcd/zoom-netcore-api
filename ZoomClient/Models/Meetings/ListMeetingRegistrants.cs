using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class ListMeetingRegistrants : BaseList
    {
        /// <summary>
        /// Zoom property: registrants
        /// </summary>
        public List<MeetingRegistrant> Registrants { get; set; }
    }
}
