using System.ComponentModel.DataAnnotations;

namespace exmainationApi.Dtos.ExamDtos {
    public record InsertExamDto {
        [Required (ErrorMessage = "title field is required")]
        [MinLength(2, ErrorMessage = "title must be two characyers or more")]
        public string title {get; init;} = string.Empty;

        [Required (ErrorMessage = "number of questions is required")]
        [Range(1, 150, ErrorMessage = "number of questions must be between 1 and 150")]
        public int numOfQuestions {get; init;}

        [Required (ErrorMessage = "duration is required")]
        [Range(0, 240, ErrorMessage = "exam duration must be between 0 and 240 minutes")]
        public int duration {get; init;}

        [Required (ErrorMessage = "passing value is required")]
        [Range (0, 100, ErrorMessage = "the value for passing an exam must be between 0 and 100")]
        public int passingValue {get; init;}

        [Required (ErrorMessage = "number of points is required")]
        [Range (0, 1000000, ErrorMessage = "number of points must be between 0 and 1 000 000")]
        public int numOfPoints {get; init;}
        public bool active {get; init;} = false;
    }
}