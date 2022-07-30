using exmainationApi.Dtos.ExamDtos;
using exmainationApi.Dtos.QuestionDtos;
using exmainationApi.Dtos.UserDtos;
using exmainationApi.Models;

namespace exmainationApi.Heplers {
    public static class Converting {
         public static UserEssentials toUserEssentials(GeneralUser user) {
            return new UserEssentials { 
                firstName = user.firstName,
                lastName = user.lastName,
                userName = user.userName,
                userRole = user.userRole,
                email = user.email,
                pictureUrl = user.pictureUrl
             };
        }

        public static ExamEssentialsDto toExamEssentials(Exam exam) {
            return new ExamEssentialsDto {
                ID = exam.ID,
                title = exam.title,
                timesUsed = exam.timesUsed,
                passRate = exam.passRate,
                numOfQuestions = exam.numOfQuestions,
                duration = exam.duration,
                passingValue = exam.passingValue,
                numOfPoints = exam.numOfPoints,
                active = exam.active,
                dateCreated = exam.dateCreated,
                dateUpdated = exam.dateUpdated,
                dateToOpen = exam.dateToOpen
            };
        }

        public static QuestionEssentialsDto toQuestionEssentials(Question q) {
            return new QuestionEssentialsDto {
                ID = q.ID,
                question = q.question,
                difficulty = q.difficulty,
                timeUsed = q.timeUsed,
                timesCorrect = q.timesCorrect,
                dateCreated = q.dateCreated,
                dateUpdated = q.dateUpdated,
                dateUsed = q.dateUsed,
                questionType = q.questionType,
                pointValue = q.pointValue,
                hasImage = q.hasImage,
                imgURL = q.imgURL
            };
        }
    }
}
