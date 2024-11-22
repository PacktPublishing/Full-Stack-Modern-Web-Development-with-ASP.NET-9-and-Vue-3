// src/store/index.ts
import { defineStore } from 'pinia';

export const useTaskManagerStore = defineStore({
  id: 'task',
  state: () => ({
    userName: '',
    tasks: [
      { name: 'Finish Vue 3 book', due_date: '2024-03-27', is_done: false },
      { name: 'Grocery Shopping', due_date: '2024-03-28', is_done: true },
    ],
  }),
  actions: {
    addTask(newTask) {
      this.tasks.push(newTask);
    },
    deleteTask(taskIndex) {
      this.tasks.splice(taskIndex, 1);
    },
    changeTaskStatus(taskName) {
      const foundTask = this.tasks.find(task => task.name == taskName);
      foundTask.is_done = !foundTask.is_done;
    },
    setUserName(username) { 
      this.userName = username; 
    }, 
  },
});
