namespace TodoAPi.ViewModels.Todo;

public class TodoViewModel
{
    public string? Title { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastUpdate { get; set; }

    public bool? Done { get; set; }
}