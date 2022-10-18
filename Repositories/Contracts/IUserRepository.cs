using TodoAPi.Models;
using TodoAPi.ViewModels;
using TodoAPi.ViewModels.User;

namespace TodoAPi.Repositories.Contracts;

public interface IUserRepository
{
    Task<ResultViewModel<List<User>>> GetUsersAsync();
    Task<ResultViewModel<EditorUserViewModel>> RegisterUserAsync(EditorUserViewModel model);

    Task<ResultViewModel<EditorUserViewModel>> UpdateUserNameAsync(EditorUserViewModel model, int id);

    Task<ResultViewModel<bool>> Deleteuser(int id);

}