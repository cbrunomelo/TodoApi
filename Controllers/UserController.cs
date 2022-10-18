using Microsoft.AspNetCore.Mvc;
using TodoAPi.Externsions;
using TodoAPi.Repositories.Contracts;
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
    /// Todos os usuários registrados
    /// </summary>
    [HttpGet("v1/users/")]
    public async Task<ActionResult<ResultViewModel<EditorUserViewModel>>> GetUser()
    {
        var users = await _userRepository.GetUsersAsync();
        return Ok(users);
    }

    /// <summary>
    /// Novo usuário
    /// </summary>
    [HttpPost("v1/users/")]

    public async Task<ActionResult<ResultViewModel<EditorUserViewModel>>> PostUser(
        [FromBody] EditorUserViewModel model
    )

    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<EditorUserViewModel>(ModelState.GetErrors()));


        var NewUser = await _userRepository.RegisterUserAsync(model);
        return Created($"v1/users/{NewUser.Data.Name}", NewUser);



    }


    /// <summary>
    /// Atualizar nome do usuário pelo Id
    /// </summary>
    [HttpPut("v1/users/{id:int}")]
    public async Task<ActionResult<ResultViewModel<EditorUserViewModel>>> UpdateUser(
        [FromRoute] int id,
        [FromBody] EditorUserViewModel model
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<EditorUserViewModel>(ModelState.GetErrors()));


        var userUpdate = await _userRepository.UpdateUserNameAsync(model, id);
        return Created($"v1/users/{id}", userUpdate);
    }

    /// <summary>
    /// Deletar um usuário pelo Id
    /// </summary>
    [HttpDelete("v1/users/{id:int}")]
    public async Task<ActionResult<ResultViewModel<bool>>> DeleteUser(
        [FromRoute] int id

    )
    {
        var UserRemove = await _userRepository.Deleteuser(id);
        return Ok(UserRemove);
    }
}
