using TaskManagerAPI.Domain.Dtos;

namespace TaskManagerAPI.Domain.Interfaces.Services
{
    public interface IUsersService
    {
        Task<LoginResponseDto> Login(LoginDto payload);
        Task<UserDto> GetUserAsync(int userId);
        Task<UserDto> CreateUserAsync(LoginDto newUser);
        Task<UserDto> UpdateUserAsync(UserDto userToBeUpdated);
        Task DeleteUserAsync(int userId);
    }
}
