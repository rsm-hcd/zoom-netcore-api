using AndcultureCode.ZoomClient.Extensions;
using AndcultureCode.ZoomClient.Interfaces;
using AndcultureCode.ZoomClient.Models;
using AndcultureCode.ZoomClient.Models.Groups;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient
{
    class ZoomGroupsClient : IZoomGroupsClient
    {
        #region Constants

        const string DELETE_GROUP        = "groups/{groupId}";
        const string DELETE_GROUP_MEMBER = "groups/{groupId}/members/{memberId}";

        const string GET_LIST_GROUPS   = "groups";
        const string GET_GROUP         = "groups/{groupId}";
        const string GET_GROUP_MEMBERS = "groups/{groupId}/members";

        const string PATCH_GROUP = "groups/{groupId}";

        const string POST_GROUP         = "groups";
        const string POST_GROUP_MEMBERS = "groups/{groupId}/members";

        #endregion

        #region Properties

        ZoomClientOptions Options { get; set; }
        RestClient WebClient { get; set; }

        #endregion

        #region Constructor

        internal ZoomGroupsClient(ZoomClientOptions options, RestClient webClient)
        {
            Options = options;
            WebClient = webClient;
        }

        #endregion

        #region IZoomGroupsClient Implementation

        public ListGroups GetGroups()
        {
            var request = BuildRequestAuthorization(GET_LIST_GROUPS, Method.GET);

            var response = WebClient.Execute<ListGroups>(request);

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

        public Group CreateGroup(CreateGroup createGroup)
        {
            var request = BuildRequestAuthorization(POST_GROUP, Method.POST);
            request.AddJsonBody(createGroup);

            var response = WebClient.Execute<Group>(request);

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

        public Group GetGroup(string groupId)
        {
            var request = BuildRequestAuthorization(GET_GROUP, Method.GET);
            request.AddParameter("groupId", groupId, ParameterType.UrlSegment);

            var response = WebClient.Execute<Group>(request);

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

        public bool UpdateGroup(string groupId, UpdateGroup group)
        {
            var request = BuildRequestAuthorization(PATCH_GROUP, Method.PATCH);
            request.AddParameter("groupId", groupId, ParameterType.UrlSegment);
            request.AddJsonBody(group);

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

        public bool DeleteGroup(string groupId)
        {
            var request = BuildRequestAuthorization(DELETE_GROUP, Method.DELETE);
            request.AddParameter("groupId", groupId, ParameterType.UrlSegment);

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

        public ListMembers GetGroupMembers(string groupId, int pageSize = 30, int pageNumber = 1)
        {
            var request = BuildRequestAuthorization(GET_GROUP_MEMBERS, Method.GET);
            request.AddParameter("groupId", groupId, ParameterType.UrlSegment);
            request.AddParameter("page_size", pageSize, ParameterType.QueryString);
            request.AddParameter("page_number", pageNumber, ParameterType.QueryString);

            var response = WebClient.Execute<ListMembers>(request);

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

        public bool AddGroupMembers(string groupId, List<CreateMember> createMembers)
        {
            var request = BuildRequestAuthorization(POST_GROUP_MEMBERS, Method.POST);
            request.AddParameter("groupId", groupId, ParameterType.UrlSegment);

            request.AddJsonBody(new { members = createMembers });

            var response = WebClient.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Completed && response.StatusCode == System.Net.HttpStatusCode.Created)
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

        public bool DeleteGroupMembers(string groupId, string memberId)
        {
            var request = BuildRequestAuthorization(DELETE_GROUP_MEMBER, Method.DELETE);
            request.AddParameter("groupId", groupId, ParameterType.UrlSegment);
            request.AddParameter("memberId", memberId, ParameterType.UrlSegment);

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
