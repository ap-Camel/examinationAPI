using System.IdentityModel.Tokens.Jwt;
using exmainationApi.Dtos.QuestionDtos;
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

            string token = HttpContext.Request.Headers["Authorization"];
            string tokenHash = token.Split(" ")[1];

            var newToken = new JwtSecurityToken(tokenHash);
            int userId = int.Parse(newToken.Claims.First(x => x.Type == "specificID").Value);

            int inserted = await questionData.insertQuestionAsync(question, userId);

            return inserted > 0 ? CreatedAtAction(nameof(getQuestionAsync), new {id = inserted}, question) : BadRequest("something went wrong, question was not created");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> getQuestionAsync(int id) {
            Question question = await questionData.getQuestoinAsync(id);

            return question is not null ? Ok(question) : BadRequest("question does not exist");
        }
    }
}