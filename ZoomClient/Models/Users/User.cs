using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;

namespace AndcultureCode.ZoomClient.Models.Users
{
    public class User : BaseObject
    {
        /// <summary>
        /// Zoom property: first_name
        /// </summary>
        [DeserializeAs(Name = "first_name")]
        [SerializeAs(Name = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Zoom property: last_name
        /// </summary>
        [DeserializeAs(Name = "last_name")]
        [SerializeAs(Name = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Zoom property: email
        /// </summary>
        [DeserializeAs(Name = "email")]
        [SerializeAs(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Zoom property: type
        /// </summary>
        [DeserializeAs(Name = "type")]
        [SerializeAs(Name = "type")]
        public UserTypes Type { get; set; }

        /// <summary>
        /// Zoom property: pmi
        /// </summary>
        [DeserializeAs(Name = "pmi")]
        [SerializeAs(Name = "pmi")]
        public string PersonalMeetingId { get; set; }

        /// <summary>
        /// Zoom property: timezone
        /// </summary>
        [DeserializeAs(Name = "timezone")]
        [SerializeAs(Name = "timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Zoom property: dept
        /// </summary>
        [DeserializeAs(Name = "dept")]
        [SerializeAs(Name = "dept")]
        public string Department { get; set; }

        /// <summary>
        /// Zoom property: created_at
        /// </summary>
        [DeserializeAs(Name = "created_at")]
        [SerializeAs(Name = "created_at")]
        public DateTimeOffset? CreatedTime { get; set; }

        /// <summary>
        /// Zoom property: last_login_time
        /// </summary>
        [DeserializeAs(Name = "last_login_time")]
        [SerializeAs(Name = "last_login_time")]
        public DateTimeOffset? LastLoginTime { get; set; }

        /// <summary>
        /// Zoom property: last_client_version
        /// </summary>
        [DeserializeAs(Name = "last_client_version")]
        [SerializeAs(Name = "last_client_version")]
        public string LastClientVersion { get; set; }
    }
}
