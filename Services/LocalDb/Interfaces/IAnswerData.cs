using exmainationApi.Dtos.AnswerDtos;
using exmainationApi.Models;

namespace exmainationApi.Services.localDb.Interfaces {
    public interface IAnswerData
    {
        Task<IEnumerable<Answer>> getAnswersAsync(int ID);
        Task<Answer> getAnswerAsync(int id);
        Task<int> insertAnswerAsync(InsertAnswerDto answer);

    }
}