namespace exmainationApi.Dtos.AnswerDtos {
    public record SendingAnswerDto {        
        public string answer {get; init;} = string.Empty;
        public bool hasImage {get; init;}
        public string imgURL {get; init;} = string.Empty;
    }
}