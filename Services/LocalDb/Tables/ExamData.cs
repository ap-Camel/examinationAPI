using exmainationApi.Dtos.ExamDtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;

namespace exmainationApi.Services.localDb.Tables {
    public class ExamData : IExamData {
        private readonly ISqlDataAccess _db;

        public ExamData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> insertExamAsync(InsertExamDto exam, int id) {
            string sql = $"insert into Exam output inserted.id values ('{exam.titile}', default, {exam.passRate}, {exam.numOfQuestions}, {exam.duration}, null, {exam.passingValue}, {exam.numOfPoints}, {Convert.ToInt16(exam.active)}, default, default, {id})";

            return await _db.insertDataWithReturn(sql);
        }

        public async Task<Exam> getExamAsync(int id) {
            string sql = $"select * from Exam where ID = {id}";

            return await _db.LoadSingle<Exam>(sql);
        }
       
    }
}