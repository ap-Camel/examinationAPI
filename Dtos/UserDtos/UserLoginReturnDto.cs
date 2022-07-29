namespace exmainationApi.Dtos.UserDtos {
    public record UserLoginReturnDto {
        
        public UserEssentials ?user {get; init;}
        public string ?JWT {get; init;}
        
    }
}