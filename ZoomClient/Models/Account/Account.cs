namespace AndcultureCode.ZoomClient.Models.Account
{
    public class Account : BaseObject
    {
        /// <summary>
        /// Zoom property: first_name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Zoom property: last_name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Zoom property: email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Zoom property: password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Zoom property: options
        /// </summary>
        public AccountOptions Options { get; set; }
    }
}
