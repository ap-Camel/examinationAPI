using exmainationApi.Dtos.TeacherDtos;
using exmainationApi.Models;

namespace exmainationApi.Services.localDb.Interfaces {
    public interface ITeacherData
    {
        Task<int> insertTeacherAsync(InsertTeacherDto teacher, int id);
        Task<Teacher> getTeacherByUserIdAsync(int id);
    }
}