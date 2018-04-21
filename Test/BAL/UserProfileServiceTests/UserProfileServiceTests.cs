using API.Entity.DTO;
using API.Services;
using Test.DAL.Repository;
using Xunit;

namespace Test.BAL.UserProfileServiceTests {
    public class UserProfileServiceTests {
        [Fact]
        public void ItExists () {
            var repository = new FakeRepository<UserProfileDto>();
            var service = new UserProfileService(repository);
        }
    }
}