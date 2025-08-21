namespace TodoList.Core.Entities;

public class Todo(string title, string description, Guid ownerId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;
    public TodoStatus Status { get; private set; } = TodoStatus.Backlog;
    public Guid OwnerId { get; private set; } = ownerId;

    public void SetStatus(TodoStatus status)
        {
        Status = status;
        }
}