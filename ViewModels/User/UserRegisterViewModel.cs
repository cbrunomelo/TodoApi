using System.ComponentModel.DataAnnotations;

namespace TodoAPi.ViewModels.User;


public class UserRegisterViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 80 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O Email é obrigatório")]
    [EmailAddress(ErrorMessage = "O E-mail é inválido")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Email deve conter entre 3 e 80 caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatório")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Senha deve conter entre 3 e 80 caracteres")]
    public string PasswordHash { get; set; }


}