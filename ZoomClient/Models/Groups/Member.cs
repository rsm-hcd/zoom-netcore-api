using AndcultureCode.ZoomClient.Models.Users;

namespace AndcultureCode.ZoomClient.Models.Groups
{
    public class Member : BaseObject
    {
        /// <summary>
        /// Zoom property: email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Zoom property: first_name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Zoom property: last_name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Zoom property: type
        /// </summary>
        public UserTypes Type { get; set; }
    }
}
