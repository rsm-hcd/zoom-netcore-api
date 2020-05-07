using AndcultureCode.ZoomClient.Interfaces;
using AndcultureCode.ZoomClient.Models;
using AndcultureCode.ZoomClient.Models.Meetings;
using AndcultureCode.ZoomClient.Models.Users;
using AndcultureCode.ZoomClient.Models.Webhooks;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AndcultureCode.ZoomClient.Tests.Integration
{
    [TestFixture]
    public class ZoomClientTests
    {
        #region Private Members

        IZoomClient _sut;
        Meeting     _meeting;
        string      _userEmail;
        Webhook     _webhook;

        private const string MISSING_MEETING_ERROR_STRING = "\"code\":3001";
        private const string PASSWORD                     = "123456";

        #endregion

        #region Setup and Teardown

        [SetUp]
        public void Setup()
        {
            _sut = new ZoomClient(new ZoomClientOptions
            {
                ZoomApiKey    = "",
                ZoomApiSecret = ""
			});
        }

        [TearDown]
        public void Teardown()
        {
            if (_meeting != null && !string.IsNullOrWhiteSpace(_meeting.Id))
            {
                _sut.Meetings.DeleteMeeting(_meeting.Id);
                _meeting = null;
            }

            if (_webhook != null && !string.IsNullOrWhiteSpace(_webhook.WebhookId))
            {
                _sut.Webhooks.DeleteWebhook(_webhook.WebhookId);
                _webhook = null;
            }
        }

        #endregion

        #region Meeting Tests

        [Test]
        public void Create_Meeting_With_Password_Returns_Meeting()
        {
            // Arrange
            GetUser();
            GenerateMeeting(PASSWORD);

            // Act
            _meeting = _sut.Meetings.CreateMeeting(_userEmail, _meeting);

            // Assert
            _meeting.ShouldNotBeNull();
            _meeting.Uuid.ShouldNotBeNullOrWhiteSpace();
            _meeting.Id.ShouldNotBeNullOrWhiteSpace();
            _meeting.StartUrl.ShouldNotBeNullOrWhiteSpace();
            _meeting.StartUrl.ShouldContain("zak=", "StartUrl=" + _meeting.StartUrl);
            _meeting.JoinUrl.ShouldNotBeNullOrWhiteSpace();
            _meeting.JoinUrl.ShouldContain("pwd=", "JoinUrl=" + _meeting.JoinUrl);
        }

        [Test]
        public void Create_Meeting_Without_Password_Returns_Meeting()
        {
            // Arrange
            GetUser();
            GenerateMeeting();

            // Act
            _meeting = _sut.Meetings.CreateMeeting(_userEmail, _meeting);

            // Assert
            _meeting.ShouldNotBeNull();
            _meeting.Uuid.ShouldNotBeNullOrWhiteSpace();
            _meeting.Id.ShouldNotBeNullOrWhiteSpace();
            _meeting.StartUrl.ShouldNotBeNullOrWhiteSpace();
            _meeting.StartUrl.ShouldContain("zak=", "StartUrl=" + _meeting.StartUrl);
            _meeting.JoinUrl.ShouldNotBeNullOrWhiteSpace();
            _meeting.JoinUrl.ShouldNotContain("pwd=", "JoinUrl=" + _meeting.JoinUrl);
        }

        [Test]
        public void Create_Meeting_Registrants_With_Password_Returns_Registrant()
        {
            // Arrange
            GetUser();
            GenerateMeeting(PASSWORD);
            _meeting = _sut.Meetings.CreateMeeting(_userEmail, _meeting);

            // Act
            var result = _sut.Meetings.CreateMeetingRegistrant(_meeting.Id, new CreateMeetingRegistrant
            {
                Email     = $"test{DateTimeOffset.Now.ToUnixTimeMilliseconds()}@gmail.com",
                FirstName = "FirstName",
                LastName  = "LastName"
            });

            // Assert
            result.ShouldNotBeNull();
            result.JoinUrl.ShouldNotBeNullOrWhiteSpace();
            result.JoinUrl.ShouldContain("pwd=", "JoinUrl=" + _meeting.JoinUrl);
        }

        [Test]
        public void Create_Meeting_Registrants_Without_Password_Returns_Registrant()
        {
            // Arrange
            GetUser();
            GenerateMeeting();
            _meeting = _sut.Meetings.CreateMeeting(_userEmail, _meeting);

            // Act
            var result = _sut.Meetings.CreateMeetingRegistrant(_meeting.Id, new CreateMeetingRegistrant
            {
                Email     = $"test{DateTimeOffset.Now.ToUnixTimeMilliseconds()}@gmail.com",
                FirstName = "FirstName",
                LastName  = "LastName"
            });

            // Assert
            result.ShouldNotBeNull();
            result.JoinUrl.ShouldNotBeNullOrWhiteSpace();
            result.JoinUrl.ShouldNotContain("pwd=", "JoinUrl=" + _meeting.JoinUrl);
        }

        [Test]
        public void Delete_Meeting_Returns_Success()
        {
            // Arrange
            GetUser();
            GenerateMeeting();
            _meeting = _sut.Meetings.CreateMeeting(_userEmail, _meeting);

            // Act
            var result = _sut.Meetings.DeleteMeeting(_meeting.Id);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(true);

            // Cleanup
            _meeting = null;
        }

        [Test]
        public void Delete_Invalid_Meeting_Throws_Exception()
        {
            // Arrange

            // Act
            var exception = Assert.Throws<Exception>(() => _sut.Meetings.DeleteMeeting("99999999"));

            // Assert
            exception.ShouldNotBeNull("Exception");
            exception.Message.ShouldNotBeNull("Message");
            exception.Message.ShouldContain(MISSING_MEETING_ERROR_STRING);
        }

        [Test]
        public void Get_Meeting_Returns_Meeting()
        {
            // Arrange
            GetUser();
            GenerateMeeting();
            _meeting = _sut.Meetings.CreateMeeting(_userEmail, _meeting);

            // Act
            var result = _sut.Meetings.GetMeeting(_meeting.Id);

            // Assert
            result.ShouldNotBeNull();
            result.Uuid.ShouldNotBeNullOrWhiteSpace();
            result.JoinUrl.ShouldNotBeNullOrWhiteSpace();
        }

		[Test]
		public void GetPastMeetingDetails_Returns_Meeting()
		{
			// Arrange
			GetUser();

			// Act
			var result = _sut.Meetings.GetPastMeetingDetails("891627341");

			// Assert
			result.ShouldNotBeNull();
			result.Uuid.ShouldNotBeNullOrWhiteSpace();
			Console.Write($"Meeting ID: {result.Id}\nParticipants: {result.ParticipantsCount}\nType: {result.Type}\nStart: {result.StartTime}\nEnd: {result.EndTime}");
		}

		[Test]
        public void Get_Invalid_Meeting_Throws_Exception()
        {
            // Arrange

            // Act
            var exception = Assert.Throws<Exception>(() => _sut.Meetings.GetMeeting("999999999"));

            // Assert
            exception.ShouldNotBeNull("Exception");
            exception.Message.ShouldNotBeNull("Message");
            exception.Message.ShouldContain(MISSING_MEETING_ERROR_STRING);
        }

        [Test]
        public void Get_Meeting_Registrants_Returns_List()
        {
            // Arrange
            GetUser();
            GenerateMeeting();
            _meeting = _sut.Meetings.CreateMeeting(_userEmail, _meeting);

            // Act
            var result = _sut.Meetings.GetMeetingRegistrants(_meeting.Id);

            // Assert
            result.ShouldNotBeNull();
            result.Registrants.ShouldNotBeNull();
        }

        [Test]
        public void Get_Invalid_Meeting_Registrants_Throws_Exception()
        {
            // Arrange

            // Act
            var exception = Assert.Throws<Exception>(() => _sut.Meetings.GetMeetingRegistrants("99999999"));

            // Assert
            exception.ShouldNotBeNull("Exception");
            exception.Message.ShouldNotBeNull("Message");
            exception.Message.ShouldContain(MISSING_MEETING_ERROR_STRING);
        }

        [Test]
        public void Update_Meeting_Returns_Success()
        {
            // Arrange
            GetUser();
            GenerateMeeting();
            _meeting = _sut.Meetings.CreateMeeting(_userEmail, _meeting);
            _meeting.Topic = "Another Test Topic";

            // Act
            var result = _sut.Meetings.UpdateMeeting(_meeting.Id, _meeting);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(true);
        }

        [Test]
        public void Update_Invalid_Meeting_Throws_Exception()
        {
            // Arrange
            GenerateMeeting();

            // Act
            var exception = Assert.Throws<Exception>(() => _sut.Meetings.UpdateMeeting("99999999", _meeting));

            // Assert
            exception.ShouldNotBeNull("Exception");
            exception.Message.ShouldNotBeNull("Message");
            exception.Message.ShouldContain(MISSING_MEETING_ERROR_STRING);
        }

        #endregion

        #region Group Tests

        [Test]
        public void Load_Groups_Returns_List()
        {
            // Arrange
            var group = _sut.Groups.CreateGroup(new Models.Groups.CreateGroup
            {
                Name = $"Test Group {DateTimeOffset.Now.ToUnixTimeMilliseconds()}"
            });
            group.Id.ShouldNotBeNullOrWhiteSpace();

            // Act
            var result = _sut.Groups.GetGroups();

            // Assert
            result.ShouldNotBeNull();
            result.Groups.ShouldNotBeNull();
            result.Groups.Count.ShouldBeGreaterThan(0);

            // Cleanup
            _sut.Groups.DeleteGroup(group.Id);
        }

        [Test]
        public void Get_Group_Returns_Valid_Group()
        {
            // Arrange
            var group = _sut.Groups.CreateGroup(new Models.Groups.CreateGroup
            {
                Name = $"Test Group {DateTimeOffset.Now.ToUnixTimeMilliseconds()}"
            });
            group.Id.ShouldNotBeNullOrWhiteSpace();

            // Act
            var result = _sut.Groups.GetGroup(group.Id);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldNotBeNull();
            result.Name.ShouldNotBeNullOrWhiteSpace();

            // Cleanup
            _sut.Groups.DeleteGroup(group.Id);
        }

        [Test]
        public void Get_Group_Members_Returns_List()
        {
            // Arrange
            var group = _sut.Groups.CreateGroup(new Models.Groups.CreateGroup
            {
                Name = $"Test Group {DateTimeOffset.Now.ToUnixTimeMilliseconds()}"
            });
            group.Id.ShouldNotBeNullOrWhiteSpace();
            GetUser();
            _sut.Groups.AddGroupMembers(group.Id, new List<Models.Groups.CreateMember>
            {
                new Models.Groups.CreateMember
                {
                    Email = _userEmail
                }
            });

            // Act
            var result = _sut.Groups.GetGroupMembers(group.Id);

            // Assert
            result.ShouldNotBeNull();
            result.TotalRecords.ShouldBeGreaterThan(0);
            result.Members.ShouldNotBeNull();
            result.Members.FirstOrDefault().Email.ShouldBe(_userEmail);

            // Cleanup
            _sut.Groups.DeleteGroup(group.Id);
        }

        [Test]
        public void Update_Meeting_Registrants_Returns_Success()
        {
            // Arrange
            GetUser();
            GenerateMeeting();
            _meeting = _sut.Meetings.CreateMeeting(_userEmail, _meeting);
            var registrant = _sut.Meetings.CreateMeetingRegistrant(_meeting.Id, new CreateMeetingRegistrant
            {
                Email = $"test{DateTimeOffset.Now.ToUnixTimeMilliseconds()}@gmail.com",
                FirstName = "FirstName",
                LastName = "LastName"
            });

            // Act
            var result = _sut.Meetings.UpdateMeetingRegistrant(_meeting.Id, new List<UpdateMeetingRegistrant> { new UpdateMeetingRegistrant { Email = registrant.Email } }, UpdateMeetingRegistrantStatuses.Approve);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(true);
        }

        [Test]
        public void Update_Invalid_Meeting_Registrants_Throws_Exception()
        {
            // Arrange

            // Act
            var exception = Assert.Throws<Exception>(() => _sut.Meetings.CreateMeetingRegistrant("99999999", new CreateMeetingRegistrant
            {
                Email = $"test{DateTimeOffset.Now.ToUnixTimeMilliseconds()}@gmail.com",
                FirstName = "FirstName",
                LastName = "LastName"
            }));

            // Assert
            exception.ShouldNotBeNull("Exception");
            exception.Message.ShouldNotBeNull("Message");
            exception.Message.ShouldContain(MISSING_MEETING_ERROR_STRING);
        }

        #endregion

        #region User Tests

        [Test]
        public void Load_User_Meetings_By_Email_Returns_List()
        {
            // Arrange
            GetUser();

            // Act
            var result = _sut.Meetings.GetMeetings(_userEmail, MeetingListTypes.Scheduled);

            //// Assert
            result.ShouldNotBeNull();
            result.Meetings.ShouldNotBeNull();
            result.Meetings.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Load_All_Users_Returns_List()
        {
            // Arrange


            // Act
            var result = _sut.Users.GetUsers();

            // Assert
            result.ShouldNotBeNull();
            result.Users.ShouldNotBeNull();
            result.Users.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Create_User_Invalid_Action_Returns_Error()
        {
            // Arrange
            var user = new CreateUser
            {
                Email = "test123@gmail.com",
                Type = UserTypes.Basic
            };

            // Act
            Exception exception = null;
            User result = null;
            try
            {
                result = _sut.Users.CreateUser(user, "badAction");
            } catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            result.ShouldBeNull();
            exception.ShouldNotBeNull();
        }

        [Test]
        [Ignore("This method should only work IF you have SSOCreate feature enabled on your zoom account. If you are confident it is enabled you can remove this line and test.")]
        public void Create_User_Returns_Valid_User()
        {
            // Arrange
            var email = $"testuser_{DateTimeOffset.Now.ToUnixTimeSeconds()}@gmail.com";
            var user = new CreateUser
            {
                Email = email,
                Type = UserTypes.Basic
            };

            // Act
            var result = _sut.Users.CreateUser(user, CreateUserAction.SsoCreate);

            // Assert
            result.ShouldNotBeNull();
            result.Email.ShouldBe(email);
            result.Id.ShouldNotBeNull();

            // Cleanup
            _sut.Users.DeleteUser(result.Id, DeleteUserAction.Delete);
        }

        [Test]
        public void Get_User_Returns_Valid_User()
        {
            // Arrange
            GetUser();

            // Act
            var result = _sut.Users.GetUser(_userEmail);

            // Assert
            result.ShouldNotBeNull();
            result.Email.ShouldBe(_userEmail);
            result.Id.ShouldNotBeNull();
        }

        [Test]
        public void Update_User_Returns_Valid_User()
        {
            // Arrange
            GetUser();
            var user = _sut.Users.GetUser(_userEmail);
            var originalLastName = user.LastName;
            var newLastName = $"Last Name {DateTimeOffset.Now.ToUnixTimeMilliseconds()}";
            var updateUser = new UpdateUser
            {
                FirstName = user.FirstName,
                LastName = newLastName
            };

            // Act
            var result = _sut.Users.UpdateUser(_userEmail, updateUser);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(true);
            user = _sut.Users.GetUser(_userEmail);
            user.Email.ShouldBe(_userEmail);
            user.LastName.ShouldBe(newLastName);

            // Cleanup
            _sut.Users.UpdateUser(_userEmail, new UpdateUser
            {
                FirstName = user.FirstName,
                LastName = originalLastName
            });
        }

        [Test]
        public void Update_User_Email_Returns_Success()
        {
            // Arrange
            GetUser();
            var user = _sut.Users.GetUser(_userEmail);
            var originalEmail = _userEmail;
            var newEmail = $"testuser{DateTimeOffset.Now.ToUnixTimeMilliseconds()}@gmail.com";

            // Act
            var result = _sut.Users.UpdateUserEmail(originalEmail, newEmail);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(true);
            user = _sut.Users.GetUser(newEmail);
            user.Email.ShouldBe(newEmail);

            // Cleanup
            _sut.Users.UpdateUserEmail(newEmail, originalEmail);
        }

        #endregion

        #region Report Tests

        [Test]
        public void Get_User_Participant_Report_For_Last_Meeting()
        {
            // Arrange
            string meetingId = "817473809";

            // Act
            var result = _sut.Reports.GetMeetingParticipantsReport(meetingId);

            // Assert
            result.ShouldNotBeNull();
            result.Participants.ShouldNotBeNull();
            result.Participants.Count.ShouldBeGreaterThan(0);
        }

        #endregion

        #region Webhook Tests

        [Test]
        public void List_Webhooks_Returns_List()
        {
            // Arrange
            CreateWebhook();
            _webhook.WebhookId.ShouldNotBeNullOrWhiteSpace();

            // Act
            var result = _sut.Webhooks.GetWebhooks();

            // Assert
            result.ShouldNotBeNull();
            result.TotalRecords.ShouldBeGreaterThan(0);
            result.Webhooks.Select(e => e.WebhookId).ShouldContain(_webhook.WebhookId);
        }

        [Test]
        public void Create_Webhooks_Returns_Webhook()
        {
            // Arrange

            // Act
            CreateWebhook();

            // Assert
            _webhook.ShouldNotBeNull();
            _webhook.WebhookId.ShouldNotBeNullOrWhiteSpace();
        }

        [Test]
        public void Delete_Webhooks_Returns_Success()
        {
            // Arrange
            CreateWebhook();
            _webhook.WebhookId.ShouldNotBeNullOrWhiteSpace();

            // Act
            var result = _sut.Webhooks.DeleteWebhook(_webhook.WebhookId);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(true);

            // Cleanup
            _webhook = null;
        }

        [Test]
        public void Update_Webhooks_Returns_Success()
        {
            // Arrange
            CreateWebhook();
            _webhook.WebhookId.ShouldNotBeNullOrWhiteSpace();
            var update = new UpdateWebhook
            {
                Url = "https://anotherurl.com",
                AuthUser = "testUser2",
                AuthPassword = "password2",
                Events = new List<string>
                {
                    WebhookEvents.MeetingEnded, WebhookEvents.RecordingCompleted, WebhookEvents.RecordingTranscriptCompleted
                }
            };

            // Act
            var result = _sut.Webhooks.UpdateWebhook(_webhook.WebhookId, update);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(true);
            var webhook = _sut.Webhooks.GetWebhook(_webhook.WebhookId);
            webhook.WebhookId.ShouldNotBeNullOrWhiteSpace();
            webhook.Url.ShouldBe(update.Url);
            webhook.AuthUser.ShouldBe(update.AuthUser);
            webhook.AuthPassword.ShouldBe(update.AuthPassword);
        }

        #endregion

        #region Private Methods

        void CreateWebhook()
        {
            _webhook = _sut.Webhooks.CreateWebhook(new CreateWebhook
            {
                Url = "https://google.com",
                AuthUser = "testUser",
                AuthPassword = "password",
                Events = new List<string>
                {
                    WebhookEvents.MeetingEnded, WebhookEvents.RecordingCompleted, WebhookEvents.RecordingTranscriptCompleted
                }
            });
        }

        void GetUser()
        {
            _userEmail = _sut.Users.GetUsers().Users.FirstOrDefault().Email;
        }

        void GenerateMeeting(string password = null)
        {
            _meeting = new Meeting
            {
                Duration   = 60,
                Password   = password,
                Settings   = new MeetingSettings
                {
                    EnableHostVideo        = true,
                    EnableParticipantVideo = true,
                    EnableJoinBeforeHost   = false,
                    ApprovalType           = MeetingApprovalTypes.Automatic,
                    AutoRecording          = MeetingAutoRecordingOptions.Cloud,
                    EnableEnforceLogin     = true
                },
                StartTime = DateTimeOffset.Now,
                Topic     = "Test Meeting " + DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Type      = MeetingTypes.Scheduled,
            };
        }

        #endregion
    }
}
