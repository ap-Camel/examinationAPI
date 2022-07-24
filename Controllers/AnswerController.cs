using exmainationApi.Dtos.AnswerDtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exmainationApi.Controllers {
    
    [ApiController]
    [Route("Answers")]
    //[Authorize("teacher")]
    public class AnswerController : ControllerBase {
        private readonly IAnswerData answerData;

        public AnswerController(IAnswerData answerData) {
            this.answerData = answerData;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Answer>>> getAnswersAsync(int id) {
            var answers = await answerData.getAnswersAsync(id);

            if(answers is null) 
                return BadRequest("No answers to show");

            return Ok(answers);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> insertAnswerAsync(InsertAnswerDto answer) {

            var result = await answerData.insertAnswerAsync(answer);

            //result ? return Ok("answer was added") : return BadRequest("something went wrong, answer was not added");
            
            return result ? Ok("answer was added") : BadRequest("something went wrong, answer was not added");
        }
    }
}