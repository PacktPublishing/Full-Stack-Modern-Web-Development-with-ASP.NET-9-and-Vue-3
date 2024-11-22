using Konscious.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TaskManagerAPI.Domain.Dtos;
using TaskManagerAPI.Domain.Interfaces.Repositories;
using TaskManagerAPI.Domain.Interfaces.Services;
using TaskManagerAPI.Domain.Models;

namespace TaskManagerAPI.Service
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly string _jwtSecurityKey;

        public UsersService(IConfiguration configuration, IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _jwtSecurityKey = configuration["JwtSettings:JWT_SECURITY_KEY"];
        }

        public async Task<LoginResponseDto> Login(LoginDto payload)
        {
            try
            {
                var user = await _usersRepository.SelectUserByNameAsync(payload.Name);

                if (user is not null && AreCredentialsValid(payload.Password, user))
                {
                    UserDto userDto = new UserDto()
                    {
                        Id = user.Id,
                        Name = user.Name,
                    };

                    return new LoginResponseDto
                    {
                        User = userDto,
                        token = GenerateJwtToken(user),
                    };
                }
                throw new UnauthorizedAccessException();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserDto> GetUserAsync(int userId)
        {
            try
            {
                User user = await _usersRepository.SelectUserWithTasksAsync(userId);

                UserDto response = new UserDto()
                {
                    Id = user.Id,
                    Name = user.Name,
                };

                return response;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<UserDto> CreateUserAsync(LoginDto newUser)
        {
            string salt = GenerateSalt();
            string hashedPassword = HashPassword(newUser.Password, salt);

            User userToBeCreated = new User()
            {
                Name = newUser.Name,
                Salt = salt,
                Password = hashedPassword,
            };

            try
            {
                User user = await _usersRepository.CreateUserAsync(userToBeCreated);

                UserDto response = new UserDto()
                {
                    Id = user.Id,
                    Name = user.Name,
                };

                return response;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<UserDto> UpdateUserAsync(UserDto userToBeUpdated)
        {
            User user = new User()
            {
                Id = userToBeUpdated.Id,
                Name = userToBeUpdated.Name,
            };

            try
            {
                User updatedUser = await _usersRepository.UpdateUserAsync(user);

                UserDto response = new UserDto()
                {
                    Id = updatedUser.Id,
                    Name = updatedUser.Name,
                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            try
            {
                await _usersRepository.DeleteUserAsync(userId);
            }
            catch(Exception)
            {
                throw;
            }
        }

        private string GenerateSalt()
        {
            var buffer = new byte[64];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
                return Convert.ToBase64String(buffer);
            } 
        }

        private string HashPassword(string password, string salt)
        {
            var argon2 = new Argon2i(Encoding.UTF8.GetBytes(password))
            {
                DegreeOfParallelism = 16,
                MemorySize = 8192,
                Iterations = 40,
                Salt = Encoding.UTF8.GetBytes(salt)
            };

            var hash = argon2.GetBytes(64);
            return Convert.ToBase64String(hash);
        }

        private string GenerateJwtToken(User user)
        {
            string JWT_SECURITY_KEY = _jwtSecurityKey;
            double expireMins = 10500;
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(expireMins);

            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim("Name", user.Name),
            });

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials,
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }

        private bool AreCredentialsValid(string testPassword, User user)
        {
            var hash = HashPassword(testPassword, user.Salt);
            return hash == user.Password;
        }
    }
}
