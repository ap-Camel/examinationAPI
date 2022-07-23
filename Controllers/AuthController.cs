using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using exmainationApi.Dtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace exmainationApi.Controllers {
    
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase {
        private readonly IUserData userData;
        private readonly IConfiguration config;

        public AuthController(IUserData userData, IConfiguration config) {
            this.userData = userData;
            this.config = config;
        }

        [HttpPost]
        public async Task<ActionResult<string>> login(UserLoginDto login) {
            
            var userVerify = await userData.verifyUser(login.email, login.password); 

            if(userVerify is null) {
                return BadRequest("Invalid credentials");
            }

            return generateToken(userVerify);
        }

        private string generateToken(GeneralUser user) {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.userName),
                new Claim(ClaimTypes.Role, user.userRole),
                new Claim("ID", user.ID.ToString()),
                new Claim(ClaimTypes.Email, user.email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["AppSettings:Token"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}