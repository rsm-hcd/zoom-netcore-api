namespace AndcultureCode.ZoomClient.Models.Groups
{
    public class Group : BaseObject
    {
        /// <summary>
        /// Zoom Property: name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Zoom Property: total_members
        /// </summary>
        public int TotalMembers { get; set; }
    }
}
