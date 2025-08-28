using Microsoft.AspNetCore.Identity;
using PracticeAPI.Data;
using PracticeAPI.Models.Api;
using PracticeAPI.Models.Entities;

namespace PracticeAPI.Services
{
    public class RegisterService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly PasswordHasher<User> _passwordHasher;
        public RegisterService(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            _passwordHasher = new PasswordHasher<User>();
        }

        public OperationResult RegisterUser(RegisterUserRequestModel model)
        {
            var userExist = CheckUsernameIfTaken(model.Username);
            if (userExist)
                return OperationResult.FailureResult(new List<string> { "Username already taken" });

            var newUser = new User{
                Username= model.Username
            };

            newUser.HashedPassword = _passwordHasher.HashPassword(newUser, model.Password);


            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();


            return OperationResult.SuccessResult("User registered successfully");
        }

        private bool CheckUsernameIfTaken(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);

           return user != null;
        }
    }
}
