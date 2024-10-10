using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Must enter name")]
        [MaxLength(50,ErrorMessage ="Name must be less than 50 letters")]
        [MinLength(3, ErrorMessage = "Name must be greater than 50 letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Must enter name")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="Email is not valid")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",ErrorMessage ="Password must be strong")]
        public string Password { get; set; }
        [RegularExpression(@"\.(jpg|png)$",ErrorMessage ="Image must be png or jpg")]
        public string? Image_URL { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
