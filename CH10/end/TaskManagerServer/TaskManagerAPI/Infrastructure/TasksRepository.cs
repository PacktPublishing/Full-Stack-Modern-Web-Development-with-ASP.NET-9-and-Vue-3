using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Domain.Interfaces.Repositories;
using TaskManagerAPI.Domain.Models;
using TaskManagerAPI.Infrastructure.Context;

namespace TaskManagerAPI.Infrastructure
{
    public class TasksRepository : ITasksRepository
    {
        private readonly AppDbContext _dbContext;

        public TasksRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserTask> SelectTaskAsync(uint taskId)
        {
            
            try
            {
                UserTask? result = await _dbContext.UserTasks.Where(task => task.Id == taskId).FirstOrDefaultAsync();

                if (result is not null) return result;

                throw new Exception($"Task with ID {taskId} was not found.");
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<UserTask> CreateTaskAsync(UserTask newTask)
        {
            try
            {
                _dbContext.UserTasks.Add(newTask);

                await _dbContext.SaveChangesAsync();

                return newTask;
            }
            catch (Exception e)
            {
                throw new Exception("Error creating task: " + e);
            }
        }

        public async Task<UserTask> UpdateTaskAsync(UserTask updatedTask)
        {
            try
            {
                UserTask? existingTask = await _dbContext.UserTasks.Where(task => task.Id == updatedTask.Id).FirstOrDefaultAsync();

                if (existingTask is not null)
                {
                    existingTask.Name = updatedTask.Name;
                    existingTask.UserId = updatedTask.UserId;
                    existingTask.DueDate = updatedTask.DueDate;

                    await _dbContext.SaveChangesAsync();

                    return existingTask;
                }

                throw new Exception($"Task with ID {updatedTask.Id} not found.");
            }
            catch (Exception e)
            {
                throw new Exception("Error updating task", e);
            }
        }


        public async Task DeleteTaskAsync(int taskId)
        {
            try
            {
                UserTask? taskToDelete = await _dbContext.UserTasks.FindAsync(taskId);

                if (taskToDelete is not null)
                {
                    _dbContext.UserTasks.Remove(taskToDelete);

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Task with ID {taskId} not found.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error deleting task: " + e);
            }
        }
    }
}
