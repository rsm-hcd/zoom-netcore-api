using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace AndcultureCode.ZoomClient.Models.Account
{
    public class Account : BaseObject
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
        /// Zoom property: password
        /// </summary>
        [DeserializeAs(Name = "password")]
        [SerializeAs(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Zoom property: options
        /// </summary>
        [DeserializeAs(Name = "options")]
        [SerializeAs(Name = "options")]
        public AccountOptions Options { get; set; }
    }
}
