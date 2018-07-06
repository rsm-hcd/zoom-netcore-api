using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class MeetingRecurrence
    {
        /// <summary>
        /// Private property to wrap the list of weekly days in a single string for comma separation when serializing/deserializing for http requests
        /// </summary>
        [JsonProperty("weekly_days")]
        string WeeklyDaysList { get; set; }

        /// <summary>
        /// Zoom property: type
        /// </summary>
        public MeetingRecurrenceTypes Type { get; set; }

        /// <summary>
        /// Zoom property: repeat_interval
        /// </summary>
        public int RepeatInterval { get; set; }

        /// <summary>
        /// Zoom property: monthly_day
        /// </summary>
        public int MonthlyDay { get; set; }

        /// <summary>
        /// Zoom property: monthly_week
        /// </summary>
        public MeetingRecurrenceWeeks MonthlyWeek { get; set; }

        /// <summary>
        /// Zoom property: monthly_week_day
        /// </summary>
        public MeetingRecurrenceWeekDays MonthlyWeekDay { get; set; }

        /// <summary>
        /// Zoom property: end_times
        /// </summary>
        public int EndTimes { get; set; }

        /// <summary>
        /// Zoom property: end_date_time
        /// </summary>
        public DateTimeOffset? EndDateTime { get; set; }

        /// <summary>
        /// Zoom property: weekly_days
        /// </summary>
        [JsonIgnore]
        public List<MeetingRecurrenceWeekDays> WeeklyDays
        {
            get
            {
                if (string.IsNullOrWhiteSpace(WeeklyDaysList))
                {
                    return null;
                }
                return WeeklyDaysList.Split(',').Select(e => (MeetingRecurrenceWeekDays)Enum.Parse(typeof(MeetingRecurrenceWeekDays), e))?.ToList();
            }
            set
            {
                WeeklyDaysList = string.Join(",", value.ToString());
            }
        }
    }
}
