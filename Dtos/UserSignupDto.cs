namespace exmainationApi.Dtos {
    public record UserSignupDto {
        public string firstName {get; init;} = string.Empty;
        public string lastName {get; init;} = string.Empty;
        public string userRole {get; init;} = string.Empty;
        public string email {get; init;} = string.Empty;
        public string password {get; init;} = string.Empty;
    }
}