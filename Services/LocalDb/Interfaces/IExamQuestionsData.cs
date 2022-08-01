using exmainationApi.Dtos.ExamQuestionsDtos;
using exmainationApi.Models;

namespace exmainationApi.Services.localDb.Interfaces {
     public interface IExamQuestionsData
    {
        Task<ExamQuestions> getExamQuestion(int id);
        Task<int> insertExamQuestionAsync(InsertExamQuestionDto eq, int questionID, int teacherID);
        Task<IEnumerable<Question>> getExamQuestionsAsync(int examID, int teacherID);
    }
}