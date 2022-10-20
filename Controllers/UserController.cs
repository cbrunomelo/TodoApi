using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoAPi.Externsions;
using TodoAPi.Repositories.Contracts;
using TodoAPi.Services;
using TodoAPi.ViewModels;
using TodoAPi.ViewModels.User;

namespace TodoAPi.Controllers;

[ApiController]

public class UserController : ControllerBase
{


    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {

        _userRepository = userRepository;
    }


    /// <summary>
    /// Todos os usuários registrados - (Apenas Admin)
    /// </summary>
    [Authorize(Roles = "Admin")]
    [HttpGet("v1/users/")]
    public async Task<ActionResult<ResultViewModel<UserViewModel>>> GetUser()
    {

        var users = await _userRepository.GetUsersAsync();
        if (users.Errors.Count() != 0)
            return StatusCode(400, users);
        return Ok(users);
    }


    /// <summary>
    /// Atualizar Nome e Mudar senha - (Precisa estar logado)
    /// </summary>
    [Authorize(Roles = "User")]
    [HttpPut("v1/users/")]
    public async Task<ActionResult<ResultViewModel<UserViewModel>>> UpdateUser(
        [FromBody] EditorUserViewModel model
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<UserViewModel>(ModelState.GetErrors()));


        var UserEmail = User.Identity!.Name;
        var userUpdate = await _userRepository.UpdateUser(model, UserEmail);
        if (userUpdate.Errors.Count() != 0)
            return StatusCode(400, userUpdate);


        return Ok(userUpdate);
    }

    /// <summary>
    /// Deletar um usuário pelo Email dele - (Apenas Admin)
    /// </summary>
    [Authorize(Roles = "Admin")]
    [HttpDelete("v1/users/")]
    public async Task<ActionResult<ResultViewModel<bool>>> DeleteUser(
        string email
        )
    {
        var UserRemove = await _userRepository.Deleteuser(email);

        if (UserRemove.Errors.Count() != 0)
            return StatusCode(400, UserRemove);


        return Ok(UserRemove);
    }

    /// <summary>
    /// Login - Após logar receberá um token onde deve inserir no Authorize para conseguir usar outros end-points
    /// </summary>
    [HttpPost("v1/Login")]
    public IActionResult Login(
        [FromServices] TokenService tokenService,
        [FromBody] LoginUserViewModel model
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<UserViewModel>(ModelState.GetErrors()));


        var user = _userRepository.UserLogin(model);
        if (user.Errors.Count() != 0)
            return StatusCode(400, user);

        var token = tokenService.GenerateToken(user.Data);
        return Ok(token);
    }


    /// <summary>
    /// Novo usuário - (Um Email -> Um Usuário)
    /// </summary>
    [HttpPost("v1/users/")]
    public ActionResult<ResultViewModel<UserViewModel>> UserRegister(
        [FromBody] UserRegisterViewModel model
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<UserViewModel>(ModelState.GetErrors()));

        var UserRegister = _userRepository.RegisterUser(model);


        if (UserRegister.Errors.Count() != 0)
            return StatusCode(400, UserRegister);

        return StatusCode(201, UserRegister);
    }


}
