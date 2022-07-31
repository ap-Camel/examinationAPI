namespace exmainationApi.Dtos.ExamDtos {
    public record ExamEssentialsDto {
        public int ID {get; init;}
        public string title {get; init;} = string.Empty;
        public bool active {get; init;}
        public int passingValue {get; init;}   
        public int numOfQuestions {get; init;}     
        public int duration {get; init;}
        public DateTime dateToOpen {get; init;}
        public int numOfPoints {get; init;}
        public int passRate {get; init;}
        public int timesUsed {get; init;}
        public DateTime dateCreated {get; init;}
        public DateTime dateUpdated {get; init;}
    }
}