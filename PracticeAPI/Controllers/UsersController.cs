using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PracticeAPI.Data;
using PracticeAPI.Models;
using PracticeAPI.Models.Api;
using PracticeAPI.Models.Entities;
using PracticeAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly RegisterService _registerService;

        public UsersController(JwtService jwtService, RegisterService registerService)
        {
            _jwtService = jwtService;
            _registerService = registerService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel request) {
           var result = await _jwtService.Authenticate(request);

            if (result == null)
                return Unauthorized();

            return result;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterUserRequestModel request)
        {
            var result = _registerService.RegisterUser(request);

            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok(result.Message);
        }

        [HttpGet("test-db-connection")]
        public async Task<IActionResult> TestDbConnection([FromServices] ApplicationDBContext context)
        {
            try
            {
                await context.Database.OpenConnectionAsync();
                await context.Database.CloseConnectionAsync();
                return Ok("DB connection works!");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
