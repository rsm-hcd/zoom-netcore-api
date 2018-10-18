using AndcultureCode.ZoomClient.Interfaces;
using AndcultureCode.ZoomClient.Models.Users;
using RestSharp;
using System;
using AndcultureCode.ZoomClient.Models;
using AndcultureCode.ZoomClient.Extensions;

namespace AndcultureCode.ZoomClient
{
    public class ZoomUsersClient : IZoomUsersClient
    {
        #region Constants

        const string DELETE_USER = "users/{userId}";

        const string GET_LIST_USERS = "users";
        const string GET_USER       = "users/{userId}";
        const string GET_USER_EMAIL = "users/email";

        const string PATCH_USER = "users/{userId}";

        const string POST_CREATE_USER = "users";

        const string PUT_UPDATE_USER_EMAIL = "users/{userId}/email";

        #endregion

        #region Properties

        ZoomClientOptions Options { get; set; }
        RestClient WebClient { get; set; }

        #endregion

        #region Constructor

        internal ZoomUsersClient(ZoomClientOptions options, RestClient webClient)
        {
            Options = options;
            WebClient = webClient;
        }

        #endregion

        #region IZoomUsersClient Implementation

        public ListUsers GetUsers(UserStatuses status = UserStatuses.Active, int pageSize = 30, int pageNumber = 1)
        {
            if (pageSize > 300)
            {
                throw new Exception("GetUsers page size max 300");
            }

            var request = BuildRequestAuthorization(GET_LIST_USERS, Method.GET);
            request.AddParameter("status", status.ToString().ToLowerInvariant(), ParameterType.QueryString);
            request.AddParameter("page_size", pageSize, ParameterType.QueryString);
            request.AddParameter("page_number", pageNumber, ParameterType.QueryString);

            var response = WebClient.Execute<ListUsers>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return null;
        }
        public User CreateUser(CreateUser createUser, string action)
        {
            var validateResult = createUser.Validate();
            if (validateResult.Count > 0)
            {
                throw new Exception($"CreateUser request does not pass validation. {string.Join(" :: ", validateResult)}");
            }

            if (!action.Equals(CreateUserAction.Create, StringComparison.InvariantCultureIgnoreCase) &&
                !action.Equals(CreateUserAction.AutoCreate, StringComparison.InvariantCultureIgnoreCase) &&
                !action.Equals(CreateUserAction.CustCreate, StringComparison.InvariantCultureIgnoreCase) &&
                !action.Equals(CreateUserAction.SsoCreate, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"CreateUser action allowed values are [{CreateUserAction.Create},{CreateUserAction.AutoCreate},{CreateUserAction.CustCreate},{CreateUserAction.SsoCreate}]");
            }

            if (string.IsNullOrWhiteSpace(createUser.Password) && !string.IsNullOrWhiteSpace(action) && action.Equals(CreateUserAction.AutoCreate, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"{nameof(createUser.Password)} property is required for creating user when action is set to {CreateUserAction.AutoCreate}");
            }

            var request = BuildRequestAuthorization(POST_CREATE_USER, Method.POST);
            request.AddJsonBody(new { action, user_info = createUser });

            var response = WebClient.Execute<User>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return response.Data;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return null;
        }

        public User GetUser(string userId, LoginTypes? loginType)
        {
            var request = BuildRequestAuthorization(GET_USER, Method.GET);
            request.AddParameter("userId", userId, ParameterType.UrlSegment);

            var response = WebClient.Execute<User>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return null;
        }

        public bool UpdateUser(string userId, UpdateUser user)
        {
            var request = BuildRequestAuthorization(PATCH_USER, Method.PATCH);
            request.AddParameter("userId", userId, ParameterType.UrlSegment);
            request.AddJsonBody(user);

            var response = WebClient.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return false;
        }

        public bool CheckUser(string email)
        {
            var request = BuildRequestAuthorization(GET_USER_EMAIL, Method.GET);
            request.AddParameter("email", email, ParameterType.QueryString);

            var response = WebClient.Execute<CheckUserEmail>(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data.EmailExists;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return false;
        }

        public bool DeleteUser(string userId, string action = "disassociate", string transferEmail = null, bool transferMeeting = false, bool transferWebinar = false, bool transferRecording = false)
        {
            if (!action.Equals(DeleteUserAction.Disassociate, StringComparison.InvariantCultureIgnoreCase) &&
                !action.Equals(DeleteUserAction.Delete, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"DeleteUser action allowed values are [{DeleteUserAction.Disassociate},{DeleteUserAction.Delete}]");
            }

            var request = BuildRequestAuthorization(DELETE_USER, Method.DELETE);
            request.AddParameter("userId", userId, ParameterType.UrlSegment);

            if (!string.IsNullOrWhiteSpace(transferEmail))
            {
                request.AddParameter("transfer_email", transferEmail, ParameterType.QueryString);
                request.AddParameter("transfer_meeting", transferMeeting, ParameterType.QueryString);
                request.AddParameter("transfer_webinar", transferWebinar, ParameterType.QueryString);
                request.AddParameter("transfer_recording", transferRecording, ParameterType.QueryString);
            }

            var response = WebClient.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return false;
        }

        public bool UpdateUserEmail(string userId, string newEmail)
        {
            var user = new UpdateUserEmail
            {
                Email = newEmail
            };
            var request = BuildRequestAuthorization(PUT_UPDATE_USER_EMAIL, Method.PUT);
            request.AddParameter("userId", userId, ParameterType.UrlSegment);
            request.AddJsonBody(user);

            var response = WebClient.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception(response.ErrorMessage);
            }

            if (!string.IsNullOrWhiteSpace(response.StatusDescription) && !string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception($"{response.StatusDescription} || {response.Content}");
            }

            return false;
        }

        #endregion

        #region Private Methods

        RestRequest BuildRequestAuthorization(string resource, Method method)
        {
            return WebClient.BuildRequestAuthorization(Options, resource, method);
        }

        #endregion
    }
}
