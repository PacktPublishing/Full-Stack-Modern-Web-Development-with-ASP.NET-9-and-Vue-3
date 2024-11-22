namespace TaskManagerAPI.Domain.Dtos
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; } = new UserDto();
        public string token { get; set; } = string.Empty;
    }
}
