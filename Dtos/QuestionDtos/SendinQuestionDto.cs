namespace exmainationApi.Dtos.QuestionDtos {
    public record SendinQuestionDto {
        public string question {get; init;} = string.Empty;
        public string questionType {get; init;} = string.Empty;
        public bool hasImage {get; init;}
        public string imgURL {get; init;} = string.Empty;
        
    }
}