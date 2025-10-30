import axios from "axios";
import { Task } from "./types/Task";

// ✅ Backend Base URL
const API_URL = "http://localhost:5120/api/tasks";

export const getTasks = () => axios.get<Task[]>(API_URL);
export const addTask = (task: { title: string; description: string }) =>
  axios.post(API_URL, task);


export const toggleTask = (id: number, isCompleted: boolean) =>
  axios.put(`${API_URL}/${id}`, { isCompleted });


export const deleteTask = (id: number) =>
  axios.delete(`${API_URL}/${id}`);

