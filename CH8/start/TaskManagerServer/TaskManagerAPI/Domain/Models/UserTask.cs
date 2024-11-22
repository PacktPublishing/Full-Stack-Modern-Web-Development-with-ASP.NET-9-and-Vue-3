namespace TaskManagerAPI.Domain.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
        public void SetCreationDate()
        {
            this.CreationDate = DateTime.UtcNow;
        }
    }
}
