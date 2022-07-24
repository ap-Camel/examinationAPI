namespace exmainationApi.Dtos.QuestionDtos {
    public record InsertQuestionDto {
        public string question {get; init;} = string.Empty;
        public int difficulty {get; init;}
        public string questionType {get; init;} = string.Empty;
        public int pointValue {get; init;}
        public bool hasImage {get; init;}
        public string imgURL {get; init;} = string.Empty;
    }
}