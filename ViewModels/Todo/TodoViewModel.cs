using System.ComponentModel.DataAnnotations;

namespace TodoAPi.ViewModels.Todo;

public class TodoViewModel
{
    [Required(ErrorMessage = "O nome da tarefa é obrigatório")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 80 caracteres")]
    public string? Title { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? LastUpdate { get; set; }

    public bool? Done { get; set; }
}