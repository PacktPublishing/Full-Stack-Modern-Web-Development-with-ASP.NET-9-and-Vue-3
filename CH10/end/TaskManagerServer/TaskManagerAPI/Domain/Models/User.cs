namespace TaskManagerAPI.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
    }
}
