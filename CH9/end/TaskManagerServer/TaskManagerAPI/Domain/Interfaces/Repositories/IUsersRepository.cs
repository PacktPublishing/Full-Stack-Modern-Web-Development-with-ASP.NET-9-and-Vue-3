using TaskManagerAPI.Domain.Models;

namespace TaskManagerAPI.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<User> SelectUserByNameAsync(string userName);
        Task<User> SelectUserWithTasksAsync(int userId);
        Task<User> CreateUserAsync(User newUser);
        Task<User> UpdateUserAsync(User userToBeUpdated);
        Task DeleteUserAsync(int userId);
    }
}
