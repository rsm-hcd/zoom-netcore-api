using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace AndcultureCode.ZoomClient.Models
{
    public abstract class BaseObject
    {
        /// <summary>
        /// Zoom Property: id
        /// </summary>
        [DeserializeAs(Name = "id")]
        [SerializeAs(Name = "id")]
        public string Id { get; set; }
    }
}
