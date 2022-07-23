namespace exmainationApi.Models {
    public record GeneralUser {
        public int ID {get;init;}
        public string firstName {get; init;} = string.Empty;
        public string lastName {get; init;} = string.Empty;
        public string userRole {get; init;} = string.Empty;
        public string userName {get; init;} = string.Empty;
        public string pictureUrl {get; init;} = string.Empty;
        public string email {get; init;} = string.Empty;
        public string userPassword {get; init;} = string.Empty;
        public DateTime dateCreated {get; init;}
        public DateTime dateUpdated {get; init;}
        public int settingsID {get; init;}
    }
}