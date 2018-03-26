using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class Meeting : BaseObject
    {
        /// <summary>
        /// Zoom Property: uuid
        /// </summary>
        [DeserializeAs(Name = "uuid")]
        [SerializeAs(Name = "uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// Zoom Property: topic
        /// </summary>
        [DeserializeAs(Name = "topic")]
        [SerializeAs(Name = "topic")]
        public string Topic { get; set; }

        /// <summary>
        /// Zoom Property: type
        /// </summary>
        [DeserializeAs(Name = "type")]
        [SerializeAs(Name = "type")]
        public MeetingTypes Type { get; set; }

        /// <summary>
        /// Zoom Property: start_time
        /// </summary>
        [DeserializeAs(Name = "start_time")]
        [SerializeAs(Name = "start_time")]
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Zoom Property: duration
        /// </summary>
        [DeserializeAs(Name = "duration")]
        [SerializeAs(Name = "duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Zoom Property: timezone
        /// </summary>
        [DeserializeAs(Name = "timezone")]
        [SerializeAs(Name = "timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Zoom Property: password
        /// </summary>
        [DeserializeAs(Name = "password")]
        [SerializeAs(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Zoom Property: agenda
        /// </summary>
        [DeserializeAs(Name = "agenda")]
        [SerializeAs(Name = "agenda")]
        public string Agenda { get; set; }

        /// <summary>
        /// Zoom Property: recurrence
        /// </summary>
        [DeserializeAs(Name = "recurrence")]
        [SerializeAs(Name = "recurrence")]
        public MeetingRecurrence Recurrence { get; set; }

        /// <summary>
        /// Zoom Property: settings
        /// </summary>
        [DeserializeAs(Name = "settings")]
        [SerializeAs(Name = "settings")]
        public MeetingSettings Settings { get; set; }
    }
}
