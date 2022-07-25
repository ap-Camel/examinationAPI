using exmainationApi.Dtos.AnswerDtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;

namespace exmainationApi.Services.localDb.Tables {    

    public class AnswerData : IAnswerData
    {
        private readonly ISqlDataAccess _db;

        public AnswerData(ISqlDataAccess db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Answer>> getAnswersAsync(int ID)
        {
            string sql = $"select * from answer where questionID = {ID}";

            return await _db.LoadMany<Answer>(sql);
        }

        public async Task<Answer> getAnswerAsync(int id) {
            string sql = $"select * from answer where ID = {id}";

            return await _db.LoadSingle<Answer>(sql);
        }

        public async Task<int> insertAnswerAsync(InsertAnswerDto answer) {
            string sql = $"insert into answer output inserted.id values ({Convert.ToInt16(answer.correct)}, '{answer.answer}', {answer.difficulty}, default, default, {Convert.ToInt16(answer.active)}, default, default, null, {Convert.ToInt16(answer.hasImage)}, '{answer.imgURL}', {answer.questionID})";

            return await _db.insertDataWithReturn(sql);
        }
    }
}