using System.ComponentModel.DataAnnotations;

namespace exmainationApi.Dtos.UserDtos  {
    public record UserLoginDto {
        [Required]
        public string email {get; init;}
        [Required]
        public string password {get; init;}
    }
}