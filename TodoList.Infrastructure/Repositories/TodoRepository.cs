using Microsoft.EntityFrameworkCore;
using TodoList.Core.Entities;

namespace TodoList.Infrastructure.Repositories;

public class TodoRepository(AppDbContext context)
{
    public async Task<Todo> AddTodoAsync(Todo todo)
    {
        context.Todos.Add(todo);           // Task in den DbSet einfügen
        await context.SaveChangesAsync();  // Änderungen in die Datenbank schreiben
        return todo;                        // Rückgabe des gespeicherten Todos
    }

    public async Task<List<Todo>> GetAllTodosAsync()
    {
        return await context.Todos.ToListAsync();
    }

    public async Task<Todo?> GetTodoByIdAsync(Guid id)
    {
        return await context.Todos.FindAsync(id);
    }

    public async Task<Todo?> UpdateTodoStatusAsync(Guid id, TodoStatus status, CancellationToken cancellationToken = default)
    {
        var todo = await context.Todos.FindAsync([id], cancellationToken);
        if (todo is null)
        {
            throw new KeyNotFoundException($"Todo with ID {id} not found.");
        }

        todo.SetStatus(status);
        await context.SaveChangesAsync(cancellationToken);

        return todo;
    }
}