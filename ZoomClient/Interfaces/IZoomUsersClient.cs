using AndcultureCode.ZoomClient.Models.Users;

namespace AndcultureCode.ZoomClient.Interfaces
{
    public interface IZoomUsersClient
    {
        /// <summary>
        /// List users on your account. https://zoom.github.io/api/#list-users
        /// </summary>
        /// <returns></returns>
        ListUsers GetUsers(UserStatuses status = UserStatuses.Active, int pageSize = 30, int pageNumber = 1);

        /// <summary>
        /// Create a new user on your account. https://zoom.github.io/api/#create-a-user
        /// </summary>
        /// <param name="createUser"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        User CreateUser(CreateUser createUser, string action);

        /// <summary>
        /// Retrieve a user on your account. https://zoom.github.io/api/#retrieve-a-user
        /// </summary>
        /// <returns></returns>
        User GetUser(string userId, LoginTypes? loginType = null);

        /// <summary>
        /// Update a user on your account. https://zoom.github.io/api/#update-a-user
        /// </summary>
        /// <returns></returns>
        bool UpdateUser(string userId, UpdateUser user);

        /// <summary>
        /// Check if the user email exists. https://zoom.github.io/api/#check-a-users-email
        /// </summary>
        /// <returns></returns>
        bool CheckUser(string email);

        /// <summary>
        /// Delete a user on your account. https://zoom.github.io/api/#delete-a-user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="action"></param>
        /// <param name="transferEmail"></param>
        /// <param name="transferMeeting"></param>
        /// <param name="transferWebinar"></param>
        /// <param name="transferRecording"></param>
        /// <returns></returns>
        bool DeleteUser(string userId, string action = "disassociate", string transferEmail = null, bool transferMeeting = false, bool transferWebinar = false, bool transferRecording = false);

        /// <summary>
        /// Update a user's email to a new address
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newEmail"></param>
        /// <returns></returns>
        bool UpdateUserEmail(string userId, string newEmail);
    }
}
