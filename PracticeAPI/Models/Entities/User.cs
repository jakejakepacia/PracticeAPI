namespace PracticeAPI.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public string HashedPassword { get; set; }
    }
}
