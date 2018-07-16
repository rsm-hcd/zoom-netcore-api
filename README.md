# Zoom NetCore Api

Dotnet Core Package for connecting to [https://zoom.github.io/api/](Zoom's Api). This repository is a work in progress, and does not yet encompass all the methods available in the Zoom Api.

## Installation

Install from the Nuget repository [https://www.nuget.org/packages/AndcultureCode.Zoom.NetCore.Api/]

## Usage

### Pulling all users from the Zoom Api

```
var options = new ZoomClientOptions {
    ZoomApiKey = "Your Api Key",
    ZoomApiSecret = "Your Api Secret"
};
var client = new ZoomClient(options);
var allUsers = client.Users.GetUsers(UserStatuses.Active, 30, 1);
var userEmails = new List<string>();

foreach (var user in allUsers.Users) {
    userEmails.Add(user.Email);
}
```

## Interfaces

### IZoomClient

* `IZoomGroupsClient Groups` - Zoom Groups Client
* `IZoomMeetingsClient Meetings` - Zoom Meetings Client
* `IZoomReportsClient Reports` - Zoom Reports Client
* `IZoomUsersClient Users` - Zoom Users Client
* `IZoomWebhooksClient Webhooks` - Zoom Webhooks Client

### IZoomGroupsClient

* `ListGroups GetUsers()` - List groups under your account. https://zoom.github.io/api/#list-groups
* `Group CreateGroup(CreateGroup createGroup)` - Create a group under your account. https://zoom.github.io/api/#create-a-group
* `Group GetGroup(string groupId)` - Retrieve a group under your account. https://zoom.github.io/api/#retrieve-a-group
* `bool UpdateGroup(string groupId, UpdateGroup group)` - Update a group under your account. https://zoom.github.io/api/#update-a-group
* `bool DeleteGroup(string groupId)` - Delete a group under your account. https://zoom.github.io/api/#delete-a-group
* `ListMembers GetGroupMembers(string groupId, int pageSize = 30, int pageNumber = 1)` - List a group’s members under your account. https://zoom.github.io/api/#list-a-groups-members
* `bool AddGroupMembers(string groupId, List<CreateMember> createMembers)` - Add members to a group under your account. https://zoom.github.io/api/#add-group-members
* `bool DeleteGroupMembers(string groupId, string memberId)` - Delete a member from a group under your account. https://zoom.github.io/api/#delete-a-group-member

### IZoomMeetingsClient

* `ListMeetings GetMeetings(string userId, MeetingListTypes type = MeetingListTypes.Live, int pageSize = 30, int pageNumber = 1)` - List meetings for a user. https://zoom.github.io/api/#list-meetings
* `Meeting CreateMeeting(string userId, Meeting meeting)` - Create a meeting for a user. https://zoom.github.io/api/#create-a-meeting
* `Meeting GetMeeting(string meetingId)` - Retrieve a meeting’s details. https://zoom.github.io/api/#retrieve-a-meeting
* `bool UpdateMeeting(string meetingId, Meeting meeting)` - Update a meeting’s details. https://zoom.github.io/api/#update-a-meeting
* `bool DeleteMeeting(string meetingId, string occurrenceId = null)` - Delete a meeting. https://zoom.github.io/api/#delete-a-meeting
* `bool EndMeeting(string meetingId)` - EndMeeting(string meetingId);
* `ListMeetingRegistrants GetMeetingRegistrants(string meetingId, string status = "approved", string occurrenceId = null, int pageSize = 30, int pageNumber = 1)` - List registrants of a meeting. https://zoom.github.io/api/#list-a-meetings-registrants
* `MeetingRegistrant CreateMeetingRegistrant(string meetingId, CreateMeetingRegistrant meetingRegistrant, string occurrenceIds = null)` - Register a participant for a meeting. https://zoom.github.io/api/#add-a-meeting-registrant
* `bool UpdateMeetingRegistrant(string meetingId, List<MeetingRegistrantUpdate> registrants, string status, string occurrenceId = null)` - Update a meeting registrant’s status. https://zoom.github.io/api/#update-a-meeting-registrants-status

### IZoomReportsClient

* `MeetingParticipantsReport GetMeetingParticipantsReport(string meetingId, int pageSize = 30, string nextPageToken = null)` - Retrieve ended meeting participants report. https://zoom.github.io/api/#retrieve-meeting-participants-report

### IZoomUsersClient

* `ListUsers GetUsers(UserStatuses status = UserStatuses.Active, int pageSize = 30, int pageNumber = 1)` - List users on your account. https://zoom.github.io/api/#list-users
* `User CreateUser(CreateUser createUser, string action)` - Create a new user on your account. https://zoom.github.io/api/#create-a-user
* `User GetUser(string userId, LoginTypes? loginType = null)` - Retrieve a user on your account. https://zoom.github.io/api/#retrieve-a-user
* `bool UpdateUser(string userId, UpdateUser user)` - Update a user on your account. https://zoom.github.io/api/#update-a-user
* `bool CheckUser(string email)` - Check if the user email exists. https://zoom.github.io/api/#check-a-users-email
* `bool DeleteUser(string userId, string action = "disassociate")` - Delete a user on your account. https://zoom.github.io/api/#delete-a-user

### IZoomWebhooksClient

* `ListWebhooks GetWebhooks()` - List webhooks for an account. https://zoom.github.io/api/#list-webhooks
* `Webhook CreateWebhook(CreateWebhook createWebhook)` - Create a webhook for an account. https://zoom.github.io/api/#create-a-webhook
* `Webhook GetWebhook(string webhookId)` - Retrieve a webhook. https://zoom.github.io/api/#retrieve-a-webhook
* `bool UpdateWebhook(string webhookId, UpdateWebhook webhook)` - Update a webhook. https://zoom.github.io/api/#update-a-webhook
* `bool DeleteWebhook(string webhookId)` - Delete a webhook. https://zoom.github.io/api/#delete-a-webhook