namespace TodoAPi.Models;


public class Todo
{
    public string Title { get; set; }

    public bool Done { get; set; } 

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdate { get; set; }

    public User User { get; set; }

    public int UserId { get; set; }

}