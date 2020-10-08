using System;
using AndcultureCode.ZoomClient.Models.Meetings;

namespace AndcultureCode.ZoomClient.Models.Reports
{
    public class Meeting
    {
        /// <summary>
        /// Zoom Property: uuid
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// Zoom Property: id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Zoom Property: host_id
        /// </summary>
        public string HostId { get; set; }

        /// <summary>
        /// Zoom Property: type
        /// </summary>
        public MeetingTypes Type { get; set; }

        /// <summary>
        /// Zoom Property: topic
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// Zoom Property: user_name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Zoom Property: user_email
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Zoom Property: start_time
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Zoom Property: end_time
        /// </summary>
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// Zoom Property: duration
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Zoom Property: total_minutes
        /// </summary>
        public int TotalMinutes { get; set; }

        /// <summary>
        /// Zoom Property: participants_count
        /// </summary>
        public int ParticipantsCount { get; set; }
    }
}
