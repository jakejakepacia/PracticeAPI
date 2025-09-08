namespace PracticeAPI.Models.Entities
{
    public class User
    {
        public int userid { get; set; }
        public required string username { get; set; }
        public string hashedpassword { get; set; }
    }
}
