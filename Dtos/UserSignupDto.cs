using System.ComponentModel.DataAnnotations;

namespace exmainationApi.Dtos {
    public record UserSignupDto {
        [Required]
        [MinLength(2)]
        public string firstName {get; init;} = string.Empty;
        [Required]
        [MinLength(2)]
        public string lastName {get; init;} = string.Empty;
        [Required]
        public string userRole {get; init;} = string.Empty;
        [Required]
        public string email {get; init;} = string.Empty;
        [Required]
        [MinLength(8)]
        public string password {get; init;} = string.Empty;
    }
}