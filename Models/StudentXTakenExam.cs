namespace exmainationApi.Models {
    public record StudentXTakenExam {
        public int ID {get; init;}
        public int takenExamID {get; init;}
        public int studentID {get; init;}
        public int questionID {get; init;}
        public int answerID {get; init;}
        public bool correct {get; init;}        
    }
}