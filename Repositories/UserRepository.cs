using Microsoft.EntityFrameworkCore;
using TodoAPi.Data;
using TodoAPi.Models;
using TodoAPi.ViewModels;
using TodoAPi.ViewModels.User;
using TodoAPi.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using SecureIdentity.Password;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TodoAPiDataContext _context;
    public UserRepository(TodoAPiDataContext context)
        => _context = context;

    public async Task<ResultViewModel<List<UserViewModel>>> GetUsersAsync()
    {
        try
        {
            var user = await _context.Users

                .AsNoTracking()
                .Select(x => new UserViewModel
                {
                    Name = x.Name,
                    Email = x.Email
                })
                .ToListAsync();
            if (user is null)
                return new ResultViewModel<List<UserViewModel>>("Nenhum usuário registrado");

            return new ResultViewModel<List<UserViewModel>>(user);
        }
        catch
        {

            return new ResultViewModel<List<UserViewModel>>("Falha interna no servidor");
        }
    }

    public async Task<ResultViewModel<UserViewModel>> RegisterUserAsync(UserViewModel model)
    {
        try
        {

            var user = new User { Name = model.Name, Email = "teste" };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return new ResultViewModel<UserViewModel>(model);
        }

        catch (DbUpdateException ex)
        {
            return new ResultViewModel<UserViewModel>("05XE9 - Não foi possível incluir o usuário");
        }

        catch
        {

            return new ResultViewModel<UserViewModel>("Falha interna no servidor");
        }
    }

    public async Task<ResultViewModel<UserViewModel>> UpdateUser(EditorUserViewModel model, string email)
    {


        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
                return new ResultViewModel<UserViewModel>("Usuário não encontrado");

            user.Name = model.Name;
            user.PasswordHash = PasswordHasher.Hash(model.Password);

            _context.Update(user);
            _context.SaveChanges();

            var resultview = new UserViewModel { Name = user.Name, Email = user.Email };
            return new ResultViewModel<UserViewModel>(resultview);

        }
        catch
        {

            return new ResultViewModel<UserViewModel>("Falha interna no servidor");
        }
    }

    public async Task<ResultViewModel<bool>> Deleteuser(string email)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
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

    public ResultViewModel<UserViewModel> RegisterUser(UserRegisterViewModel model)
    {
        try
        {
            // Verificar se o usuário ja existe  
            var UserAlreadyExists = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (UserAlreadyExists != null)
                return new ResultViewModel<UserViewModel>("05XE12 - Email já cadastrado");

            // se nao prossegue na inserção
            var passwordHash = PasswordHasher.Hash(model.PasswordHash);

            var user = new User
            {
                Name = model.Name,

                Email = model.Email,

                PasswordHash = passwordHash
            };

            // Adicionar uma Role(Admin/User) ao usuário
            var role = new UserRole { UserEmail = model.Email, RoleName = "User" };

            _context.UsersRoles.Add(role);
            _context.Users.Add(user);
            _context.SaveChanges();

            var modelReturn = new UserViewModel { Email = model.Email, Name = model.Name };

            return new ResultViewModel<UserViewModel>(modelReturn);
        }

        catch (DbUpdateException ex)
        {
            return new ResultViewModel<UserViewModel>("05XE9 - Não foi possível incluir o usuário");
        }

        catch
        {

            return new ResultViewModel<UserViewModel>("Falha interna no servidor");
        }
    }

    public ResultViewModel<User> UserLogin(LoginUserViewModel model)
    {
        try
        {

            var user = _context.Users
                            .AsNoTracking()
                            .Include(x => x.UserRoles)
                            .FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
                return new ResultViewModel<User>("Senha ou usuário inválido");


            if (!PasswordHasher.Verify(user.PasswordHash, model.Password))
                return new ResultViewModel<User>("Senha ou usuário inválido");



            return new ResultViewModel<User>(user);
        }

        catch (DbUpdateException ex)
        {
            return new ResultViewModel<User>("05XE9 - Não foi possível incluir o usuário");
        }

        catch
        {

            return new ResultViewModel<User>("Falha interna no servidor");
        }
    }

}


