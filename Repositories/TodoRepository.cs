using Microsoft.EntityFrameworkCore;
using TodoAPi.Data;
using TodoAPi.Models;
using TodoAPi.ViewModels;
using TodoAPi.ViewModels.Todo;
using TodoAPi.Repositories.Contracts;

namespace TodoAPi.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoAPiDataContext _context;
    public TodoRepository(TodoAPiDataContext context)
        => _context = context;

    public async Task<ResultViewModel<TodoViewModel>> RegisterTodoAsync(EditorTodoViewModel model, string email)
    {

        try
        {

            var task = await _context.Todos.FirstOrDefaultAsync(x => x.Email == email && x.Title == model.Title);
            if (task != null)
                return new ResultViewModel<TodoViewModel>("Usuário ja possui essa tarefa");

            var todo = new Todo
            {
                Title = model.Title,
                Done = model.Done,
                CreatedAt = DateTime.Now.ToUniversalTime(),
                LastUpdate = DateTime.Now.ToUniversalTime(),
                Email = email
            };

            await _context.AddAsync(todo);
            await _context.SaveChangesAsync();

            var viewmodel = new TodoViewModel { Title = todo.Title, CreatedAt = todo.CreatedAt, LastUpdate = todo.LastUpdate, Done = todo.Done };
            return new ResultViewModel<TodoViewModel>(viewmodel);

        }
        catch (DbUpdateException ex)
        {
            return new ResultViewModel<TodoViewModel>("15XE9 - Não foi possível incluir a tarefa");
        }

        catch
        {
            return new ResultViewModel<TodoViewModel>("Falha interna no servidor");
        }
    }

    public async Task<ResultViewModel<List<TodoViewModel>>> GetAllTodosFromAUser(string email)
    {
        try
        {

            var result = new List<TodoViewModel>();
            var todos = await _context.Todos
                          .Where(x => x.Email == email)
                          .Select(x => new TodoViewModel
                          {
                              Title = x.Title,
                              CreatedAt = x.CreatedAt,
                              LastUpdate = x.LastUpdate,
                              Done = x.Done,
                          }
                          )
                          .AsNoTracking()
                          .ToListAsync();

            if (todos.Count == 0)
                return new ResultViewModel<List<TodoViewModel>>("Usuário sem Tarefas");


            return new ResultViewModel<List<TodoViewModel>>(todos);
        }
        catch
        {
            return new ResultViewModel<List<TodoViewModel>>("Falha interna no servidor");
        }
    }


    public async Task<ResultViewModel<bool>> DeleteATodoFromAUser(String title, string email)
    {

        try
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Email == email && x.Title == title);
            if (todo == null)
                return new ResultViewModel<bool>("Tarefa não encontrada, Titulo incorreto");

            _context.Remove(todo);
            await _context.SaveChangesAsync();

            return new ResultViewModel<bool>(true); ;
        }
        catch (DbUpdateException ex)
        {
            return new ResultViewModel<bool>("05XE8 - Não foi possível alterar a categoria");
        }

        catch
        {
            return new ResultViewModel<bool>("Falha interna no servidor");
        }
    }

    public async Task<ResultViewModel<TodoViewModel>> UpdateStatusTodoFromAUser(EditorTodoViewModel model, string email)
    {
        try
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Email == email && x.Title == model.Title);

            if (todo == null)
                return new ResultViewModel<TodoViewModel>("Tarefa não encontrada, Titulo incorreto");


            todo.LastUpdate = DateTime.Now.ToUniversalTime();
            todo.Done = model.Done;

            _context.Update(todo);
            await _context.SaveChangesAsync();

            var viewmodel = new TodoViewModel { Title = todo.Title, CreatedAt = todo.CreatedAt, LastUpdate = todo.LastUpdate, Done = todo.Done };

            return new ResultViewModel<TodoViewModel>(viewmodel);

        }
        catch (DbUpdateException ex)
        {
            return new ResultViewModel<TodoViewModel>("05XE8 - Não foi possível alterar a categoria");
        }

        catch
        {
            return new ResultViewModel<TodoViewModel>("Falha interna no servidor");
        }
    }

    public async Task<ResultViewModel<List<TodoViewModel>>> GetUnfinishedTodosFromAUser(string email)
    {
        try
        {

            var result = new List<TodoViewModel>();
            var todos = await _context.Todos
                          .Where(x => x.Email == email && x.Done == false)
                          .Select(x => new TodoViewModel
                          {
                              Title = x.Title,
                              CreatedAt = x.CreatedAt,
                              LastUpdate = x.LastUpdate,
                              Done = x.Done,
                          }
                          )
                          .AsNoTracking()
                          .ToListAsync();

            if (todos.Count == 0)
                return new ResultViewModel<List<TodoViewModel>>("Usuário sem Tarefas Inacabadas");


            return new ResultViewModel<List<TodoViewModel>>(todos);
        }
        catch
        {
            return new ResultViewModel<List<TodoViewModel>>("Falha interna no servidor");
        }
    }
}