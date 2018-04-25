using Newtonsoft.Json;
using System;

namespace AndcultureCode.ZoomClient.Models.Users
{
    public class User : BaseObject
    {
        /// <summary>
        /// Zoom property: first_name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Zoom property: last_name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Zoom property: email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Zoom property: type
        /// </summary>
        public UserTypes Type { get; set; }

        /// <summary>
        /// Zoom property: pmi
        /// </summary>
        [JsonProperty("pmi")]
        public string PersonalMeetingId { get; set; }

        /// <summary>
        /// Zoom property: timezone
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// Zoom property: dept
        /// </summary>
        [JsonProperty("dept")]
        public string Department { get; set; }

        /// <summary>
        /// Zoom property: created_at
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedTime { get; set; }

        /// <summary>
        /// Zoom property: last_login_time
        /// </summary>
        public DateTimeOffset? LastLoginTime { get; set; }

        /// <summary>
        /// Zoom property: last_client_version
        /// </summary>
        public string LastClientVersion { get; set; }
    }
}
