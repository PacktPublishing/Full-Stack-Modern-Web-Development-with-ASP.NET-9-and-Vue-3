using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Domain.Interfaces.Repositories;
using TaskManagerAPI.Domain.Models;
using TaskManagerAPI.Infrastructure.Context;

namespace TaskManagerAPI.Infrastructure
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _dbContext;

        public UsersRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> SelectUserByNameAsync(string userName)
        {

            try
            {
                User? result = await _dbContext.Users.Where(user => user.Name == userName)
                    .SingleOrDefaultAsync();

                if (result is not null) return result;

                throw new Exception($"User with name {userName} was not found.");
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting user with name {userName}: " + e);
            }
        }

        public async Task<User> SelectUserWithTasksAsync(int userId)
        {
            
            try
            {
                User? result = await _dbContext.Users.Where(user => user.Id == userId)
                    .Include(user => user.UserTasks)
                    .FirstOrDefaultAsync();

                if (result is not null) return result;

                throw new Exception($"User with ID {userId} was not found.");
            }
            catch(Exception e)
            {
                throw new Exception($"Error getting user with ID {userId}: " + e);
            }
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            try
            {
                var result = await SelectUserByNameAsync(newUser.Name);

                if (result is null)
                {
                    _dbContext.Users.Add(newUser);

                    await _dbContext.SaveChangesAsync();

                    return newUser;
                }

                throw new Exception("User already exists");
            }
            catch (Exception e)
            {
                throw new Exception("Error creating user: " + e);
            }
        }

        public async Task<User> UpdateUserAsync(User userToBeUpdated)
        {
            try
            {
                User? existingUser = await _dbContext.Users.Where(user => user.Id == userToBeUpdated.Id).FirstOrDefaultAsync();

                if (existingUser is not null)
                {
                    existingUser.Name = userToBeUpdated.Name;

                    await _dbContext.SaveChangesAsync();

                    return existingUser;
                }

                throw new Exception($"User with ID {userToBeUpdated.Id} not found.");
            }
            catch (Exception e)
            {
                throw new Exception("Error updating user: " + e);
            }
        }


        public async Task DeleteUserAsync(int userId)
        {
            try
            {
                User? userToDelete = await _dbContext.Users.FindAsync(userId);

                if (userToDelete is not null)
                {
                    _dbContext.Users.Remove(userToDelete);

                    await _dbContext.SaveChangesAsync();
                }

                throw new Exception($"User with ID {userId} not found.");
            }
            catch (Exception e)
            {
                throw new Exception("Error deleting user: " + e);
            }
        }
    }
}
