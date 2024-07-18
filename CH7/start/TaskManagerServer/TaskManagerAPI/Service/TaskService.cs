using TaskManagerAPI.Domain.Models;
using TaskManagerAPI.Service.Interfaces;

namespace TaskManagerAPI.Service
{
    public class TaskService : ITaskService
    {
        public UserTaskDto GetTask(int id)
        {
            throw new NotImplementedException();
        }

        public UserTaskDto CreateTask(UserTaskDto newTask)
        {
            throw new NotImplementedException();
        }

        public UserTaskDto UpdateTask(UserTaskDto taskToBeUpdated)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
