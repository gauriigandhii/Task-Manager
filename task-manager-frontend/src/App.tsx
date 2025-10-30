import { useEffect, useState } from "react";
import { Task } from "./types/Task";
import { getTasks, addTask, toggleTask, deleteTask } from "./api";
import "./App.css";


function App() {
  const [tasks, setTasks] = useState<Task[]>([]);
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");

  const loadTasks = () => {
    getTasks().then((res) => setTasks(res.data));
  };

  useEffect(() => {
    loadTasks();
  }, []);

  const handleAdd = () => {
    if (!title.trim()) return;

    addTask({ title, description }) // ✅ send both now
      .then(() => {
        setTitle("");
        setDescription("");
        loadTasks();
      });
  };

  const handleToggle = (id: number, isCompleted: boolean) => {
    toggleTask(id, isCompleted).then(() => loadTasks());
  };

  const handleDelete = (id: number) => {
    deleteTask(id).then(() => loadTasks());
  };

  return (
    <div className="container p-4">
      <h2 className="text-center mb-4">Task Manager ✅</h2>

      {/* Add Task Form */}
      <div className="mb-3">
        <input
          type="text"
          className="form-control"
          placeholder="Title"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
        />
      </div>

      <div className="mb-3">
        <textarea
          className="form-control"
          placeholder="Description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
        ></textarea>
      </div>

      <button className="btn btn-primary mb-3" onClick={handleAdd}>
        Add Task
      </button>

      {/* List of Tasks */}
      <ul className="list-group">
        {tasks.map((task) => (
          <li
  key={task.id}
  className={`list-group-item d-flex justify-content-between align-items-start flex-column ${
    task.isCompleted ? "task-completed" : ""
  }`}
>
  <div>
    <strong>{task.title}</strong>
    <br />
    <small>{task.description}</small>
  </div>

  <div className="d-flex justify-content-between mt-2 w-100">
    <label className="form-check-label">
      <input
        type="checkbox"
        className="form-check-input me-2"
        checked={task.isCompleted}
        onChange={() => handleToggle(task.id, !task.isCompleted)}
      />
       {task.isCompleted && (
    <span className="badge bg-success ms-2">Completed ✅</span>
  )}
    </label>

    <button
      className="btn btn-danger btn-sm"
      onClick={() => handleDelete(task.id)}
    >
      Delete
    </button>
  </div>
</li>

        ))}
      </ul>
    </div>
  );
}

export default App;
