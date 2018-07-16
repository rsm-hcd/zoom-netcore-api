using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Groups
{
    public class ListGroups
    {
        /// <summary>
        /// Zoom Property: total_records
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Zoom property: groups
        /// </summary>
        public List<Group> Groups { get; set; }
    }
}
