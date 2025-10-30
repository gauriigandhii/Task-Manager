using TaskManagerBackend.Models;

namespace TaskManagerBackend.Services
{
  public interface ITaskRepository
  {
    IEnumerable<TaskItem> GetAll();
    TaskItem? Get(Guid id);
    void Add(TaskItem task);
    void Update(TaskItem task);
    void Delete(Guid id);
  }
}
