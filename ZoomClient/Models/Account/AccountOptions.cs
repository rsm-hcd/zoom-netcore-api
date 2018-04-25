using Newtonsoft.Json;

namespace AndcultureCode.ZoomClient.Models.Account
{
    public class AccountOptions
    {
        /// <summary>
        /// Zoom property: share_rc
        /// </summary>
        [JsonProperty("share_rc")]
        public bool EnableShareVirtualRoomConnector { get; set; }

        /// <summary>
        /// Zoom property: room_connectors
        /// </summary>
        [JsonProperty("room_connectors")]
        public string VirtualRoomConnectors { get; set; }

        /// <summary>
        /// Zoom property: share_mc
        /// </summary>
        [JsonProperty("share_mc")]
        public bool EnableShareMeetingConnector { get; set; }

        /// <summary>
        /// Zoom property: meeting_connectors
        /// </summary>
        public string MeetingConnectors { get; set; }

        /// <summary>
        /// Zoom property: pay_mode
        /// </summary>
        [JsonProperty("pay_mode")]
        public string PaymentMode { get; set; }
    }
}