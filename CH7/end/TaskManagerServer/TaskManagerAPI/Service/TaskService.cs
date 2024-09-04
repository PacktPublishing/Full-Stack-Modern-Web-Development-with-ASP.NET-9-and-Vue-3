using TaskManagerAPI.Domain.Models;
using TaskManagerAPI.Infrastructure.Context;
using TaskManagerAPI.Infrastructure.Interfaces;
using TaskManagerAPI.Service.Interfaces;

namespace TaskManagerAPI.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITasksRepository _tasksRepository;

        public TaskService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<UserTaskDto> GetTask(int id)
        {
            UserTask task = await _tasksRepository.SelectTask(id);

            UserTaskDto response = new UserTaskDto
            {
                Id = task.Id,
                Name = task.Name,
                DueDate = task.DueDate,
                IsDone = task.IsDone,
            };

            return response;
        }

        public async Task<UserTaskDto> CreateTask(UserTaskDto newTask)
        {
            UserTask taskToBeCreated = new UserTask
            {
                Name = newTask.Name,
                UserId = 1,
                DueDate = newTask.DueDate,
                IsDone = newTask.IsDone,
            };

            taskToBeCreated.SetCreationDate();

            UserTask task = await _tasksRepository.CreateTask(taskToBeCreated);

            UserTaskDto response = new UserTaskDto
            {
                Id = task.Id,
                Name = task.Name,
                DueDate = task.DueDate,
                IsDone = task.IsDone,
            };

            return response;
        }

        public async Task<UserTaskDto> UpdateTask(UserTaskDto taskToBeUpdated)
        {
            UserTask task = new UserTask
            {
                Id = taskToBeUpdated.Id,
                Name = taskToBeUpdated.Name,
                UserId = 1,
                DueDate = taskToBeUpdated.DueDate,
                IsDone = taskToBeUpdated.IsDone,
            };

            UserTask updatedTask = await _tasksRepository.UpdateTask(task);

            UserTaskDto response = new UserTaskDto
            {
                Id = updatedTask.Id,
                Name = updatedTask.Name,
                DueDate = updatedTask.DueDate,
                IsDone = updatedTask.IsDone,
            };

            return response;
        }

        public async Task DeleteTask(int id)
        {
            await _tasksRepository.DeleteTask(id);
        }
    }
}
