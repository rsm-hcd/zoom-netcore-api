using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace AndcultureCode.ZoomClient.Models.Account
{
    public class AccountOptions
    {
        [DeserializeAs(Name = "share_rc")]
        [SerializeAs(Name = "share_rc")]
        public bool EnableShareVirtualRoomConnector { get; set; }
        [DeserializeAs(Name = "room_connectors")]
        [SerializeAs(Name = "room_connectors")]
        public string VirtualRoomConnectors { get; set; }
        [DeserializeAs(Name = "share_mc")]
        [SerializeAs(Name = "share_mc")]
        public bool EnableShareMeetingConnector { get; set; }
        [DeserializeAs(Name = "meeting_connectors")]
        [SerializeAs(Name = "meeting_connectors")]
        public string MeetingConnectors { get; set; }
        [DeserializeAs(Name = "pay_mode")]
        [SerializeAs(Name = "pay_mode")]
        public string PaymentMode { get; set; }
    }
}