using System.ComponentModel.DataAnnotations;

namespace skitBackend.Data.Models.Dto
{
    public class RegisterUserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
    }
}
