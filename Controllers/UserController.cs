using exmainationApi.Dtos;
using exmainationApi.Dtos.StudentDtos;
using exmainationApi.Dtos.TeacherDtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exmainationApi.Controllers {
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase {
        private readonly IUserData userData;
        private readonly ITeacherData teacherData;
        private readonly IStudentData studentData;

        public UserController(IUserData userData, ITeacherData teacherData, IStudentData studentData) {
            this.userData = userData;
            this.teacherData = teacherData;
            this.studentData = studentData;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<GeneralUser>> getUserAsync(string userName) {

            var check = await userData.getUser(userName);

            if(check is null) {
                return BadRequest("user does not exist");
            }

            return check;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> signupAsync(UserSignupDto user) {

            if(!(user.userRole == "teacher" || user.userRole == "student")) {
                return BadRequest($"can not sign up with the role of: {user.userRole}");
            }

            var check = await userData.checkForEmailAsync(user.email);

            if(check is not null) {                
                return Conflict("user already exists");
            }

            int insertUser = await userData.insertUser(user);                
            if(insertUser > 0) {
                int insertedSpecific = 0;
                try
                {
                    switch(user.userRole){
                    case "student":
                        insertedSpecific = await studentData.InsertStudentAsync(new InsertStudentDto { rating = 0 }, insertUser);
                    break;
                    case "teacher":
                        insertedSpecific = await teacherData.insertTeacherAsync(new InsertTeacherDto{ apiUsageRate = 0 }, insertUser);
                    break;                          
                    }
                }
                catch (System.Exception)
                {
                    bool deleted = await userData.deleteUserAsync(insertUser);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                    // throw;
                }
                
                if(insertedSpecific > 0) {
                    return CreatedAtAction(nameof(getUserAsync), new { userName = user.email}, user);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}