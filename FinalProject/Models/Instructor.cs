using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Must enter name")]
        [MaxLength(50, ErrorMessage = "Name must be less than 50 letters")]
        [MinLength(3, ErrorMessage = "Name must be greater than 50 letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Must enter name")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be strong")]
        public string Password { get; set; }
        [RegularExpression(@"\.(jpg|png)$", ErrorMessage = "Image must be png or jpg")]
        public string? Image_URL { get; set; }
        [Required]
        [Display(Name ="Description")]
        public string des {  get; set; }
        public ICollection<InstructorCourse> InstructorCourse { get; set; }
        public ICollection<Question> Question { get; set; }
        public ICollection<Answer> Answer { get; set; }



    }
}
