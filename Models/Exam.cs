namespace exmainationApi.Models {
    public record Exam {
        public int ID {get; init;}
        public string titile {get; init;} = string.Empty;
        public int timesUsed {get; init;}
        public int passRate {get; init;}
        public int numOfQuestions {get; init;}
        public int duration {get; init;}
        public DateTime dateToOpen {get; init;}
        public int passingValue {get; init;}
        public int numOfPoints {get; init;}
        public bool active {get; init;}
        public DateTime dateCreated {get; init;}
        public DateTime dateUpdated {get; init;}
        public int teacherID {get; init;}


    }
}