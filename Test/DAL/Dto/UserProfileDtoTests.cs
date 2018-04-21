using System;
using API.Entity.DTO;
using Xunit;

namespace Test.DAL.Dto {
    public class UserProfileDtoTests {
        [Fact]
        public void ItExists () {
            var dto = new UserProfileDto ();
        }

        [Fact]
        public void ItHasAndId () {
            // Arrange
            var dto = new UserProfileDto ();
            dto.Id = 1;
            // Act
            // Assert
            Assert.Equal (1, dto.Id);
        }

        public void ItHasAUserName () {
            // Arrange
            var dto = new UserProfileDto ();
            // Act
            dto.Username = "Nicolas";
            // Assert
            Assert.Equal ("Nicolas", dto.Username);
        }
    }
}