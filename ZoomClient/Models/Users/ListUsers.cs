using RestSharp.Deserializers;
using RestSharp.Serializers;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Users
{
    public class ListUsers : BaseList
    {
        /// <summary>
        /// Zoom property: users
        /// </summary>
        [DeserializeAs(Name = "users")]
        [SerializeAs(Name = "users")]
        public List<User> Users { get; set; }
    }
}
