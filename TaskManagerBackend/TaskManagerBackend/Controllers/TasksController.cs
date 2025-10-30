using Microsoft.AspNetCore.Mvc;
using TaskManagerBackend.Models;
using TaskManagerBackend.Services;

namespace TaskManagerBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TasksController : ControllerBase
  {
    private readonly ITaskRepository _repo;

    public TasksController(ITaskRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_repo.GetAll());

    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
      _repo.Add(task);
      return CreatedAtAction(nameof(GetAll), task);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, TaskItem task)
    {
      task.Id = id;
      _repo.Update(task);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
      _repo.Delete(id);
      return NoContent();
    }
  }
}
