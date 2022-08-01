using exmainationApi.Dtos.ExamDtos;
using exmainationApi.Models;

namespace exmainationApi.Services.localDb.Interfaces {
    public interface IExamData {
        Task<int> insertExamAsync(InsertExamDto exam, int id);
        Task<Exam> getExamAsync(int id, int teacherID);
        Task<IEnumerable<Exam>> getExamsAsync(int teacherID, int num);
        Task<bool> updateExamAsync(UpdateExamDto exam, int id);
        Task<bool> deleteExamAsync(int teacherID, int examID);
    }
}