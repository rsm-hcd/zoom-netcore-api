
namespace AndcultureCode.ZoomClient.Models.Meetings
{
    public class MeetingGlobalDialInNumber
    {
        /// <summary>
        /// Zoom Property: country
        /// <para>Country code. For example, BR.</para>
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Zoom Property: country_name
        /// <para>Full name of country. For example, Brazil.</para>
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Zoom Property: city
        /// <para>City of the number, if any. For example, Chicago.</para>
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Zoom Property: number
        /// <para>Phone number. For example, +1 2332357613.</para>
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Zoom Property: type
        /// <para>Type of number. Allowed values: toll, tollfree.</para>
        /// </summary>
        public string Type { get; set; }
    }
}
