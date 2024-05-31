<script setup>
import '@mdi/font/css/materialdesignicons.css'
import { ref } from 'vue';
import { useTaskManagerStore } from '../stores/TaskManagerStore';

const taskStore = useTaskManagerStore();

const user = ref(taskStore.userName);

const tasks = ref(taskStore.tasks);

const deleteTask = (task) => {
  const taskIndex = tasks.value.findIndex(t => t === task)
  taskStore.deleteTask(taskIndex);
};

const changeTaskStatus = (task) => {
  taskStore.changeTaskStatus(task.name);
}

const updateTask = (task) => {
};

</script>

<template>
  <v-app class="display: flex; justify-content: center;"> 
    <v-main>
      <v-card variant="elevated">
        <div class="header-div">
          <v-card-title>Welcome, {{ user }}!</v-card-title>
          <v-card-subtitle>You can add, edit or delete items in your task list using the action buttons.</v-card-subtitle>
        </div>
        <v-card-text>
          <v-table>
            <thead>
              <tr>
                <th class="text-center">
                  Name
                </th>
                <th class="text-center">
                  Due Date
                </th>
                <th class="text-center">
                  Done
                </th>
                <th class="text-center">
                  Actions
                </th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="task in tasks"
                :key="task.name"
              >
                <td>{{ task.name }}</td>
                <td>{{ task.due_date }}</td>
                <td>
                  <v-icon v-if="task.is_done" @click="changeTaskStatus(task)">mdi-check</v-icon>
                  <v-icon v-if="!task.is_done" @click="changeTaskStatus(task)">mdi-close</v-icon>
                </td>
                <td>
                  <v-btn color="warning" variant="plain" @click="updateTask(task)" icon>
                    <v-icon>mdi-pencil</v-icon>
                  </v-btn>
                  <v-btn color="error" variant="plain" @click="deleteTask(task)" icon>
                    <v-icon>mdi-delete</v-icon>
                  </v-btn>
                </td>
              </tr>
            </tbody>
          </v-table>
          <v-card-actions class="action-wrapper">
            <v-btn @click="redirectToAnotherPage" color="#2596be" variant="outlined">Create new Task</v-btn>
          </v-card-actions>
        </v-card-text>
      </v-card>
    </v-main>
  </v-app>
</template>

<style scoped>

.background-card {
  background-color: #f0f0f0;
  padding: 20px;
  border-radius: 10px;
  margin-bottom: 20px;
}

.v-main {
  display: flex;
  justify-content: center;
  align-items: center;
}

.action-wrapper {
  justify-content: end;
}

.header-div {
  background-color: #2596be;
  padding-bottom: 1rem;
  color: white;
}
</style>
