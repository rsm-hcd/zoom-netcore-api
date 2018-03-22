using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;

namespace AndcultureCode.ZoomClient.Models.Users
{
    public class User
    {
        [DeserializeAs(Name = "first_name")]
        [SerializeAs(Name = "first_name")]
        public string FirstName { get; set; }
        [DeserializeAs(Name = "last_name")]
        [SerializeAs(Name = "last_name")]
        public string LastName { get; set; }
        [DeserializeAs(Name = "email")]
        [SerializeAs(Name = "email")]
        public string Email { get; set; }
        [DeserializeAs(Name = "type")]
        [SerializeAs(Name = "type")]
        public UserTypes Type { get; set; }
        [DeserializeAs(Name = "pmi")]
        [SerializeAs(Name = "pmi")]
        public string PersonalMeetingId { get; set; }
        [DeserializeAs(Name = "timezone")]
        [SerializeAs(Name = "timezone")]
        public string Timezone { get; set; }
        [DeserializeAs(Name = "dept")]
        [SerializeAs(Name = "dept")]
        public string Department { get; set; }
        [DeserializeAs(Name = "created_at")]
        [SerializeAs(Name = "created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        [DeserializeAs(Name = "last_login_time")]
        [SerializeAs(Name = "last_login_time")]
        public DateTimeOffset? LastLoginAt { get; set; }
        [DeserializeAs(Name = "last_client_version")]
        [SerializeAs(Name = "last_client_version")]
        public string LastClientVersion { get; set; }
    }
}
