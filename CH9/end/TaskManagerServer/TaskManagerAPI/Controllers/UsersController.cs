using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Domain.Dtos;
using TaskManagerAPI.Domain.Interfaces.Services;

namespace TaskManagerAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginDto payload)
        {
            LoginResponseDto response = await _usersService.Login(payload);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<ActionResult<UserDto>> GetUser(int userId)
        {
            UserDto response = await _usersService.GetUserAsync(userId);
            
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<UserDto>> CreateTask(LoginDto newUser)
        {
            UserDto response = await _usersService.CreateUserAsync(newUser);

            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult<UserDto>> UpdateTask(UserDto taskToBeUpdated)
        {
            UserDto response = await _usersService.UpdateUserAsync(taskToBeUpdated);

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            await _usersService.DeleteUserAsync(userId);

            return Ok();
        }
    }
}
