using System.IdentityModel.Tokens.Jwt;
using exmainationApi.Dtos.QuestionDtos;
using exmainationApi.Heplers;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exmainationApi.Controllers {
    [ApiController]
    [Route("questions")]
    [Authorize]
    public class QuestionController : ControllerBase {
        private readonly IQuestionData questionData;

        public QuestionController(IQuestionData questionData) {
            this.questionData = questionData;
        }

        [HttpPost]
        public async Task<ActionResult<string>> insertQuestionAsync(InsertQuestionDto question) {

            int userId = JwtHelpers.getSpecificID(HttpContext.Request.Headers["Authorization"]);

            int inserted = await questionData.insertQuestionAsync(question, userId);

            return inserted > 0 ? CreatedAtAction(nameof(getQuestionAsync), new {id = inserted}, question) : BadRequest("something went wrong, question was not created");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> getQuestionAsync(int id) {
            Question question = await questionData.getQuestoinAsync(id);

            return question is not null ? Ok(question) : BadRequest("question does not exist");
        }


        [HttpGet("getQuestions/{num}")]
        public async Task<ActionResult<List<QuestionEssentialsDto>>> getQuestionsDto(int num) {
            int teacherID = JwtHelpers.getSpecificID(HttpContext.Request.Headers["Authorization"]);

            var list = await questionData.getQuestionsAsync(num, teacherID);

            if(list.Count() == 0) {
                return NotFound("you dint have any questions");
            }

            List<QuestionEssentialsDto> temp = new List<QuestionEssentialsDto>();
            foreach(Question q in list) {
                temp.Add(Converting.toQuestionEssentials(q));
            }

            return Ok(temp);
        }
    }
}