namespace PracticeAPI.Models.Entities
{
    public class User
    {
        public int userId { get; set; }
        public required string username { get; set; }
        public string hashedPassword { get; set; }
    }
}
