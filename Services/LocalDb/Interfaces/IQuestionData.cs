using exmainationApi.Dtos.QuestionDtos;
using exmainationApi.Models;

namespace exmainationApi.Services.localDb.Interfaces {
    public interface IQuestionData
    {
        Task<IEnumerable<Question>> getQuestionsAsync(int id);
        Task<Question> getQuestoinAsync(int id);
        Task<int> insertQuestionAsync(InsertQuestionDto q, int id);
    }
}