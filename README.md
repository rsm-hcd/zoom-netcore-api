# Zoom NetCore Api

Dotnet Core Package for connecting to Zoom's Api [https://marketplace.zoom.us/docs/api-reference/zoom-api/]. This repository is a work in progress, and does not yet encompass all the methods available in the Zoom Api.

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

### API Key

You must generate a JWT App (does not currently work with OAuth generated Apps).

https://marketplace.zoom.us/docs/guides/build/jwt-app

## Interfaces

### IZoomClient

* `IZoomGroupsClient Groups` - Zoom Groups Client
* `IZoomMeetingsClient Meetings` - Zoom Meetings Client
* `IZoomReportsClient Reports` - Zoom Reports Client
* `IZoomUsersClient Users` - Zoom Users Client
* `IZoomWebhooksClient Webhooks` - Zoom Webhooks Client

### IZoomGroupsClient

* `ListGroups GetUsers()` - List groups under your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/groups/groups
* `Group CreateGroup(CreateGroup createGroup)` - Create a group under your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/groups/groupcreate
* `Group GetGroup(string groupId)` - Retrieve a group under your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/groups/group
* `bool UpdateGroup(string groupId, UpdateGroup group)` - Update a group under your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/groups/groupupdate
* `bool DeleteGroup(string groupId)` - Delete a group under your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/groups/groupdelete
* `ListMembers GetGroupMembers(string groupId, int pageSize = 30, int pageNumber = 1)` - List a group’s members under your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/groups/groupmembers
* `bool AddGroupMembers(string groupId, List<CreateMember> createMembers)` - Add members to a group under your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/groups/groupmemberscreate
* `bool DeleteGroupMembers(string groupId, string memberId)` - Delete a member from a group under your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/groups/groupmembersdelete

### IZoomMeetingsClient

* `ListMeetings GetMeetings(string userId, MeetingListTypes type = MeetingListTypes.Live, int pageSize = 30, int pageNumber = 1)` - List meetings for a user. https://marketplace.zoom.us/docs/api-reference/zoom-api/meetings/meetings
* `Meeting CreateMeeting(string userId, Meeting meeting)` - Create a meeting for a user. https://marketplace.zoom.us/docs/api-reference/zoom-api/meetings/meetingcreate
* `Meeting GetMeeting(string meetingId)` - Retrieve a meeting’s details. https://marketplace.zoom.us/docs/api-reference/zoom-api/meetings/meeting
* `bool UpdateMeeting(string meetingId, Meeting meeting)` - Update a meeting’s details. https://marketplace.zoom.us/docs/api-reference/zoom-api/meetings/meetingupdate
* `bool DeleteMeeting(string meetingId, string occurrenceId = null)` - Delete a meeting. https://marketplace.zoom.us/docs/api-reference/zoom-api/meetings/meetingdelete
* `bool EndMeeting(string meetingId)` - EndMeeting(string meetingId) - End a meeting. https://marketplace.zoom.us/docs/api-reference/zoom-api/meetings/meetingstatus
* `ListMeetingRegistrants GetMeetingRegistrants(string meetingId, string status = "approved", string occurrenceId = null, int pageSize = 30, int pageNumber = 1)` - List registrants of a meeting. https://marketplace.zoom.us/docs/api-reference/zoom-api/meetings/meetingregistrants
* `MeetingRegistrant CreateMeetingRegistrant(string meetingId, CreateMeetingRegistrant meetingRegistrant, string occurrenceIds = null)` - Register a participant for a meeting. https://marketplace.zoom.us/docs/api-reference/zoom-api/meetings/meetingregistrantcreate
* `bool UpdateMeetingRegistrant(string meetingId, List<MeetingRegistrantUpdate> registrants, string status, string occurrenceId = null)` - Update a meeting registrant’s status. https://marketplace.zoom.us/docs/api-reference/zoom-api/meetings/meetingregistrantstatus

### IZoomReportsClient

* `MeetingParticipantsReport GetMeetingParticipantsReport(string meetingId, int pageSize = 30, string nextPageToken = null)` - Retrieve ended meeting participants report. https://marketplace.zoom.us/docs/api-reference/zoom-api/reports/reportmeetingparticipants

### IZoomUsersClient

* `ListUsers GetUsers(UserStatuses status = UserStatuses.Active, int pageSize = 30, int pageNumber = 1)` - List users on your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/users/users
* `User CreateUser(CreateUser createUser, string action)` - Create a new user on your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/users/usercreate
* `User GetUser(string userId, LoginTypes? loginType = null)` - Retrieve a user on your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/users/user
* `bool UpdateUser(string userId, UpdateUser user)` - Update a user on your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/users/userupdate
* `bool CheckUser(string email)` - Check if the user email exists. https://marketplace.zoom.us/docs/api-reference/zoom-api/users/useremail
* `bool DeleteUser(string userId, string action = "disassociate", string transferEmail = null, bool transferMeeting = false, bool transferWebinar = false, bool transferRecording = false)` - Delete a user on your account. https://marketplace.zoom.us/docs/api-reference/zoom-api/users/userdelete
* `bool UpdateUserEmail(string userId, string newEmail)` - Update a user's email address. https://marketplace.zoom.us/docs/api-reference/zoom-api/users/useremailupdate

### IZoomWebhooksClient

* `ListWebhooks GetWebhooks()` - List webhooks for an account. https://marketplace.zoom.us/docs/api-reference/zoom-api/webhooks/webhooks
* `Webhook CreateWebhook(CreateWebhook createWebhook)` - Create a webhook for an account. https://marketplace.zoom.us/docs/api-reference/zoom-api/webhooks/webhookcreate
* `Webhook GetWebhook(string webhookId)` - Retrieve a webhook. https://marketplace.zoom.us/docs/api-reference/zoom-api/webhooks/webhook
* `bool UpdateWebhook(string webhookId, UpdateWebhook webhook)` - Update a webhook. https://marketplace.zoom.us/docs/api-reference/zoom-api/webhooks/webhookupdate
* `bool DeleteWebhook(string webhookId)` - Delete a webhook. https://marketplace.zoom.us/docs/api-reference/zoom-api/webhooks/webhookdelete