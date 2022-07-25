using exmainationApi.Dtos.AnswerDtos;
using exmainationApi.Dtos.QuestionDtos;

namespace exmainationApi.Dtos.ExamQuestionsDtos {
    public record ExamQuestion {
        public SendinQuestionDto question {get; init;}
        public List<SendingAnswerDto> answers {get; init;}
    }
}