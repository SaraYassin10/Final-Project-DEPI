using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<InstructorCourse> InstructorCourse { get; set; }
    }

}
