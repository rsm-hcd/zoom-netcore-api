using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class MeetingRegistrant
    {
        /// <summary>
        /// Zoom property: id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Zoom property: email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Zoom property: first_name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Zoom property: last_name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Zoom property: address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Zoom property: city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Zoom property: country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Zoom property: zip
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Zoom property: state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Zoom property: phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Zoom property: industry
        /// </summary>
        public string Industry { get; set; }

        /// <summary>
        /// Zoom property: org
        /// </summary>
        [JsonProperty("org")]
        public string Organization { get; set; }

        /// <summary>
        /// Zoom property: job_title
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Zoom property: purchasing_time_frame
        /// </summary>
        public string PurchasingTimeFrame { get; set; }

        /// <summary>
        /// Zoom property: role_in_purchase_process
        /// </summary>
        public string RoleInPurchaseProcess { get; set; }

        /// <summary>
        /// Zoom property: no_of_employees
        /// </summary>
        [JsonProperty("no_of_employees")]
        public string NumberOfEmployees { get; set; }

        /// <summary>
        /// Zoom property: comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Zoom property: status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Zoom property: create_time
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Zoom property: join_url
        /// </summary>
        public string JoinUrl { get; set; }

        /// <summary>
        /// Zoom property: custom_questions
        /// </summary>
        public List<MeetingRegistrantCustomQuestion> CustomQuestions { get; set; }
    }
}
