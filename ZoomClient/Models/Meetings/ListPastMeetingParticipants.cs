using System;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class ListPastMeetingParticipants : BaseList
    {
        /// <summary>
        /// Zoom property: participants
        /// </summary>
        public List<PastMeetingParticipants> Participants { get; set; }
    }
}
