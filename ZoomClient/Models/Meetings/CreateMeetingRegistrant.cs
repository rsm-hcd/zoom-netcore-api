using AndcultureCode.ZoomClient.Interfaces;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class CreateMeetingRegistrant : MeetingRegistrant, ICreatable
    {
        #region ICreatable Implementation

        public List<string> Validate()
        {
            var results = new List<string>();

            return results;
        }

        #endregion
    }
}
