namespace CoreApp.Data.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }

    public int UserRoleId { get; set; }
    public virtual UserRole UserRole { get; set; }
}