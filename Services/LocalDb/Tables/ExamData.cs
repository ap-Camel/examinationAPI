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
            string sql = $"insert into Exam output inserted.id values ('{exam.title}', default, default, {exam.numOfQuestions}, {exam.duration}, null, {exam.passingValue}, {exam.numOfPoints}, {Convert.ToInt16(exam.active)}, default, default, {id})";

            return await _db.insertDataWithReturn(sql);
        }

        public async Task<Exam> getExamAsync(int id) {
            string sql = $"select * from Exam where ID = {id}";

            return await _db.LoadSingle<Exam>(sql);
        }

        public async Task<IEnumerable<Exam>> getExamsAsync(int teacherID, int num) {
            string sql = $"select top {num} * from Exam where teacherID = {teacherID} order by timesUsed asc;";

            return await _db.LoadMany<Exam>(sql);
        }
       
    }
}