namespace exmainationApi.Models {
    public record TeacherXStudent {
        public int ID {get; init;}
        public int teacherID {get; init;}
        public int studentID {get; init;}
    }
}