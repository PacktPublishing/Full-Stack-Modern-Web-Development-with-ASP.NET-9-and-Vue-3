<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const name = ref('');
const router = useRouter();

const clearInput = () => {
  name.value = '';
};

const redirectToAnotherPage = () => {
  router.push('/another-page');
};
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
            <v-text-field v-model="name" color="primary" label="Name"></v-text-field>
            <p>{{ name }}</p>
            <v-card-actions class="action-wrapper">
            <v-btn @click="clearInput" color="#2596be" variant="outlined">Refresh</v-btn>
            <v-btn @click="redirectToAnotherPage" color="#5cb85c" variant="outlined">Proceed</v-btn>
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
