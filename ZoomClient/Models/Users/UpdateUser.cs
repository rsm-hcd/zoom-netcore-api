using AndcultureCode.ZoomClient.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Users
{
    public class UpdateUser : ICreatable
    {
        /// <summary>
        /// Zoom property: type
        /// </summary>
        public UserTypes Type { get; set; }

        /// <summary>
        /// Zoom property: first_name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Zoom property: last_name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Zoom property: pmi
        /// </summary>
        [JsonProperty("pmi")]
        public string PersonalMeetingId { get; set; }

        /// <summary>
        /// Zoom property: timezone
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// Zoom property: dept
        /// </summary>
        [JsonProperty("dept")]
        public string Department { get; set; }

        /// <summary>
        /// Zoom property: vanity_name
        /// </summary>
        public string VanityName { get; set; }

        /// <summary>
        /// Zoom property: host_key
        /// </summary>
        public string HostKey { get; set; }

        /// <summary>
        /// Zoom property: cms_user_id
        /// </summary>
        public string CmsUserId { get; set; }


        #region ICreatable Implementation

        public List<string> Validate()
        {
            var results = new List<string>();
            if (!string.IsNullOrWhiteSpace(FirstName) && FirstName.Length > 64)
            {
                results.Add($"{nameof(FirstName)} property max length is {64} characters");
            }
            if (!string.IsNullOrWhiteSpace(LastName) && LastName.Length > 64)
            {
                results.Add($"{nameof(LastName)} property max length is {64} characters");
            }
            if (!string.IsNullOrWhiteSpace(PersonalMeetingId) && PersonalMeetingId.Length != 10)
            {
                results.Add($"{nameof(PersonalMeetingId)} property length must equal {10} characters");
            }
            if (!string.IsNullOrWhiteSpace(HostKey) && HostKey.Length != 6)
            {
                results.Add($"{nameof(HostKey)} property length must equal {6} characters");
            }

            return results;
        }

        #endregion
    }
}
