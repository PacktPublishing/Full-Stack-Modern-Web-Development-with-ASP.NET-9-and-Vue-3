<script setup>
import { ref, computed } from 'vue';
import { useRouter } from 'vue-router';
import { useTaskManagerStore } from '../stores/TaskManagerStore';

const taskStore = useTaskManagerStore();

const name = ref('');
const router = useRouter();

const clearInput = () => {
  name.value = '';
};

const redirectToAnotherPage = () => {
  taskStore.setUserName(name.value);
  router.push('/task-manager');
};

const isNameValid = computed(() => name.value.length > 0 && name.value.length <= 50);
</script>

<template>
  <v-app class="display: flex; justify-content: center;"> 
    <v-main>
        <v-card variant="elevated">
        <div class="header-div">
          <v-card-title>Task Manager</v-card-title>
          <v-card-subtitle>Welcome to the task manager application! Please, inform your name so we can proceed:</v-card-subtitle>
        </div>
          <v-card-text>
            <v-text-field v-model="name" color="primary" label="Name" required maxlength="50"></v-text-field>
              <p v-if="name && name.length > 50">
                Name must be less than 50 characters long.
              </p>
              <p v-else-if="!name">
                Name is required.
              </p>
            <v-card-actions class="action-wrapper">
            <v-btn @click="clearInput" color="#2596be" variant="outlined">Refresh</v-btn>
            <v-btn :disabled="!isNameValid" @click="redirectToAnotherPage" color="#5cb85c" variant="outlined">Proceed</v-btn>
            </v-card-actions>
          </v-card-text>
        </v-card>
    </v-main>
  </v-app>
</template>


<style scoped>
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
