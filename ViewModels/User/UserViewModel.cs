using System.ComponentModel.DataAnnotations;

namespace TodoAPi.ViewModels.User;


public class UserViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 80 caracteres")]
    public string Name { get; set; }

    public string Email { get; set; }
}   