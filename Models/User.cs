namespace TodoAPi.Models;

public class User
{
    public string Email { get; set; }

    public string Name { get; set; }

    public string PasswordHash { get; set; }


    public List<Todo> Todos { get; set; }


    public List<UserRole> UserRoles { get; set; }
}