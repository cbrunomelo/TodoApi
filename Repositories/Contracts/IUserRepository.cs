using TodoAPi.Models;
using TodoAPi.ViewModels;
using TodoAPi.ViewModels.User;

namespace TodoAPi.Repositories.Contracts;

public interface IUserRepository
{
    Task<ResultViewModel<List<UserViewModel>>> GetUsersAsync();
    Task<ResultViewModel<UserViewModel>> RegisterUserAsync(UserViewModel model);

    Task<ResultViewModel<UserViewModel>> UpdateUser(EditorUserViewModel model, string email);

    Task<ResultViewModel<bool>> Deleteuser(string email);

    ResultViewModel<UserViewModel> RegisterUser(UserRegisterViewModel model);

    ResultViewModel<User> UserLogin(LoginUserViewModel model);


}