using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Groups
{
    public class ListMembers : BaseList
    {
        /// <summary>
        /// Zoom property: members
        /// </summary>
        public List<Member> Members { get; set; }
    }
}
