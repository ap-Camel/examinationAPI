using exmainationApi.Dtos.QuestionDtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;

namespace exmainationApi.Services.localDb.Tables {

    public class QuestionData : IQuestionData
    {
        private readonly ISqlDataAccess _db;

        public QuestionData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<Question> getQuestoinAsync(int id)
        {
            string sql = $"select top 1 * from question where ID = {id}";

            return await _db.LoadSingle<Question>(sql);
        }

        public async Task<IEnumerable<Question>> getQuestionsAsync(int id)
        {
            string sql = $"select * from question where teacherID = {id}";

            return await _db.LoadMany<Question>(sql);
        }

        public async Task<int> insertQuestionAsync(InsertQuestionDto q, int id)
        {
            string sql = $"insert into question output inserted.id values('{q.question}', {q.difficulty}, default, default, default, default, null, {q.questionType}, {q.pointValue}, {Convert.ToInt16(q.hasImage)}, {q.imgURL}, {id});";

            return await _db.insertDataWithReturn(sql);
        }

    }
}