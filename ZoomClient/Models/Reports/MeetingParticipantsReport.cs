using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Reports
{
    public class MeetingParticipantsReport : BaseTokenList
    {
        /// <summary>
        /// Zoom Property: participants
        /// </summary>
        public List<MeetingParticipant> Participants { get; set; }
    }
}
