namespace exmainationApi.Models {
    public record Answer {
        public int ID {get; init;}
        public bool correct {get; init;}
        public string answer {get; init;} = string.Empty;
        public int difficulty {get; init;}
        public int timesUsed {get; init;}
        public int timesChoosen {get; init;}
        public bool active {get; init;}
        public DateTime dateCreated {get; init;}
        public DateTime dateUpdated {get; init;}
        public DateTime dateUsed {get; init;}
        public bool hasImage {get; init;}
        public string imgURL {get; init;} = string.Empty;
        public int questionID {get; init;}

    }
}