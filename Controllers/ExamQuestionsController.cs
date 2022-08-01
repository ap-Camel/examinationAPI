using exmainationApi.Dtos.ExamQuestionsDtos;
using exmainationApi.Dtos.QuestionDtos;
using exmainationApi.Heplers;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exmainationApi.Controllers {
    [ApiController]
    [Route("examQuestions")]
    [Authorize(Roles = "teacher")]
    public class ExamQuestionsController : ControllerBase {

        private readonly IExamQuestionsData examQuestionsData;
        private readonly IQuestionData questionData;

        public ExamQuestionsController(IExamQuestionsData examQuestionsData, IQuestionData questionData) {
            this.examQuestionsData = examQuestionsData;
            this.questionData = questionData;
        }

        
        [HttpGet("{examID}")]
        public async Task<ActionResult<List<QuestionEssentialsDto>>> getExamQuestionsAsync(int examID){
            if(examID == 0) {
                return BadRequest("zero is not a valid exam id");
            }

            int teacherID = JwtHelpers.getSpecificID(HttpContext.Request.Headers["Authorization"]);

            var list = await examQuestionsData.getExamQuestionsAsync(examID, teacherID);

            if(list is null) {
                return NotFound("no question were found");
            }

            List<QuestionEssentialsDto> temp = new List<QuestionEssentialsDto>();
            foreach(Question q in list) {
                temp.Add(Converting.toQuestionEssentials(q));
            }

            return Ok(temp);
        }


        [HttpPost]
        public async Task<ActionResult<bool>> insertExamQuestionAsync(InsertExamQuestionDto insert) {

            if(insert.examID == 0) {
                return BadRequest("zero is not a valid exam id");
            }

            int teacherID = JwtHelpers.getSpecificID(HttpContext.Request.Headers["Authorization"]);

            int questionID = 0;
            try
            {
                questionID = await questionData.insertQuestionAsync(insert.question, teacherID);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "was not able to add question");
                throw;
            }

            var result = await examQuestionsData.insertExamQuestionAsync(insert, questionID, teacherID);

            return result > 0 ? Ok("question was added") : StatusCode(StatusCodes.Status500InternalServerError, "was not able to add question");
        }


        // public async Task<ActionResult> insertExamQuestionAsync(InsertExamQuestionDto eq) {
        //     int result = await examQuestionsData.insertExamQuestionAsync(eq);

        //     return result > 0 ? CreatedAtAction(nameof())
        // }

        // public async Task<ActionResult> getExamQuestion(int id) {
        //     return Ok();
        // }

    }   
}