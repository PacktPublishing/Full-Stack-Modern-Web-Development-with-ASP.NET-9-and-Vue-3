import { createRouter, createWebHistory } from 'vue-router'
import WelcomeComponent from '../components/WelcomeComponent.vue'
import TaskManagerComponent from '../components/TaskManagerComponent.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: WelcomeComponent
    },
    {
      path: '/task-manager',
      name: 'task-manager',
      component: TaskManagerComponent
    }
  ]
})

export default router
