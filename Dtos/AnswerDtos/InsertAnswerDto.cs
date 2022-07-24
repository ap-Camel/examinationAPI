namespace exmainationApi.Dtos.AnswerDtos {
    public record InsertAnswerDto {
        public bool correct {get; init;}
        public string answer {get; init;} = string.Empty;
        public int difficulty {get; init;}
        public bool active {get; init;}
        public bool hasImage {get; init;}
        public string imgURL {get; init;} = string.Empty;
        public int questionID {get; init;}
    }
}