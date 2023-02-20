namespace ISMS_API.DTOs
{
    public class RegisterUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int RoleId { get; set; }
    }
}
