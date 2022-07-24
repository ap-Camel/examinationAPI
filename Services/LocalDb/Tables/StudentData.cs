using exmainationApi.Dtos.StudentDtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;

namespace exmainationApi.Services.localDb.Tables {

    public class StudentData : IStudentData
    {
        private readonly ISqlDataAccess _db;

        public StudentData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> InsertStudentAsync(InsertStudentDto student, int id)
        {
            string sql = $"insert into student output inserted.id values ({student.rating}, {id})";

            return await _db.insertDataWithReturn(sql);
        }

        public async Task<Student> getStudentByUserIdAsync(int id) {
            string sql = $"select * from student where userID = {id}";

            return await _db.LoadSingle<Student>(sql);
        }
    }
}