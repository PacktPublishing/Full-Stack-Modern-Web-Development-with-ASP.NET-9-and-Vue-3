using TaskManagerAPI.Domain.Dtos;

namespace TaskManagerAPI.Domain.Interfaces.Services
{
    public interface ITaskService
    {
        Task<UserTaskDto> GetTaskAsync(uint taskId);
        Task<UserTaskDto> CreateTaskAsync(UserTaskDto newTask);
        Task<UserTaskDto> UpdateTaskAsync(UserTaskDto taskToBeUpdated);
        Task DeleteTaskAsync(int taskId);
    }
}
