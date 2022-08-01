using exmainationApi.Dtos.QuestionDtos;

namespace exmainationApi.Dtos.ExamQuestionsDtos {
    public record InsertExamQuestionDto {
        public int examID {get; init;}
        public bool active {get; init;}
        public int rate {get; init;}
        public InsertQuestionDto question {get; init;}
    }
}