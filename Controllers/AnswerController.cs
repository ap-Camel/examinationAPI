using exmainationApi.Dtos.AnswerDtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exmainationApi.Controllers {
    
    [ApiController]
    [Route("Answers")]
    [Authorize(Roles = "teacher")]
    
    public class AnswerController : ControllerBase {
        private readonly IAnswerData answerData;

        public AnswerController(IAnswerData answerData) {
            this.answerData = answerData;
        }


        [HttpGet("answers/{id}")]
        public async Task<ActionResult<IEnumerable<Answer>>> getAnswersAsync(int id) {
            var answers = await answerData.getAnswersAsync(id);

            if(answers is null) 
                return BadRequest("No answers to show");

            return Ok(answers);
        }

        [HttpGet("answer/{id}")]
        public async Task<ActionResult<Answer>> getAnswerAsync(int id) {
            var answer = await answerData.getAnswerAsync(id);

            if(answer is null)
                return NotFound("no answer with this id exists");

            return Ok(answer);
        }

        [HttpPost]
        public async Task<ActionResult> insertAnswerAsync(InsertAnswerDto answer) {

            int result = await answerData.insertAnswerAsync(answer);
            
            return result > 0 ? CreatedAtAction(nameof(getAnswersAsync), new {id = result}, answer) : BadRequest("something went wrong, answer was not added");
        }
    }
}