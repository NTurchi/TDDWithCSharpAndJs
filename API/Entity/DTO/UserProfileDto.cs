using System;

namespace API.Entity.DTO {
    public class UserProfileDto {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}