using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace AndcultureCode.ZoomClient.Models.Account
{
    public class Account
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
        [DeserializeAs(Name = "password")]
        [SerializeAs(Name = "password")]
        public string Password { get; set; }
        [DeserializeAs(Name = "options")]
        [SerializeAs(Name = "options")]
        public AccountOptions Options { get; set; }
    }
}
