namespace CoreApp.Data.Models;

public class Login
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
}