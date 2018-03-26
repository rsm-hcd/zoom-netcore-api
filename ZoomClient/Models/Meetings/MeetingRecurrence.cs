using RestSharp.Deserializers;
using RestSharp.Serializers;
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
        [DeserializeAs(Name = "weekly_days")]
        [SerializeAs(Name = "weekly_days")]
        string WeeklyDaysList { get; set; }

        /// <summary>
        /// Zoom property: type
        /// </summary>
        [DeserializeAs(Name = "type")]
        [SerializeAs(Name = "type")]
        public MeetingRecurrenceTypes Type { get; set; }

        /// <summary>
        /// Zoom property: repeat_interval
        /// </summary>
        [DeserializeAs(Name = "repeat_interval")]
        [SerializeAs(Name = "repeat_interval")]
        public int RepeatInterval { get; set; }

        /// <summary>
        /// Zoom property: monthly_day
        /// </summary>
        [DeserializeAs(Name = "monthly_day")]
        [SerializeAs(Name = "monthly_day")]
        public int MonthlyDay { get; set; }

        /// <summary>
        /// Zoom property: monthly_week
        /// </summary>
        [DeserializeAs(Name = "monthly_week")]
        [SerializeAs(Name = "monthly_week")]
        public MeetingRecurrenceWeeks MonthlyWeek { get; set; }

        /// <summary>
        /// Zoom property: monthly_week_day
        /// </summary>
        [DeserializeAs(Name = "monthly_week_day")]
        [SerializeAs(Name = "monthly_week_day")]
        public MeetingRecurrenceWeekDays MonthlyWeekDay { get; set; }

        /// <summary>
        /// Zoom property: end_times
        /// </summary>
        [DeserializeAs(Name = "end_times")]
        [SerializeAs(Name = "end_times")]
        public int EndTimes { get; set; }

        /// <summary>
        /// Zoom property: end_date_time
        /// </summary>
        [DeserializeAs(Name = "end_date_time")]
        [SerializeAs(Name = "end_date_time")]
        public DateTimeOffset? EndDateTime { get; set; }

        /// <summary>
        /// Zoom property: weekly_days
        /// </summary>
        public List<MeetingRecurrenceWeekDays> WeeklyDays
        {
            get
            {
                return WeeklyDaysList.Split(',').Select(e => (MeetingRecurrenceWeekDays)Enum.Parse(typeof(MeetingRecurrenceWeekDays), e)).ToList();
            }
            set
            {
                WeeklyDaysList = string.Join(",", value);
            }
        }
    }
}
