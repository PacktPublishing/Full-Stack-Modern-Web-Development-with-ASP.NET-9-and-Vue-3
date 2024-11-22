using TaskManagerAPI.Domain.Models;

namespace TaskManagerAPI.Domain.Interfaces.Repositories
{
    public interface ITasksRepository
    {
        Task<UserTask> SelectTaskAsync(uint taskId);
        Task<UserTask> CreateTaskAsync(UserTask newTask);
        Task<UserTask> UpdateTaskAsync(UserTask taskToBeUpdated);
        Task DeleteTaskAsync(int taskId);
    }
}
