using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class MeetingSettings
    {
        /// <summary>
        /// Zoom Property: host_video
        /// </summary>
        [DeserializeAs(Name = "host_video")]
        [SerializeAs(Name = "host_video")]
        public bool EnableHostVideo { get; set; }

        /// <summary>
        /// Zoom Property: participant_video
        /// </summary>
        [DeserializeAs(Name = "participant_video")]
        [SerializeAs(Name = "participant_video")]
        public bool EnableParticipantVideo { get; set; }

        /// <summary>
        /// Zoom Property: cn_meeting
        /// </summary>
        [DeserializeAs(Name = "cn_meeting")]
        [SerializeAs(Name = "cn_meeting")]
        public bool EnableChinaHost { get; set; }

        /// <summary>
        /// Zoom Property: in_meeting
        /// </summary>
        [DeserializeAs(Name = "in_meeting")]
        [SerializeAs(Name = "in_meeting")]
        public bool EnableIndiaHost { get; set; }

        /// <summary>
        /// Zoom Property: join_before_host
        /// </summary>
        [DeserializeAs(Name = "join_before_host")]
        [SerializeAs(Name = "join_before_host")]
        public bool EnableJoinBeforeHost { get; set; }

        /// <summary>
        /// Zoom Property: mute_upon_entry
        /// </summary>
        [DeserializeAs(Name = "mute_upon_entry")]
        [SerializeAs(Name = "mute_upon_entry")]
        public bool EnableMuteOnEntry { get; set; }

        /// <summary>
        /// Zoom Property: watermark
        /// </summary>
        [DeserializeAs(Name = "watermark")]
        [SerializeAs(Name = "watermark")]
        public bool EnableWatermark { get; set; }

        /// <summary>
        /// Zoom Property: use_pmi
        /// </summary>
        [DeserializeAs(Name = "use_pmi")]
        [SerializeAs(Name = "use_pmi")]
        public bool UsePersonalMeetingId { get; set; }

        /// <summary>
        /// Zoom Property: approval_type
        /// </summary>
        [DeserializeAs(Name = "approval_type")]
        [SerializeAs(Name = "approval_type")]
        public MeetingApprovalTypes ApprovalType { get; set; }

        /// <summary>
        /// Zoom Property: registration_type
        /// </summary>
        [DeserializeAs(Name = "registration_type")]
        [SerializeAs(Name = "registration_type")]
        public MeetingRegistrationTypes RegistrationType { get; set; }

        /// <summary>
        /// Zoom Property: audio
        /// </summary>
        [DeserializeAs(Name = "audio")]
        [SerializeAs(Name = "audio")]
        public string Audio { get; set; }

        /// <summary>
        /// Zoom Property: auto_recording
        /// </summary>
        [DeserializeAs(Name = "auto_recording")]
        [SerializeAs(Name = "auto_recording")]
        public string AutoRecording { get; set; }

        /// <summary>
        /// Zoom Property: enforce_login
        /// </summary>
        [DeserializeAs(Name = "enforce_login")]
        [SerializeAs(Name = "enforce_login")]
        public bool EnableEnforceLogin { get; set; }

        /// <summary>
        /// Zoom Property: enforce_login_domains
        /// </summary>
        [DeserializeAs(Name = "enforce_login_domains")]
        [SerializeAs(Name = "enforce_login_domains")]
        public string EnableEnforceLoginDomains { get; set; }

        /// <summary>
        /// Zoom Property: alternative_hosts
        /// </summary>
        [DeserializeAs(Name = "alterative_hosts")]
        [SerializeAs(Name = "alterative_hosts")]
        public string AlternativeHosts { get; set; }
    }
}
