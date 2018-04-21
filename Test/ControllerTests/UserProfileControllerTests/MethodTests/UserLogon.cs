using API.Controllers;
using API.Entity.DTO;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Test.DAL.Repository;
using Xunit;

namespace Test.ControllerTests.UserProfileControllerTests.MethodTests
{
    public class UserLogon
    {
        private readonly UserProfileController _controller;

        public UserLogon()
        {
            // Arrange
            var repository = new FakeRepository<UserProfileDto>();
            var service = new UserProfileService(repository);
            _controller = new UserProfileController(service);

            repository.DataSet.Add(new UserProfileDto
            {
                Username = "TestUser@email.com",
                PasswordHash = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes("ValidPassword"))
            });
        }

        [Fact]
        public void ItExists()
        {
            // Act
            var response = _controller.LogonUser("TestUser@email.com", "Password");
        }

        [Fact]
        public void ItReturnsAnActionResult()
        {
            // Act
            var response = _controller.LogonUser("TestUser@email.com", "Password");

            // Assert
            Assert.IsAssignableFrom<IActionResult>(response);
        }

        [Fact]
        public void ItReturnsNotAuthorizedForBadUsername()
        {
            // Act
            var response = (StatusCodeResult)_controller.LogonUser("BadUser@email.com", "ValidPassword");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, (HttpStatusCode)response.StatusCode);
        }

        [Fact]
        public void ItReturnsOkForValidUsernameAndPassword()
        {
            // Act
            var response = (StatusCodeResult)_controller.LogonUser("TestUser@email.com", "ValidPassword");

            // Assert
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
        }

        [Fact]
        public void ItReturnsUnauthorizedForInvlalidPassword()
        {
            // Act
            var response = (StatusCodeResult)_controller.LogonUser("TestUser@email.com", "InvalidPassword");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, (HttpStatusCode)response.StatusCode);
        }
    }
}
