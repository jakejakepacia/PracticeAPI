namespace PracticeAPI.Models.Api
{
    public class RegisterUserRequestModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
