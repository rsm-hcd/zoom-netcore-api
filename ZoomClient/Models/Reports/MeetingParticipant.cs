using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;

namespace AndcultureCode.ZoomClient.Models.Reports
{
    public class MeetingParticipant
    {
        /// <summary>
        /// Zoom Property: name
        /// </summary>
        [DeserializeAs(Name = "name")]
        [SerializeAs(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Zoom Property: user_email
        /// </summary>
        [DeserializeAs(Name = "user_email")]
        [SerializeAs(Name = "user_email")]
        public string Email { get; set; }

        /// <summary>
        /// Zoom Property: join_time
        /// </summary>
        [DeserializeAs(Name = "join_time")]
        [SerializeAs(Name = "join_time")]
        public DateTimeOffset JoinTime { get; set; }

        /// <summary>
        /// Zoom Property: leave_time
        /// </summary>
        [DeserializeAs(Name = "leave_time")]
        [SerializeAs(Name = "leave_time")]
        public DateTimeOffset LeaveTime { get; set; }

        /// <summary>
        /// Zoom Property: duration
        /// </summary>
        [DeserializeAs(Name = "duration")]
        [SerializeAs(Name = "duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Zoom Property: attentiveness_score
        /// </summary>
        [DeserializeAs(Name = "attentiveness_score")]
        [SerializeAs(Name = "attentiveness_score")]
        public string AttentivenessScore { get; set; }
    }
}
