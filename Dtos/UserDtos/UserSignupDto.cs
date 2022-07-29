using System.ComponentModel.DataAnnotations;

namespace exmainationApi.Dtos.UserDtos {
    public record UserSignupDto {
        [Required(ErrorMessage = "first name is required")]
        [MinLength(2)]
        public string firstName {get; init;} = string.Empty;

        [Required(ErrorMessage = "last name is required")]
        [MinLength(2, ErrorMessage = "last name must be 2 characters or more")]
        public string lastName {get; init;} = string.Empty;

        [Required]
        public string userRole {get; init;} = string.Empty;

        [Required]
        public string email {get; init;} = string.Empty;

        [Required(ErrorMessage = "password is required")]
        [MinLength(8, ErrorMessage = "password must be more than 8 characters")]
        public string password {get; init;} = string.Empty;
    }
}