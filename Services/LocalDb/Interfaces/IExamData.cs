using exmainationApi.Dtos.ExamDtos;
using exmainationApi.Models;

namespace exmainationApi.Services.localDb.Interfaces {
    public interface IExamData {
        Task<int> insertExamAsync(InsertExamDto exam, int id);

        Task<Exam> getExamAsync(int id);
        Task<IEnumerable<Exam>> getExamsAsync(int teacherID, int num);
    }
}