using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndcultureCode.ZoomClient.Models.Webinars
{
    public class Webinar : BaseObject
    {
        /// <summary>
        /// Zoom Property: uuid
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// Zoom Property: topic
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// Zoom Property: type
        /// </summary>
        public WebinarTypes Type { get; set; }

        /// <summary>
        /// Zoom Property: start_time
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Zoom Property: duration
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Zoom Property: timezone
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// Zoom Property: password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Zoom Property: agenda
        /// </summary>
        public string Agenda { get; set; }

        /// <summary>
        /// Zoom Property: start_url
        /// </summary>
        public string StartUrl { get; set; }

        /// <summary>
        /// Zoom Property: join_url
        /// </summary>
        public string JoinUrl { get; set; }

        /// <summary>
        /// Zoom Property: recurrence
        /// </summary>
        public WebinarRecurrence Recurrence { get; set; }

        /// <summary>
        /// Zoom Property: settings
        /// </summary>
        public WebinarSettings Settings { get; set; }
 
        /// <summary>
        /// Zoom Property: TrackingField
        /// </summary>
        [JsonProperty("tracking_fields")]
        public WebinarTrackingField[] TrackingFields { get; set; }
    }
}
