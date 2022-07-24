using System.IdentityModel.Tokens.Jwt;
using exmainationApi.Dtos.ExamDtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exmainationApi.Controllers {

    [ApiController]
    [Route("exam")]
    [Authorize]
    public class ExamController : ControllerBase {
        private readonly IExamData examData;

        public ExamController(IExamData examData) {
            this.examData = examData;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> insertExamAsync(InsertExamDto exam) {

            string token = HttpContext.Request.Headers["Authorization"];
            string tokenHash = token.Split(" ")[1];

            var newToken = new JwtSecurityToken(tokenHash);
            var userId = int.Parse(newToken.Claims.First(x => x.Type == "specificID").Value);

            int result = await examData.insertExamAsync(exam, userId);

            return result >= 1 ? CreatedAtAction(nameof(getExamAsync), result, exam) : BadRequest("exam was not created, something went wrong");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> getExamAsync(int id) {
            Exam exam = await examData.getExamAsync(id);

            return exam is not null ? Ok(exam) : BadRequest("this exam does not exist"); 
        }
    }
}