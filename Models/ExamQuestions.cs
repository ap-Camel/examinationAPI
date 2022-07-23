namespace exmainationApi.Models {
    public record ExamQuestions {
        public int ID {get; init;}
        public int examID {get; init;}
        public int questionID {get; init;}
        public int timesUsed {get; init;}
        public bool active {get; init;}
        public int rate {get; init;}
    }
}