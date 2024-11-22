namespace TaskManagerAPI.Domain.Dtos
{
    public class UserTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
    }
}
