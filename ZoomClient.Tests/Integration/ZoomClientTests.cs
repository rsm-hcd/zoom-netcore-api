using AndcultureCode.ZoomClient;
using AndcultureCode.ZoomClient.Interfaces;
using AndcultureCode.ZoomClient.Models;
using AndcultureCode.ZoomClient.Models.Meetings;
using AndcultureCode.ZoomClient.Models.Users;
using NUnit.Framework;
using Shouldly;
using System;
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

        #endregion

        #region Setup and Teardown

        [SetUp]
        public void Setup()
        {
            _sut = new ZoomClient(new ZoomClientOptions
            {
                ZoomApiKey = "eaHeqhjFTSy02e3DDmC6SA",
                ZoomApiSecret = "ouRovTuGj1d29dUXIrWvkD3be6vQrVJj7xLp"
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
        }

        #endregion

        #region Meeting Tests

        [Test]
        public void Create_Meeting_Returns_Meeting()
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

        #region Private Methods

        void GetUser()
        {
            _userEmail = _sut.Users.GetUsers().Users.FirstOrDefault().Email;
        }

        void GenerateMeeting()
        {
            _meeting = new Meeting
            {
                Topic = "Test Meeting " + DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Type = MeetingTypes.Scheduled,
                StartTime = DateTimeOffset.Now,
                Duration = 60,
                Settings = new MeetingSettings
                {
                    EnableHostVideo = true,
                    EnableParticipantVideo = true,
                    EnableJoinBeforeHost = false,
                    ApprovalType = MeetingApprovalTypes.Automatic,
                    AutoRecording = MeetingAutoRecordingOptions.Cloud,
                    EnableEnforceLogin = true
                }
            };
        }

        #endregion
    }
}
