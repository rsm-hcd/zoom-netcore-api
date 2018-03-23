using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace AndcultureCode.ZoomClient.Models.Account
{
    public class AccountOptions
    {
        /// <summary>
        /// Zoom property: share_rc
        /// </summary>
        [DeserializeAs(Name = "share_rc")]
        [SerializeAs(Name = "share_rc")]
        public bool EnableShareVirtualRoomConnector { get; set; }

        /// <summary>
        /// Zoom property: room_connectors
        /// </summary>
        [DeserializeAs(Name = "room_connectors")]
        [SerializeAs(Name = "room_connectors")]
        public string VirtualRoomConnectors { get; set; }

        /// <summary>
        /// Zoom property: share_mc
        /// </summary>
        [DeserializeAs(Name = "share_mc")]
        [SerializeAs(Name = "share_mc")]
        public bool EnableShareMeetingConnector { get; set; }

        /// <summary>
        /// Zoom property: meeting_connectors
        /// </summary>
        [DeserializeAs(Name = "meeting_connectors")]
        [SerializeAs(Name = "meeting_connectors")]
        public string MeetingConnectors { get; set; }

        /// <summary>
        /// Zoom property: pay_mode
        /// </summary>
        [DeserializeAs(Name = "pay_mode")]
        [SerializeAs(Name = "pay_mode")]
        public string PaymentMode { get; set; }
    }
}