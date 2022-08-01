using exmainationApi.Dtos.ExamQuestionsDtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;

namespace exmainationApi.Services.localDb.Tables {

    public class ExamQuestionsData : IExamQuestionsData
    {
        private readonly ISqlDataAccess _db;

        public ExamQuestionsData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> insertExamQuestionAsync(InsertExamQuestionDto eq, int questionID, int teacherID)
        {
            string sql = $"insert into examQuestions output inserted.id values ({eq.examID}, {questionID}, default, {Convert.ToInt16(eq.active)}, {eq.rate})";

            return await _db.insertDataWithReturn(sql);
        }

        public async Task<ExamQuestions> getExamQuestion(int id)
        {
            string sql = $"select top 1 * from examQuestions where ID = {id}";

            return await _db.LoadSingle<ExamQuestions>(sql);
        }


        public async Task<IEnumerable<Question>> getExamQuestionsAsync(int examID, int teacherID) {
            string sql = $"select question.* from exam " +
             "join ExamQuestions on exam.ID = ExamQuestions.examID " +
              "join Question on ExamQuestions.questionID = question.ID " +
              $"where question.teacherID = {teacherID} and exam.ID = {examID} ";

            return await _db.LoadMany<Question>(sql);
        }

    }
}