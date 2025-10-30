using TaskManagerBackend.Models;

namespace TaskManagerBackend.Services
{
  public class InMemoryTaskRepository : ITaskRepository
  {
    private readonly List<TaskItem> _tasks = new();

    public IEnumerable<TaskItem> GetAll() => _tasks;

    public TaskItem? Get(Guid id) => _tasks.FirstOrDefault(t => t.Id == id);

    public void Add(TaskItem task) => _tasks.Add(task);

    public void Update(TaskItem task)
    {
      var existing = Get(task.Id);
      if (existing != null)
      {
        existing.Description = task.Description;
        existing.IsCompleted = task.IsCompleted;
      }
    }

    public void Delete(Guid id)
    {
      var task = Get(id);
      if (task != null)
        _tasks.Remove(task);
    }
  }
}
