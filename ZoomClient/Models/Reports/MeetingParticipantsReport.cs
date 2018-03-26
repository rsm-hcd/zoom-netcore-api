using RestSharp.Deserializers;
using RestSharp.Serializers;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Reports
{
    public class MeetingParticipantsReport : BaseTokenList
    {
        /// <summary>
        /// Zoom Property: participants
        /// </summary>
        [DeserializeAs(Name = "participants")]
        [SerializeAs(Name = "participants")]
        public List<MeetingParticipant> Participants { get; set; }
    }
}
