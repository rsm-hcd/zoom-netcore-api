using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndcultureCode.ZoomClient.Models.Webinars
{
    public class WebinarSettings
    {
        /// <summary>
        /// Zoom Property: Start video when host joins webinar.
        /// </summary>
        [JsonProperty("host_video")]
        public bool EnableHostVideo { get; set; }

        /// <summary>
        /// Zoom Property: Start video when panelists join webinar.
        /// </summary>
        [JsonProperty("panelists_video")]
        public bool EnablePanelistVideo { get; set; }

        /// <summary>
        /// Zoom Property: Enable practice session.
        /// </summary>
        [JsonProperty("practice_session")]
        public bool EnablePracticeSession { get; set; }

        /// <summary>
        /// Zoom Property: Default to HD video.
        /// </summary>
        [JsonProperty("hd_video")]
        public bool EnableHdVideo { get; set; }

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
        [JsonProperty("approval_type")]
        public WebinarApprovalTypes ApprovalType { get; set; }

        /// <summary>
        /// Zoom Property: Registration types. Only used for recurring webinars with a fixed time..
        /// </summary>
        [JsonProperty("registration_type")]
        public WebinarRegistrationTypes RegistrationType { get; set; }

        /// <summary>
        /// Zoom Property: audio
        /// </summary>
        [JsonProperty("audio")]
        public string Audio { get; set; }

        /// <summary>
        /// Zoom Property: auto_recording
        /// </summary>
        [JsonProperty("auto_recording")]
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
        [JsonProperty("alternative_hosts")]
        public string AlternativeHosts { get; set; }

        /// <summary>
        /// Zoom Property: close_registration, Close registration after event date.
        /// </summary>
        [JsonProperty("close_registration")]
        public bool EnableCloseRegistration { get; set; }

        /// <summary>
        /// Zoom Property: show_share_button, Show social share buttons on the registration page.
        /// </summary>
        [JsonProperty("show_share_button")]
        public bool ShowShareButton { get; set; }

        /// <summary>
        /// Zoom Property: allow_multiple_devices, Allow attendees to join from multiple devices.
        /// </summary>
        [JsonProperty("allow_multiple_devices")]
        public bool AllowMultipleDevices { get; set; }

        /// <summary>
        /// Zoom Property: on_demand, Make the webinar on-demand.
        /// </summary>
        [JsonProperty("on_demand")]
        public bool OnDemand { get; set; }

        /// <summary>
        /// Zoom Property: global_dial_in_countries, List of global dial-in countries.
        /// </summary>
        [JsonProperty("global_dial_in_countries")]
        public string[] GlobalDialInCountries { get; set; }

        /// <summary>
        /// Zoom Property: contact_name, Contact name for registration
        /// </summary>
        [JsonProperty("contact_name")]
        public string ContactName { get; set; }

        /// <summary>
        /// Zoom Property: contact_email, Contact email for registration
        /// </summary>
        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }


        /// <summary>
        /// Zoom Property: registrants_restrict_number, Restrict number of registrants for a webinar. By default, it is set to 
        /// default: 0
        /// minimum: 0
        /// maximum: 20000
        /// </summary>
        [JsonProperty("registrants_restrict_number")]
        public int RegistrantsRestrictNumber { get; set; }


        /// <summary>
        /// Zoom Property: post_webinar_survey, Zoom will open a survey page in attendees’ browsers after leaving the webinar 
        /// </summary>
        [JsonProperty("post_webinar_survey")]
        public bool PostWebinarSurvey { get; set; }

        /// <summary>
        /// Zoom Property: survey_url, Survey url for post webinar survey 
        /// </summary>
        [JsonProperty("survey_url")]
        public string SurveyUrl { get; set; }


        /// <summary>
        /// Zoom Property: registrants_email_notification, Send email notifications to registrants about approval, cancellation, denial of the registration. The value of this field must be set to true in order to use the  registrants_confirmation_email field
        /// </summary>
        [JsonProperty("registrants_email_notification")]
        public bool RegistrantsEmailNotification { get; set; }


        /// <summary>
        /// Zoom Property: meeting_authentication, Only authenticated  users can join meeting if the value of this field is set to  true
        /// </summary>
        [JsonProperty("meeting_authentication")]
        public bool MeetingAuthentication { get; set; }


        /// <summary>
        /// Zoom Property: authentication_option, Specify the authentication type for users to join a Webinar with meeting_authentication  setting set to true. The value of this field can be retrieved from the id field  within authentication_options array in the response of Get User Setting API
        /// </summary>
        [JsonProperty("authentication_option")]
        public string AuthenticationOption { get; set; }

        /// <summary>
        /// Zoom Property: authentication_domains, Meeting authentication domains. This option, allows you to specify the rule so that Zoom users, whose email address contains a certain domain, can join the Webinar. You can either provide multiple domains, using a comma in between and/or use a wildcard for listing domains.
        /// </summary>
        [JsonProperty("authentication_domains")]
        public string AuthenticationDomains { get; set; }
    }
}
