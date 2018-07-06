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

        #endregion

        #region Setup and Teardown

        [SetUp]
        public void Setup()
        {
            _sut = new ZoomClient(new ZoomClientOptions
            {
                ZoomApiKey = "",
                ZoomApiSecret = ""
            });
        }

        [TearDown]
        public void Teardown() { }

        #endregion

        #region Meeting Tests

        [Test]
        public void Create_Meeting_Returns_Meeting()
        {
            // Arrange
            string userEmail = null;
            try
            {
                userEmail = _sut.Users.GetUsers().Users.FirstOrDefault().Email;
            }
            catch (Exception) { }
            userEmail.ShouldNotBeNull();
            var meeting = new Meeting
            {
                Topic = "Test Meeting",
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

            // Act
            var result = _sut.Meetings.CreateMeeting(userEmail, meeting);

            // Assert
            result.ShouldNotBeNull();
            result.Uuid.ShouldNotBeNullOrWhiteSpace();
        }

        #endregion


        #region User Tests

        [Test]
        public void Load_User_Meetings_By_Email_Returns_List()
        {
            // Arrange
            string userEmail = null;
            try
            {
                userEmail = _sut.Users.GetUsers().Users.FirstOrDefault().Email;
            } catch (Exception) { }
            userEmail.ShouldNotBeNull();

            // Act
            var result = _sut.Meetings.GetMeetings(userEmail, MeetingListTypes.Scheduled);

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
        public void Create_User_Returns_Valid_User()
        {
            /**
             * Developer Note: This method should only work IF you have SSOCreate feature enabled on your zoom account
             * If you are confident it is enabled you can remove the return below and test.
             */
            return;

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
    }
}
