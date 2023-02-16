using Microsoft.AspNetCore.Identity;
using skitBackend.Data.Enums;
using skitBackend.Data.Models;

namespace Data.Models;

public class User
{
    public int Id { get; set; }
    public string? PublicId { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string Login { get; set; }
    public string Password { get; set; }
    public string Nickname { get; set; }
    public string? DiscordNickname { get; set; }
    public string Email { get; set; }
    public List<Comment>? Comments { get; set; }
    public UserRoleEnum UserRole { get; set; }
}