using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // Rating out of 5
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

    }

}
