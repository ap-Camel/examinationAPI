using exmainationApi.Dtos.StudentDtos;
using exmainationApi.Models;

namespace exmainationApi.Services.localDb.Interfaces {
    public interface IStudentData
    {
        Task<int> InsertStudentAsync(InsertStudentDto student, int id);
        Task<Student> getStudentByUserID(int id);
    }
}