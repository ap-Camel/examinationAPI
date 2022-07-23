namespace exmainationApi.Models {
    public record TakenExams {
        public int ID {get; init;}
        public int numOfStudents {get; init;}
        public DateTime dateCreated {get; init;}
        public int numOfPassed {get; init;}
        public int examID {get; init;}
    }
}