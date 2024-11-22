using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Domain.Models;
using TaskManagerAPI.Service.Interfaces;

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
        public async Task<ActionResult<UserTaskDto>> GetTask(int taskId)
        {
            UserTaskDto response = await _taskService.GetTask(taskId);
            
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task<ActionResult<UserTaskDto>> CreateTask(UserTaskDto newTask)
        {
            UserTaskDto response = await _taskService.CreateTask(newTask);

            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateTask")]
        public async Task<ActionResult<UserTaskDto>> UpdateTask(UserTaskDto taskToBeUpdated)
        {
            UserTaskDto response = await _taskService.UpdateTask(taskToBeUpdated);

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteTask")]
        public async Task<ActionResult> DeleteTask(int taskId)
        {
            await _taskService.DeleteTask(taskId);

            return Ok();
        }
    }
}
