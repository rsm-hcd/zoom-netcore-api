using System;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Reports
{
    public class MeetingReport : BaseTokenList
    {
        /// <summary>
        /// Zoom Property: meetings
        /// </summary>
        public List<Meeting> Meetings { get; set; }
    }
}
