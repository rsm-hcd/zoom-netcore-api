using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndcultureCode.ZoomClient.Models.Webinars
{
    public class WebinarRecurrence
    {
        /// <summary>
        /// Private property to wrap the list of weekly days in a single string for comma separation when serializing/deserializing for http requests
        /// </summary>
        [JsonProperty("weekly_days")]
        string WeeklyDaysList { get; set; }

        /// <summary>
        /// Zoom property: type
        /// </summary>
        public WebinarRecurrenceTypes Type { get; set; }

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
        public WebinarRecurrenceWeeks MonthlyWeek { get; set; }

        /// <summary>
        /// Zoom property: monthly_week_day
        /// </summary>
        public WebinarRecurrenceWeekDays MonthlyWeekDay { get; set; }

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
        public List<WebinarRecurrenceWeekDays> WeeklyDays
        {
            get
            {
                if (string.IsNullOrWhiteSpace(WeeklyDaysList))
                {
                    return null;
                }
                return WeeklyDaysList.Split(',').Select(e => (WebinarRecurrenceWeekDays)Enum.Parse(typeof(WebinarRecurrenceWeekDays), e))?.ToList();
            }
            set
            {
                WeeklyDaysList = string.Join(",", value.ToString());
            }
        }
    }
}
