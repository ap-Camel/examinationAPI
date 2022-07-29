using System.IdentityModel.Tokens.Jwt;
using exmainationApi.Dtos.ExamDtos;
using exmainationApi.Heplers;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exmainationApi.Controllers {

    [ApiController]
    [Route("exam")]
    [Authorize(Roles = "teacher")]
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

            return result >= 1 ? CreatedAtAction(nameof(getExamAsync), new {id = result}, exam) : BadRequest("exam was not created, something went wrong");
        }

        [HttpGet("examID/{id}")]
        public async Task<ActionResult<Exam>> getExamAsync(int id) {
            Exam exam = await examData.getExamAsync(id);

            return exam is not null ? Ok(exam) : BadRequest("this exam does not exist"); 
        }

        [HttpGet("numberOfExams/{num}")]
        public async Task<ActionResult<List<ExamEssentialsDto>>> getExamsAsync(int num) {

            int id = JwtHelpers.getSpecificID(HttpContext.Request.Headers["Authorization"]);

            var list = await examData.getExamsAsync(id, num);

            if(list is null) {
                return NotFound("no exams exist");
            }

            List<ExamEssentialsDto> newList = new List<ExamEssentialsDto>();
            foreach(Exam e in list) {
                newList.Add(Converting.toExamEssentials(e));
            }

            return newList;
        }
    }
}