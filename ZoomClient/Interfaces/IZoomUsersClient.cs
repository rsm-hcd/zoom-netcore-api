using AndcultureCode.ZoomClient.Models.Meetings;
using AndcultureCode.ZoomClient.Models.Reports;
using AndcultureCode.ZoomClient.Models.Users;
using System.Collections.Generic;

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
        /// Delete a user on your account. https://zoom.github.io/api/#delete-a-user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        bool DeleteUser(string userId, string action = "disassociate");
    }
}
