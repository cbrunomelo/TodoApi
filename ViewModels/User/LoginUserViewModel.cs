using System.ComponentModel.DataAnnotations;

namespace TodoAPi.ViewModels.User;


public class LoginUserViewModel
{
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "O e-mail é inválido")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "E-mail deve conter entre 3 e 80 caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatório")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Senha deve conter entre 3 e 80 caracteres")]
    public string Password { get; set; }
}