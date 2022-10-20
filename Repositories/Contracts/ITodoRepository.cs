using TodoAPi.ViewModels;
using TodoAPi.ViewModels.Todo;

namespace TodoAPi.Repositories.Contracts;

public interface ITodoRepository
{
    Task<ResultViewModel<TodoViewModel>> UpdateStatusTodoFromAUser(EditorTodoViewModel model, string email);
    Task<ResultViewModel<bool>> DeleteATodoFromAUser(String title, string email);
    Task<ResultViewModel<List<TodoViewModel>>> GetAllTodosFromAUser(string email);
    Task<ResultViewModel<TodoViewModel>> RegisterTodoAsync(EditorTodoViewModel model, string email);

}