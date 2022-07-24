namespace exmainationApi.Dtos.ExamDtos {
    public record InsertExamDto {
        public string titile {get; init;} = string.Empty;
        public int passRate {get; init;}
        public int numOfQuestions {get; init;}
        public int duration {get; init;}
        public int passingValue {get; init;}
        public int numOfPoints {get; init;}
        public bool active {get; init;}
    }
}