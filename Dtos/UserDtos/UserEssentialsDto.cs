namespace exmainationApi.Dtos.UserDtos {
    public record UserEssentials {
        public string firstName {get; init;} = string.Empty;
        public string lastName {get; init;} = string.Empty;
        public string userRole {get; init;} = string.Empty;
        public string userName {get; init;} = string.Empty;
        public string pictureUrl {get; init;} = string.Empty;
        public string email {get; init;} = string.Empty;
    }
}