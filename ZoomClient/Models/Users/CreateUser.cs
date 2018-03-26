using AndcultureCode.ZoomClient.Interfaces;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models.Users
{
    public class CreateUser : ICreatable
    {
        /// <summary>
        /// Zoom property: action
        /// </summary>
        [DeserializeAs(Name = "action")]
        [SerializeAs(Name = "action")]
        public string Action { get; set; }

        /// <summary>
        /// Zoom property: email
        /// </summary>
        [DeserializeAs(Name = "email")]
        [SerializeAs(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Zoom property: type
        /// </summary>
        [DeserializeAs(Name = "type")]
        [SerializeAs(Name = "type")]
        public UserTypes Type { get; set; }

        /// <summary>
        /// Zoom property: first_name
        /// </summary>
        [DeserializeAs(Name = "first_name")]
        [SerializeAs(Name = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Zoom property: last_name
        /// </summary>
        [DeserializeAs(Name = "last_name")]
        [SerializeAs(Name = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Zoom property: password
        /// </summary>
        [DeserializeAs(Name = "password")]
        [SerializeAs(Name = "password")]
        public string Password { get; set; }

        #region ICreatable Implementation

        public List<string> Validate()
        {
            var results = new List<string>();
            if (string.IsNullOrWhiteSpace(Action))
            {
                results.Add($"{nameof(Action)} property is required for creating user");
            } else if (!Action.Equals(CreateUserAction.AutoCreate, StringComparison.InvariantCultureIgnoreCase) ||
                !Action.Equals(CreateUserAction.Create, StringComparison.InvariantCultureIgnoreCase) ||
                !Action.Equals(CreateUserAction.CustCreate, StringComparison.InvariantCultureIgnoreCase) ||
                !Action.Equals(CreateUserAction.SsoCreate, StringComparison.InvariantCultureIgnoreCase))
            {
                results.Add($"{nameof(Action)} property has invalid value. Only allowed values are: [{CreateUserAction.AutoCreate},{CreateUserAction.Create},{CreateUserAction.CustCreate},{CreateUserAction.SsoCreate}]");
            }
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
            if (string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Action) && Action.Equals(CreateUserAction.AutoCreate, StringComparison.InvariantCultureIgnoreCase))
            {
                results.Add($"{nameof(Password)} property is required for creating user when action is set to {CreateUserAction.AutoCreate}");
            }

            return results;
        }

        #endregion
    }
}
