using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoAPi.Data;
using TodoAPi.Externsions;
using TodoAPi.Models;
using TodoAPi.Repositories;
using TodoAPi.Repositories.Contracts;
using TodoAPi.ViewModels;
using TodoAPi.ViewModels.Todo;

namespace TodoAPi.Controllers;

[ApiController]
[Authorize(Roles = "User")]
public class TodoController : ControllerBase
{

    private readonly ITodoRepository _todoRepository;
    public TodoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }



    // GET: api/<TodoController>
    /// <summary>
    /// Todas as tarefas de um usuário logado
    /// </summary>

    /// <returns>Retorna uma lista das Tarefas de um usuário logado</returns>
    ///<response code="200">Retorna uma Lista das tarefas do usuário em Data: , se não Data virá vazia e em Erros: Uma lista de erros</response>
    [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]

    [HttpGet("v1/users/todos/")]
    public async Task<ActionResult<ResultViewModel<List<TodoViewModel>>>> GetTodos()
    {
        var useremail = User.Identity!.Name;
        var UserTodos = await _todoRepository.GetAllTodosFromAUser(useremail);

        if (UserTodos.Errors.Count() != 0)
            return StatusCode(404, UserTodos);

        return Ok(UserTodos);

    }


    /// <summary>
    /// Todas as tarefas NÃO concluidas de um usuário logado
    /// </summary>

    /// <returns>Retorna uma lista das Tarefas NÃO concluidas de um usuário logado</returns>
    ///<response code="200">Retorna uma Lista das tarefas do usuário em Data: , se não Data virá vazia e em Erros: Uma lista de erros</response>
    [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]

    [HttpGet("v1/users/todos/unfinished")]
    public async Task<ActionResult<ResultViewModel<List<TodoViewModel>>>> GetUnfinished()
    {
        var useremail = User.Identity!.Name;
        var UserTodos = await _todoRepository.GetUnfinishedTodosFromAUser(useremail);

        if (UserTodos.Errors.Count() != 0)
            return StatusCode(404, UserTodos);

        return Ok(UserTodos);

    }

    /// <summary>
    /// Registrar Nova tarefa para usuário logado
    /// </summary>

    /// <returns>Registrar uma Nova tarefa</returns>
    ///<response code="200">Retorna uma Lista das tarefas do usuário em Data, se não Data virá vazia e em Erros: Uma lista de erros</response>

    [HttpPost("v1/users/todos")]
    public async Task<ActionResult<ResultViewModel<TodoViewModel>>> PostTodos(
        [FromBody] EditorTodoViewModel model
    )
    {
        var userEmail = User.Identity!.Name;
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<TodoViewModel>(ModelState.GetErrors()));

        var newTodo = await _todoRepository.RegisterTodoAsync(model, userEmail);

        return Created($"v1/users/todos/{userEmail}", newTodo);

    }
    /// <summary>
    /// Deletar a tarefa do usuário logado
    /// </summary>

    [HttpDelete("v1/users/todos/")]
    public async Task<IActionResult> DeleteTodo(
              string title
   )
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<User>(ModelState.GetErrors()));

        var userEmail = User.Identity!.Name;

        var DeleteUser = await _todoRepository.DeleteATodoFromAUser(title, userEmail);
        if (DeleteUser.Errors.Count() != 0)
            return StatusCode(404, DeleteUser);

        return Ok(DeleteUser);

    }


    /// <summary>
    /// Atualizar a conclusão da tarefa do usuário logado
    /// </summary>
    /// <returns>Altera a conclusão de uma tarefa do usuário</returns>
    ///<response code="200">Retorna a tarefa alterada</response>

    [HttpPut("v1/users/todos/")]
    public async Task<ActionResult<ResultViewModel<TodoViewModel>>> UpdateTodo(
    [FromBody] EditorTodoViewModel model
)
    {

        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<EditorTodoViewModel>(ModelState.GetErrors()));

        var userEmail = User.Identity!.Name;

        var TodoUpdate = await _todoRepository.UpdateStatusTodoFromAUser(model, userEmail);
        return Created($"v1/users/{userEmail}", TodoUpdate);
    }

}

