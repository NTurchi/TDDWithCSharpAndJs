using API.Entity.DTO;
using API.Services;
using Test.DAL.Repository;
using Xunit;

namespace Test.BAL.UserProfileServiceTests {
    public class GetUserProfileTests {
        [Fact]
        public void ItReturnsNullForNonExistentUsers () {
            // Arrange
            var repository = new FakeRepository<UserProfileDto> ();
            var service = new UserProfileService (repository);

            // Act
            var profile = service.GetUserProfile ("NonExistantUser@email.com");

            // Assert
            Assert.Null (profile);
        }

        [Fact]
        public void ItReturnsUserProfileForUsersThatExist () {
            // Arrange
            var repository = new FakeRepository<UserProfileDto> ();
            var service = new UserProfileService (repository);

            repository.DataSet.Add (new UserProfileDto {
                Username = "ExistingUser@email.com"
            });

            // Act
            var profile = service.GetUserProfile ("ExistingUser@email.com");

            // Assert
            Assert.NotNull (profile);
            Assert.IsAssignableFrom<UserProfileDto> (profile);
        }
    }
}