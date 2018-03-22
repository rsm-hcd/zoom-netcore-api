using AndcultureCode.ZoomClient;
using AndcultureCode.ZoomClient.Interfaces;
using AndcultureCode.ZoomClient.Models;
using AndcultureCode.ZoomClient.Models.Users;
using NUnit.Framework;
using Shouldly;
using System;

namespace ZoomClient.Tests.Integration
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
            _sut = new AndcultureCode.ZoomClient.ZoomClient(new ZoomClientOptions
            {
                ZoomApiKey = "eaHeqhjFTSy02e3DDmC6SA",
                ZoomApiSecret = "XfKzqO44Qtov4yWOkOSs20j061zYYrO9Ff9r"
            });
        }

        [TearDown]
        public void Teardown() { }

        #endregion

        [Test]
        public void Load_All_Users_Returns_List()
        {
            // Arrange


            // Act
            var result = _sut.GetUsers();

            // Assert
            result.ShouldNotBeNull();
            result.Users.ShouldNotBeNull();
            result.Users.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void Create_User_No_Action_Returns_Error()
        {
            // Arrange
            var user = new CreateUser
            {
                Email = "test123@gmail.com"
            };

            // Act
            Exception exception = null;
            User result = null;
            try
            {
                result = _sut.CreateUser(user);
            } catch (Exception ex)
            {
                exception = ex;
            }

            // Assert
            result.ShouldBeNull();
            exception.ShouldNotBeNull();
        }
    }
}
