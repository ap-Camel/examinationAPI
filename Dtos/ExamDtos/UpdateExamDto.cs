namespace exmainationApi.Dtos.ExamDtos {
    public record UpdateExamDto {
        public int ID {get; init;}
        public string title {get; init;} = string.Empty;
        public int numOfQuestions {get; init;}
        public int duration {get; init;}
        public DateTime dateToOpen {get; init;}
        public int passingValue {get; init;}
        public int numOfPoints {get; init;}
        public bool active {get; init;}
    }
}