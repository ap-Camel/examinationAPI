using exmainationApi.Dtos.QuestionDtos;
using exmainationApi.Models;

namespace exmainationApi.Services.localDb.Tables {
    public class QuestionData
    {
        private readonly ISqlDataAccess _db;

        public QuestionData(ISqlDataAccess db)
        {
            _db = db;
        }
       
        public async Task<Question> getQuestoinAsync(int id) {
            string sql = $"select top 1 * from question where ID = {id}";

            return await _db.LoadSingle<Question>(sql);
        }

        public async Task<IEnumerable<Question>> getQuestionsAsync(int id) {
            string sql = $"select * from question where teacherID = {id}";

            return await _db.LoadMany<Question>(sql);
        }

        public async Task<int> insertQuestionAsync(InsertQuestionDto q) {
            string sql = $"insert into Question output INSERTED.id values('{q.question}', {q.difficulty}, default, default, default, default, null, '{q.questionType}', {q.pointValue}, {Convert.ToInt16(q.hasImage)}, {q.imgURL})";

            int id = await _db.insertDataWithReturn(sql);
            return id;
        }

        public async Task<bool> updateQuestoinAsync(int id) {
            return false;
        }

        public async Task<int> updateQuestionWithReturnAsync(int id) {
            return 0;
        }

        public async Task<bool> deleteQuestionAsync(int id) {
            return false;
        }

        public async Task<int> deleteQuestionWithReturn(int id) {
            return 0;
        }

    }
}