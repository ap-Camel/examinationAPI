namespace exmainationApi.Dtos.QuestionDtos {
    public record QuestionEssentialsDto {
        public int ID {get; init;}
        public string question {get; init;} = string.Empty;
        public int difficulty {get; init;}
        public int timeUsed {get; init;}
        public int timesCorrect {get; init;}
        public DateTime dateCreated {get; init;}
        public DateTime dateUpdated {get; init;}
        public DateTime dateUsed {get; init;}
        public string questionType {get; init;} = string.Empty;
        public int pointValue {get; init;}
        public bool hasImage {get; init;}
        public string imgURL {get; init;} = string.Empty;
    }
}