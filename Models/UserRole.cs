namespace TodoAPi.Models;


public class UserRole
{
    public string RoleName { get; set; }

    public string UserEmail { get; set; }

    public User User { get; set; }

    public Role Role { get; set; }
}