using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class ListMeetings : BaseList
    {
        /// <summary>
        /// Zoom property: meetings
        /// </summary>
        public List<Meeting> Meetings { get; set; }
    }
}
