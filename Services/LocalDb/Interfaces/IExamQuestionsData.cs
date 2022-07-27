using exmainationApi.Dtos.ExamQuestionsDtos;
using exmainationApi.Models;

namespace exmainationApi.Services.localDb.Interfaces {
     public interface IExamQuestionsData
    {
        Task<ExamQuestions> getExamQuestion(int id);
        Task<int> insertExamQuestionAsync(InsertExamQuestionDto eq);
    }
}