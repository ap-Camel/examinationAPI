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
        public async Task<ActionResult<ExamEssentialsDto>> getExamAsync(int id) {

            if(id == 0) {
                return BadRequest("zero is not a valid exam id");
            }

            int teacherID = JwtHelpers.getSpecificID(HttpContext.Request.Headers["Authorization"]);

            Exam exam = await examData.getExamAsync(id, teacherID);

            return exam is not null ? Ok(Heplers.Converting.toExamEssentials(exam)) : BadRequest("this exam does not exist"); 
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


        [HttpPut]
        public async Task<ActionResult<bool>> updateExamAsync(UpdateExamDto exam) {

            if(exam.ID == 0) {
                return BadRequest("no id was specified");
            }

            int id = JwtHelpers.getSpecificID(HttpContext.Request.Headers["Authorization"]);

            // var temp = exam.dateToOpen.ToLongDateString();
            // exam.dateToOpen = exam.dateToOpen.ToUniversalTime();

            bool result = await examData.updateExamAsync(exam, id);

            if(result) {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "was not able to update the exam");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> deleteExamAsync(int id) {
            int teacherID = JwtHelpers.getSpecificID(HttpContext.Request.Headers["Authorization"]);

            return await examData.deleteExamAsync(teacherID, id) ? StatusCode(StatusCodes.Status204NoContent, "deleted succesfuly") : NotFound("no exam was found with specified id");
        }
    }
}