using Newtonsoft.Json;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class MeetingSettings
    {
        /// <summary>
        /// Zoom Property: host_video
        /// </summary>
        [JsonProperty("host_video")]
        public bool EnableHostVideo { get; set; }

        /// <summary>
        /// Zoom Property: participant_video
        /// </summary>
        [JsonProperty("participant_video")]
        public bool EnableParticipantVideo { get; set; }

        /// <summary>
        /// Zoom Property: cn_meeting
        /// </summary>
        [JsonProperty("cn_meeting")]
        public bool EnableChinaHost { get; set; }

        /// <summary>
        /// Zoom Property: in_meeting
        /// </summary>
        [JsonProperty("in_meeting")]
        public bool EnableIndiaHost { get; set; }

        /// <summary>
        /// Zoom Property: join_before_host
        /// </summary>
        [JsonProperty("join_before_host")]
        public bool EnableJoinBeforeHost { get; set; }

        /// <summary>
        /// Zoom Property: mute_upon_entry
        /// </summary>
        [JsonProperty("mute_upon_entry")]
        public bool EnableMuteOnEntry { get; set; }

        /// <summary>
        /// Zoom Property: watermark
        /// </summary>
        [JsonProperty("watermark")]
        public bool EnableWatermark { get; set; }

        /// <summary>
        /// Zoom Property: use_pmi
        /// </summary>
        [JsonProperty("use_pmi")]
        public bool UsePersonalMeetingId { get; set; }

        /// <summary>
        /// Zoom Property: approval_type
        /// </summary>
        public MeetingApprovalTypes ApprovalType { get; set; }

        /// <summary>
        /// Zoom Property: registration_type
        /// </summary>
        public MeetingRegistrationTypes RegistrationType { get; set; }

        /// <summary>
        /// Zoom Property: audio
        /// </summary>
        public string Audio { get; set; }

        /// <summary>
        /// Zoom Property: auto_recording
        /// </summary>
        public string AutoRecording { get; set; }

        /// <summary>
        /// Zoom Property: enforce_login
        /// </summary>
        [JsonProperty("enforce_login")]
        public bool EnableEnforceLogin { get; set; }

        /// <summary>
        /// Zoom Property: enforce_login_domains
        /// </summary>
        [JsonProperty("enforce_login_domains")]
        public string EnableEnforceLoginDomains { get; set; }

        /// <summary>
        /// Zoom Property: alternative_hosts
        /// </summary>
        public string AlternativeHosts { get; set; }
    }
}
