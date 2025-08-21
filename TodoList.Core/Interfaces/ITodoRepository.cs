using TodoList.Core.Entities;

namespace TodoList.Core.Interfaces;

public interface ITodoRepository
{
    Task<Todo> AddTodoAsync();
}