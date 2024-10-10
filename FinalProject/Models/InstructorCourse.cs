using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class InstructorCourse
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId {  get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
