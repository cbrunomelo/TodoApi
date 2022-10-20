using System.ComponentModel.DataAnnotations;

namespace TodoAPi.ViewModels.User;


public class EditorUserViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O Password é obrigatório")]
    public string Password { get; set; }
}