using System.ComponentModel.DataAnnotations;

namespace TodoAPi.ViewModels.User;


public class EditorUserViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Nome deve conter entre 3 e 80 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A senha é obrigatório")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Senha deve conter entre 3 e 80 caracteres")]
    public string Password { get; set; }
}