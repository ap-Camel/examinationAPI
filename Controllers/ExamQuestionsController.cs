using exmainationApi.Dtos.ExamQuestionsDtos;
using exmainationApi.Services.localDb.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exmainationApi.Controllers {
    [ApiController]
    [Route("examQuestions")]
    [Authorize]
    public class ExamQuestionsController : ControllerBase {

        private readonly IExamQuestionsData examQuestionsData;

        public ExamQuestionsController(IExamQuestionsData examQuestionsData) {
            this.examQuestionsData = examQuestionsData;
        }

        
        // public async Task<ActionResult> insertExamQuestionAsync(InsertExamQuestionDto eq) {
        //     int result = await examQuestionsData.insertExamQuestionAsync(eq);

        //     return result > 0 ? CreatedAtAction(nameof())
        // }

        public async Task<ActionResult> getExamQuestion(int id) {
            return Ok();
        }

    }   
}