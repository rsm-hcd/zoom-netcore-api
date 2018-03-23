using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace AndcultureCode.ZoomClient.Models
{
    public abstract class BaseList
    {
        /// <summary>
        /// Zoom Property: page_count
        /// </summary>
        [DeserializeAs(Name = "page_count")]
        [SerializeAs(Name = "page_count")]
        public int PageCount { get; set; }

        /// <summary>
        /// Zoom Property: page_number
        /// </summary>
        [DeserializeAs(Name = "page_number")]
        [SerializeAs(Name = "page_number")]
        public int PageNumber { get; set; }

        /// <summary>
        /// Zoom Property: page_size
        /// </summary>
        [DeserializeAs(Name = "page_size")]
        [SerializeAs(Name = "page_size")]
        public int PageSize { get; set; }

        /// <summary>
        /// Zoom Property: total_records
        /// </summary>
        [DeserializeAs(Name = "total_records")]
        [SerializeAs(Name = "total_records")]
        public int TotalRecords { get; set; }
    }
}
