using Newtonsoft.Json;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class MeetingSettings
    {
        /// <summary>
        /// Zoom Property: host_video
        /// <para>Start video when the host joins the meeting.</para>
        /// </summary>
        [JsonProperty("host_video")]
        public bool EnableHostVideo { get; set; }

        /// <summary>
        /// Zoom Property: participant_video
        /// <para>Start video when participants join the meeting.</para>
        /// </summary>
        [JsonProperty("participant_video")]
        public bool EnableParticipantVideo { get; set; }

        /// <summary>
        /// Zoom Property: cn_meeting
        /// <para>Host meeting in China.</para>
        /// </summary>
        [JsonProperty("cn_meeting")]
        public bool EnableChinaHost { get; set; }

        /// <summary>
        /// Zoom Property: in_meeting
        /// <para>Host meeting in India.</para>
        /// </summary>
        [JsonProperty("in_meeting")]
        public bool EnableIndiaHost { get; set; }

        /// <summary>
        /// Zoom Property: join_before_host
        /// <para>Allow participants to join the meeting before the host starts the meeting. 
        /// This field can only be used for scheduled or recurring meetings.</para>
        /// <para><strong>Note:</strong> If waiting room is enabled, 
        /// the <strong>join before host</strong> setting will be disabled.</para>
        /// </summary>
        [JsonProperty("join_before_host")]
        public bool EnableJoinBeforeHost { get; set; }

        /// <summary>
        /// Zoom Property: mute_upon_entry
        /// <para>Mute participants upon entry.</para>
        /// </summary>
        [JsonProperty("mute_upon_entry")]
        public bool EnableMuteOnEntry { get; set; }

        /// <summary>
        /// Zoom Property: watermark
        /// <para>Add watermark when viewing a shared screen.</para>
        /// </summary>
        [JsonProperty("watermark")]
        public bool EnableWatermark { get; set; }

        /// <summary>
        /// Zoom Property: use_pmi
        /// <para>Use Personal Meeting ID instead of an automatically generated meeting ID. 
        /// It can only be used for scheduled meetings, instant meetings, and recurring
        /// meetings with no fixed time.</para>
        /// </summary>
        [JsonProperty("use_pmi")]
        public bool UsePersonalMeetingId { get; set; }

        /// <summary>
        /// Zoom Property: approval_type
        /// <para></para>
        /// 0 = Automatically approve.<br/>
        /// 1 = Manually approve.<br/>
        /// 2 = No registration required.<br/>
        /// </summary>
        public MeetingApprovalTypes ApprovalType { get; set; }

        /// <summary>
        /// Zoom Property: registration_type
        /// <para>Registration type. Used for recurring meeting with fixed time only.</para>
        /// 1 = Attendees register once and can attend any of the occurrences.<br/>
        /// 2 = Attendees need to register for each occurrence to attend.<br/>
        /// 3 = Attendees register once and can choose one or more occurrences to attend.<br/>
        /// </summary>
        public MeetingRegistrationTypes RegistrationType { get; set; }

        /// <summary>
        /// Zoom Property: audio
        /// <para>Determine how participants can join the audio portion of the meeting.</para>
        /// both = Both Telephony and VoIP.<br/>
        /// telephony = Telephony only.<br/>
        /// voip = VoIP only.<br/>
        /// </summary>
        public string Audio { get; set; }

        /// <summary>
        /// Zoom Property: auto_recording
        /// <para>Automatic recording</para>
        /// local = Record on local.<br/>
        /// cloud = Record on cloud.<br/>
        /// none = Disabled.<br/>
        /// </summary>
        public string AutoRecording { get; set; }

        /// <summary>
        /// Zoom Property: alternative_hosts
        /// <para>Alternative host's emails or IDs: multiple values separated by a comma.</para>
        /// </summary>
        public string AlternativeHosts { get; set; }

        /// <summary>
        /// Zoom Property: close_registration
        /// <para>Close registration after event date.</para>
        /// </summary>
        [JsonProperty("close_registration")]
        public bool EnableCloseRegistration { get; set; }


        /// <summary>
        /// Zoom Property: waiting_room
        /// <para>Enable waiting room. Note that if the value of this field is set to <strong>true</strong>
        /// , it will override and disable the <strong>join_before_host</strong> setting.</para>
        /// </summary>
        [JsonProperty("waiting_room")]
        public bool EnableWaitingRoom { get; set; }

        /// <summary>
        /// Zoom Property: global_dial_in_countries
        /// <para>List of global dial-in countries.</para>
        /// </summary>
        public string[] GlobalDialInCountries { get; set; }

        /// <summary>
        /// Zoom Property: global_dial_in_numbers
        /// <para>Global Dial-in Countries/Regions.</para>
        /// </summary>
        public MeetingGlobalDialInNumber[] GlobalDialInNumbers { get; set; }

        /// <summary>
        /// Zoom Property: contact_name
        /// <para>Contact name for registration.</para>
        /// </summary>
        public string ContactName { get; set; }


        /// <summary>
        /// Zoom Property: contact_email
        /// <para>Contact email for registration.</para>
        /// </summary>
        public string ContactEmail { get; set; }

        /// <summary>
        /// Zoom Property: registrants_email_notification
        /// <para>Send email notifications to registrants about approval, cancellation, denial of the registration.
        /// The value of this field must be set to true in order to use the 
        /// <strong>registrants_confirmation_email</strong> field.</para>
        /// </summary>
        [JsonProperty("registrants_email_notification")]
        public bool EnableRegistrantsEmailNotification { get; set; }

        /// <summary>
        /// Zoom Property: meeting_authentication
        /// <para>Only authenticated users can join meeting if the value of this field is set to <strong>true</strong>.</para>
        /// </summary>
        [JsonProperty("meeting_authentication")]
        public bool EnableMeetingAuthentication { get; set; }

        /// <summary>
        /// Zoom Property: authentication_option
        /// <para>Specify the authentication type for users to join a meeting with <strong>meeting_authentication</strong>
        /// setting set to <strong>true</strong>. The value of this field can be retrieved from the <strong>id</strong> field
        /// can <strong>authentication_options</strong> array in the response of 
        /// <see href="https://marketplace.zoom.us/docs/api-reference/zoom-api/users/usersettings">Get User Settings Api</see>
        /// </para>
        /// </summary>
        public string AuthenticationOption { get; set; }

        /// <summary>
        /// Zoom Property: authentication_domains
        /// <para>Meeting authentication domains. This option, allows you to specify the rule so that Zoom users, 
        /// whose email address contains a certain domain, can join the meeting. You can either provide multiple domains, 
        /// using a comma in between and/or use a wildcard for listing domains.</para>
        /// </summary>
        public string AuthenticationDomains { get; set; }

        /// <summary>
        /// Zoom Property: additional_data_center_regions
        /// <para>Enable additional 
        /// <see href="https://support.zoom.us/hc/en-us/articles/360042411451-Selecting-data-center-regions-for-hosted-meetings-and-webinars">data center regions</see>
        /// for this meeting. Provide the value in the form of array of country code(s) for the countries 
        /// which are available as data center regions in the <see href="https://zoom.us/account/setting">user settings</see>
        /// but have been opt out of in the user settings. For instance, let’s say that in your account settings, 
        /// the data center regions that have been selected are Europe, Honkong, Australia, India, Latin America, Japan, 
        /// China, United States,and Canada. The complete list of available data center regions for your account is: 
        /// [“EU”, “HK”, “AU”, “IN”, “LA”, “TY”, “CN”, “US”, “CA”]. In <see href="https://zoom.us/profile/setting">user settings</see>
        /// , you have opted out of India(IN) and Japan(TY) for meeting and webinar traffic routing. If you would like, 
        /// you can still include India and Japan as additional data centers for this meeting using this field. 
        /// To include India and Japan as additional data center regions, you would provide [“IN”, “TY”] as the value.
        /// </para>
        /// </summary>
        public string[] AdditionalDataCenterRegions { get; set; }
    }
}
