using System.ComponentModel.DataAnnotations;

namespace TodoAPi.ViewModels.Todo;


public class EditorTodoViewModel
{



    [Required(ErrorMessage = "O nome da tarefa é obrigatório")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 80 caracteres")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Conclusão da tarefa é obrigatório")]
    public bool Done { get; set; }
}