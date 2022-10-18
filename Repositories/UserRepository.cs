using Microsoft.EntityFrameworkCore;
using TodoAPi.Data;
using TodoAPi.Models;
using TodoAPi.ViewModels;
using TodoAPi.ViewModels.User;
using TodoAPi.Repositories.Contracts;

namespace TodoAPi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TodoAPiDataContext _context;
    public UserRepository(TodoAPiDataContext context)
        =>_context = context;
    
    public async Task<ResultViewModel<List<User>>> GetUsersAsync()
    {
        try
        {
            var user = await _context.Users
                .AsNoTracking()
                .ToListAsync();
            if (user is null)
                return new ResultViewModel<List<User>>("Nenhum usuário registrado");

            return new ResultViewModel<List<User>>(user);
        }
        catch
        {

            return new ResultViewModel<List<User>>("Falha interna no servidor");
        }
    }

    public async Task<ResultViewModel<EditorUserViewModel>> RegisterUserAsync(EditorUserViewModel model)
    {
        try
        {

            var user = new User { Name = model.Name, Id = 0 };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return new ResultViewModel<EditorUserViewModel>(model);
        }

        catch (DbUpdateException ex)
        {
            return new ResultViewModel<EditorUserViewModel>("05XE9 - Não foi possível incluir o usuário");
        }

        catch
        {

            return new ResultViewModel<EditorUserViewModel>("Falha interna no servidor");
        }
    }

    public async Task<ResultViewModel<EditorUserViewModel>> UpdateUserNameAsync(EditorUserViewModel model, int id)
    {


        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return new ResultViewModel<EditorUserViewModel>("Usuário não encontrado");

            user.Name = model.Name;

            _context.Update(user);
            _context.SaveChanges();
            return new ResultViewModel<EditorUserViewModel>(model);

        }
        catch
        {

            return new ResultViewModel<EditorUserViewModel>("Falha interna no servidor");
        }
    }

    public async Task<ResultViewModel<bool>> Deleteuser(int id)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return new ResultViewModel<bool>("Conteúdo não encontrado");



            _context.Remove(user);
            _context.SaveChanges();
            return new ResultViewModel<bool>(true);

        }
        catch
        {
            return new ResultViewModel<bool>("Falha interna no servidor");
        }
    }
}

