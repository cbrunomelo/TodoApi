using TodoAPi.ViewModels;
using TodoAPi.ViewModels.Todo;

namespace TodoAPi.Repositories.Contracts;

public interface ITodoRepository
{
    Task<ResultViewModel<TodoViewModel>> UpdateStatusTodoFromAUser(EditorTodoViewModel model);
    Task<ResultViewModel<bool>> DeleteATodoFromAUser(EditorTodoViewModel model, int id);
    Task<ResultViewModel<List<TodoViewModel>>> GetAllTodosFromAUser(int id);
    Task<ResultViewModel<TodoViewModel>> RegisterTodoAsync(EditorTodoViewModel model);
    
}