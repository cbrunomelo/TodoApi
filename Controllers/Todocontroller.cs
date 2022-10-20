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
public class TodoController : ControllerBase
{

    private readonly ITodoRepository _todoRepository;
    public TodoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }



    // GET: api/<TodoController>
    /// <summary>
    /// Todas as tarefas de um usuário
    /// </summary>

    /// <returns>Retorna uma lista das Tarefas encontradas de um usuário</returns>
    ///<response code="200">Retorna uma Lista das tarefas do usuário em Data: , se não Data virá vazia e em Erros: Uma lista de erros</response>
    [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]

    [HttpGet("v1/users/todos/{id:int}")]
    public async Task<ActionResult<ResultViewModel<List<TodoViewModel>>>> GetTodos(
        [FromRoute] string email
    )
    {
        var UserTodos = await _todoRepository.GetAllTodosFromAUser(email);
        return Ok(UserTodos);

    }

    /// <summary>
    /// Registrar Nova tarefa para um usuário
    /// </summary>

    /// <returns>Registra uma Nova tarefa</returns>
    ///<response code="200">Retorna uma Lista das tarefas do usuário em Data, se não Data virá vazia e em Erros: Uma lista de erros</response>
    [HttpPost("v1/users/todos")]

    public async Task<ActionResult<ResultViewModel<TodoViewModel>>> PostTodos(
        [FromBody] EditorTodoViewModel model
    )
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<TodoViewModel>(ModelState.GetErrors()));

        var newTodo = await _todoRepository.RegisterTodoAsync(model);

        return Created($"v1/users/todos/{model.Email}", newTodo);

    }
    /// <summary>
    /// Deletar a tarefa de um usuário
    /// </summary>
    [HttpDelete("v1/users/todos/{id:int}")]
    public async Task<IActionResult> DeleteTodo(
       [FromRoute] string email,
       [FromBody] EditorTodoViewModel model
   )
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<User>(ModelState.GetErrors()));

        var DeleteUser = await _todoRepository.DeleteATodoFromAUser(model, email);
        return Ok(DeleteUser);

    }


    /// <summary>
    /// Atualizar a conclusão da tarefa de um usuário
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

        var TodoUpdate = await _todoRepository.UpdateStatusTodoFromAUser(model);
        return Created($"v1/users/{model.Email}", TodoUpdate);
    }

}

