using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace AndcultureCode.ZoomClient.Models
{
    public abstract class BaseTokenList : BaseList
    {
        /// <summary>
        /// Zoom Property: next_page_token
        /// </summary>
        [DeserializeAs(Name = "next_page_token")]
        [SerializeAs(Name = "next_page_token")]
        public string NextPageToken { get; set; }
    }
}
