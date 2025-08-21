using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Entities;
using TodoList.Infrastructure.Repositories;

namespace TodoList.WEB.Controllers;

[ApiController]
[Route($"api/todoOptions")]
public class TodoOptionsController(TodoRepository repository) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateTodo([FromBody] Todo todo)
    {
        var created = await repository.AddTodoAsync(todo);
        return CreatedAtAction(nameof(CreateTodo), new { id = created.Id }, created);
    }

    [HttpPost("updateStatus/{id:Guid}")]
    public async Task<IActionResult> UpdateTodoStatus(Guid id, [FromBody] TodoStatus status)
    {
        var updatedTodo = await repository.UpdateTodoStatusAsync(id, status);
        return Ok(updatedTodo);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTodos()
    {
        var allTodos = await repository.GetAllTodosAsync();
        return Ok(allTodos);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetTodo(Guid id)
    {
        var todo = await repository.GetTodoByIdAsync(id);
        return Ok(todo);
    }
}
