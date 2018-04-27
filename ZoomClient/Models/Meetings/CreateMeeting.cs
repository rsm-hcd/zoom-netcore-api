using AndcultureCode.ZoomClient.Interfaces;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class CreateMeeting : Meeting, ICreatable
    {
        #region ICreatable Implementation

        public List<string> Validate()
        {
            var results = new List<string>();

            if (Recurrence != null)
            {
                if (Recurrence.RepeatInterval > 0)
                {
                    if (Recurrence.Type == MeetingRecurrenceTypes.Daily && Recurrence.RepeatInterval > 90)
                    {
                        results.Add($"{nameof(Recurrence.RepeatInterval)} cannot exceed {90} when Type = {Type}");
                    }
                    else if (Recurrence.Type == MeetingRecurrenceTypes.Weekly && Recurrence.RepeatInterval > 12)
                    {
                        results.Add($"{nameof(Recurrence.RepeatInterval)} cannot exceed {12} when Type = {Type}");
                    }
                    else if (Recurrence.Type == MeetingRecurrenceTypes.Monthly && Recurrence.RepeatInterval > 3)
                    {
                        results.Add($"{nameof(Recurrence.RepeatInterval)} cannot exceed {3} when Type = {Type}");
                    }
                }
            }

            return results;
        }

        #endregion
    }
}
