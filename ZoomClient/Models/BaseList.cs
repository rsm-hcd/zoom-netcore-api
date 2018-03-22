using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace AndcultureCode.ZoomClient.Models
{
    public abstract class BaseList
    {
        [DeserializeAs(Name = "page_count")]
        [SerializeAs(Name = "page_count")]
        public int PageCount { get; set; }
        [DeserializeAs(Name = "page_number")]
        [SerializeAs(Name = "page_number")]
        public int PageNumber { get; set; }
        [DeserializeAs(Name = "page_size")]
        [SerializeAs(Name = "page_size")]
        public int PageSize { get; set; }
        [DeserializeAs(Name = "total_records")]
        [SerializeAs(Name = "total_records")]
        public int TotalRecords { get; set; }
    }
}
