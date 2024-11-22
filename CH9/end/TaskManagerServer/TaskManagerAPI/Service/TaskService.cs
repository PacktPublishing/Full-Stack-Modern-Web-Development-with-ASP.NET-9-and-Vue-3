using TaskManagerAPI.Domain.Dtos;
using TaskManagerAPI.Domain.Interfaces.Repositories;
using TaskManagerAPI.Domain.Interfaces.Services;
using TaskManagerAPI.Domain.Models;

namespace TaskManagerAPI.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITasksRepository _tasksRepository;

        public TaskService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<UserTaskDto> GetTaskAsync(uint id)
        {
            UserTask task = await _tasksRepository.SelectTaskAsync(id);

            UserTaskDto response = new UserTaskDto
            {
                Id = task.Id,
                Name = task.Name,
                DueDate = task.DueDate,
                IsDone = task.IsDone,
            };

            return response;
        }

        public async Task<UserTaskDto> CreateTaskAsync(UserTaskDto newTask)
        {
            UserTask taskToBeCreated = new UserTask
            {
                Name = newTask.Name,
                UserId = 1,
                DueDate = newTask.DueDate,
                IsDone = newTask.IsDone,
            };

            taskToBeCreated.SetCreationDate();

            try
            {
                UserTask task = await _tasksRepository.CreateTaskAsync(taskToBeCreated);

                UserTaskDto response = new UserTaskDto
                {
                    Id = task.Id,
                    Name = task.Name,
                    DueDate = task.DueDate,
                    IsDone = task.IsDone,
                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<UserTaskDto> UpdateTaskAsync(UserTaskDto taskToBeUpdated)
        {
            UserTask task = new UserTask()
            {
                Id = taskToBeUpdated.Id,
                Name = taskToBeUpdated.Name,
                UserId = 1,
                DueDate = taskToBeUpdated.DueDate,
                IsDone = taskToBeUpdated.IsDone,
            };

            try
            {
                UserTask updatedTask = await _tasksRepository.UpdateTaskAsync(task);

                UserTaskDto response = new UserTaskDto
                {
                    Id = updatedTask.Id,
                    Name = updatedTask.Name,
                    DueDate = updatedTask.DueDate,
                    IsDone = updatedTask.IsDone,
                };

                return response;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _tasksRepository.DeleteTaskAsync(id);
        }
    }
}
