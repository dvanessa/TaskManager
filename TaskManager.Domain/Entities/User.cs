namespace TaskManager.Domain.Entities
{
    public class User
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = ""; // Solo para demo, idealmente usar hashing
    }
}