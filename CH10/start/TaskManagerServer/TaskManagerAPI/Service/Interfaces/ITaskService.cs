using TaskManagerAPI.Domain.Models;

namespace TaskManagerAPI.Service.Interfaces
{
    public interface ITaskService
    {
        Task<UserTaskDto> GetTask(int taskId);
        Task<UserTaskDto> CreateTask(UserTaskDto newTask);
        Task<UserTaskDto> UpdateTask(UserTaskDto taskToBeUpdated);
        Task DeleteTask(int taskId);
    }
}
