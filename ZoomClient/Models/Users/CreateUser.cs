using AndcultureCode.ZoomClient.Interfaces;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Users
{
    public class CreateUser : ICreatable
    {
        /// <summary>
        /// Zoom property: email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Zoom property: type
        /// </summary>
        public UserTypes Type { get; set; }

        /// <summary>
        /// Zoom property: first_name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Zoom property: last_name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Zoom property: password
        /// </summary>
        public string Password { get; set; }

        #region ICreatable Implementation

        public List<string> Validate()
        {
            var results = new List<string>();
            if (string.IsNullOrWhiteSpace(Email))
            {
                results.Add($"{nameof(Email)} property is required for creating user");
            }
            if (!string.IsNullOrWhiteSpace(FirstName) && FirstName.Length > 64)
            {
                results.Add($"{nameof(FirstName)} property max length is {64} characters");
            }
            if (!string.IsNullOrWhiteSpace(LastName) && LastName.Length > 64)
            {
                results.Add($"{nameof(LastName)} property max length is {64} characters");
            }

            return results;
        }

        #endregion
    }
}
