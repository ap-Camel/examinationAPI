using exmainationApi.Dtos.TeacherDtos;
using exmainationApi.Models;
using exmainationApi.Services.localDb.Interfaces;

namespace exmainationApi.Services.localDb.Tables {    

    public class TeacherData : ITeacherData
    {
        private readonly ISqlDataAccess _db;

        public TeacherData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> insertTeacherAsync(InsertTeacherDto teacher, int id)
        {
            string sql = $"insert into Teacher output inserted.ID values ({teacher.apiUsageRate}, {id})";

            return await _db.insertDataWithReturn(sql);
        }

        public async Task<Teacher> getTeacherByUserIdAsync(int id) 
        {
            string sql = $"select * from teacher where userID = {id}";

            return await _db.LoadSingle<Teacher>(sql);
        }
    }
}