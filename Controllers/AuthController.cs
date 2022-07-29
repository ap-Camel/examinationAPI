using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using exmainationApi.Dtos;
using exmainationApi.Dtos.UserDtos;
using exmainationApi.Heplers;
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
        private readonly ITeacherData teacherData;
        private readonly IStudentData studentData;

        public AuthController(IUserData userData, IConfiguration config, ITeacherData teacherData, IStudentData studentData) {
            this.userData = userData;
            this.config = config;
            this.teacherData = teacherData;
            this.studentData = studentData;
        }

        [HttpPost]
        public async Task<ActionResult<UserLoginReturnDto>> login(UserLoginDto login) {
            
            var userVerify = await userData.verifyUserAsync(login.email, login.password);

            if(userVerify is null) {
                return NotFound("Invalid credentials");
            }

            int specificID = 0;
            try
            {
                switch(userVerify.userRole) {
                    case "student":
                        specificID = (await studentData.getStudentByUserIdAsync(userVerify.ID)).ID;
                    break;
                    case "teacher":
                        specificID = (await teacherData.getTeacherByUserIdAsync(userVerify.ID)).ID;
                    break;
                    default:
                        return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                //throw;
            }

            if(specificID > 0) {
                UserLoginReturnDto loginReturn = new UserLoginReturnDto {
                    user = Converting.toUserEssentials(userVerify),
                    JWT = generateToken(userVerify, specificID)
                };
                return Ok(loginReturn);
            }
            
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        private string generateToken(GeneralUser user, int specificID) {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.userName),
                new Claim(ClaimTypes.Role, user.userRole),
                new Claim("ID", user.ID.ToString()),
                new Claim("specificID", specificID.ToString()),
                new Claim(ClaimTypes.Email, user.email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["AppSettings:Token"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}