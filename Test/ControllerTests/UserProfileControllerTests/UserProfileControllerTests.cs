using API.Controllers;
using API.Entity.DTO;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DAL.Repository;
using Xunit;

namespace Test.ControllerTests.UserControllerTests
{
    public class UserProfileControllerTests
    {


        [Fact]
        public void ItExists()
        {
            var service = new UserProfileService(new FakeRepository<UserProfileDto>());
            var controller = new UserProfileController(service);
        }

        [Fact]
        public void ItIsAController()
        {
            var service = new UserProfileService(new FakeRepository<UserProfileDto>());
            var controller = new UserProfileController(service);

            Assert.IsAssignableFrom<Controller>(controller);
        }
    }
}
