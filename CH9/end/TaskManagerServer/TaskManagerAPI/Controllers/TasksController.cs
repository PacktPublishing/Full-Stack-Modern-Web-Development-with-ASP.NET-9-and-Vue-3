using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Domain.Dtos;
using TaskManagerAPI.Domain.Interfaces.Services;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("GetTask")]
        public async Task<ActionResult<UserTaskDto>> GetTask(uint taskId)
        {
            UserTaskDto response = await _taskService.GetTaskAsync(taskId);
            
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task<ActionResult<UserTaskDto>> CreateTask(UserTaskDto newTask)
        {
            UserTaskDto response = await _taskService.CreateTaskAsync(newTask);

            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateTask")]
        public async Task<ActionResult<UserTaskDto>> UpdateTask(UserTaskDto taskToBeUpdated)
        {
            UserTaskDto response = await _taskService.UpdateTaskAsync(taskToBeUpdated);

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteTask")]
        public async Task<ActionResult> DeleteTask(int taskId)
        {
            await _taskService.DeleteTaskAsync(taskId);

            return Ok();
        }
    }
}
