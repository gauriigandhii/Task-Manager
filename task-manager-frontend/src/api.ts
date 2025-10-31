import axios from "axios";
import { Task } from "./types/Task";

const API_URL = "https://task-manager-2-qi6m.onrender.com/api/tasks";

export const getTasks = () => axios.get<Task[]>(API_URL);

export const addTask = (task: { title: string; description: string }) =>
  axios.post(API_URL, task);

export const toggleTask = (id: number, isCompleted: boolean) =>
  axios.put(`${API_URL}/${id}`, { isCompleted });

export const deleteTask = (id: number) =>
  axios.delete(`${API_URL}/${id}`);


