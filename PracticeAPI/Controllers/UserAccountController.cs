using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAPI.Data;
using PracticeAPI.Models.Entities;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserAccountController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public UserAccountController(ApplicationDBContext dBContext) => _dbContext = dBContext;

        [HttpGet("{id}")]
        public async Task<User?> GetUserInfo(int id)
        {
            return await _dbContext.UserAccounts.FirstOrDefaultAsync(x => x.userId == id);
        }
    }
}
