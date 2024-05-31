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
        public ActionResult<UserTaskDto> GetTask(int taskId)
        {
            UserTaskDto response = _taskService.GetTask(taskId);
            
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateTask")]
        public ActionResult<UserTaskDto> CreateTask(UserTaskDto newTask)
        {
            UserTaskDto response = _taskService.CreateTask(newTask);

            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateTask")]
        public ActionResult<UserTaskDto> UpdateTask(UserTaskDto taskToBeUpdated)
        {
            UserTaskDto response = _taskService.UpdateTask(taskToBeUpdated);

            return Ok(response);
        }

        [HttpDelete]
        [Route("UpdateTask")]
        public ActionResult DeleteTask(int taskId)
        {
            _taskService.DeleteTask(taskId);

            return Ok();
        }
    }
}
