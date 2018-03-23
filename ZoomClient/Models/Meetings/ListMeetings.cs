using RestSharp.Deserializers;
using RestSharp.Serializers;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class ListMeetings : BaseList
    {
        /// <summary>
        /// Zoom property: meetings
        /// </summary>
        [DeserializeAs(Name = "meetings")]
        [SerializeAs(Name = "meetings")]
        public List<Meeting> Meetings { get; set; }
    }
}
