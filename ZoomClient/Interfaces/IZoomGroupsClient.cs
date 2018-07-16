using AndcultureCode.ZoomClient.Models.Groups;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Interfaces
{
    public interface IZoomGroupsClient
    {
        /// <summary>
        /// List groups under your account. https://zoom.github.io/api/#list-groups
        /// </summary>
        /// <returns></returns>
        ListGroups GetGroups();

        /// <summary>
        /// Create a group under your account. https://zoom.github.io/api/#create-a-group
        /// </summary>
        /// <param name="createGroup"></param>
        /// <returns></returns>
        Group CreateGroup(CreateGroup createGroup);

        /// <summary>
        /// Retrieve a group under your account. https://zoom.github.io/api/#retrieve-a-group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        Group GetGroup(string groupId);

        /// <summary>
        /// Update a group under your account. https://zoom.github.io/api/#update-a-group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        bool UpdateGroup(string groupId, UpdateGroup group);

        /// <summary>
        /// Delete a group under your account. https://zoom.github.io/api/#delete-a-group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        bool DeleteGroup(string groupId);

        /// <summary>
        /// List a group’s members under your account. https://zoom.github.io/api/#list-a-groups-members
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        ListMembers GetGroupMembers(string groupId, int pageSize = 30, int pageNumber = 1);

        /// <summary>
        /// Add members to a group under your account. https://zoom.github.io/api/#add-group-members
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        bool AddGroupMembers(string groupId, List<CreateMember> createMembers);

        /// <summary>
        /// Delete a member from a group under your account. https://zoom.github.io/api/#delete-a-group-member
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        bool DeleteGroupMembers(string groupId, string memberId);
    }
}
