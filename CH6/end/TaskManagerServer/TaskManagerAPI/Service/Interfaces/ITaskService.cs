using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Domain.Models;

namespace TaskManagerAPI.Service.Interfaces
{
    public interface ITaskService
    {
        UserTaskDto GetTask(int taskId);
        UserTaskDto CreateTask(UserTaskDto newTask);
        UserTaskDto UpdateTask(UserTaskDto taskToBeUpdated);
        void DeleteTask(int taskId);
    }
}
