using System;
using System.Collections.Generic;
using System.Text;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class MeetingOccurrence
    {
        /// <summary>
        /// Zoom Property: occurrence_id
        /// <para>Occurrence ID: Unique identifier that identifies an occurrence of a recurring webinar.
        /// <see href="https://support.zoom.us/hc/en-us/articles/216354763-How-to-Schedule-A-Recurring-Webinar">
        /// Recurring webinars</see> can have a maximum of 50 occurrences.</para>
        /// </summary>
        public string OccurenceId { get; set; }

        /// <summary>
        /// Zoom Property: start_time
        /// </summary>
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Zoom Property: duration
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Zoom Property: status
        /// </summary>
        public string Status { get; set; }
    }
}
