using Newtonsoft.Json;
using System;

namespace AndcultureCode.ZoomClient.Models.Reports
{
    public class MeetingParticipant
    {
        /// <summary>
        /// Zoom Property: name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Zoom Property: user_email
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Zoom Property: join_time
        /// </summary>
        public DateTimeOffset JoinTime { get; set; }

        /// <summary>
        /// Zoom Property: leave_time
        /// </summary>
        public DateTimeOffset LeaveTime { get; set; }

        /// <summary>
        /// Zoom Property: duration
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Zoom Property: attentiveness_score
        /// </summary>
        public string AttentivenessScore { get; set; }
    }
}
