using TaskManagerAPI.Domain.Models;

namespace TaskManagerAPI.Infrastructure.Interfaces
{
    public interface ITasksRepository
    {
        Task<UserTask> SelectTask(int taskId);
        Task<UserTask> CreateTask(UserTask newTask);
        Task<UserTask> UpdateTask(UserTask taskToBeUpdated);
        Task DeleteTask(int taskId);
    }
}
