//using Microsoft.EntityFrameworkCore;

//namespace FinalProject.Models
//{

//    //Data Source=DESKTOP-3VDT2ME\MSSQLSERVER2022;Initial Catalog=depi;Integrated Security=True;Encrypt=True;Trust Server Certificate=True
//    public class LearningContext : DbContext
//    {
//        public DbSet<Answer> Answers { get; set; }
//        public DbSet<Cart> Carts { get; set; }
//        public DbSet<CartItem> CartItems { get; set; }
//        public DbSet<Category> Categories { get; set; }
//        public DbSet<Course> Courses { get; set; }
//        public DbSet<Enrollment> Enrollments { get; set; }
//        public DbSet<Exam> Exams { get; set; }
//        public DbSet<Feedback> Feedbacks { get; set; }
//        public DbSet<Instructor> Instructors { get; set; }
//        public DbSet<InstructorCourse> InstructorCourses { get; set; }
//        public DbSet<Lesson> Lessons { get; set; }
//        public DbSet<Order> Orders { get; set; }
//        public DbSet<Payment> Payments { get; set; }
//        public DbSet<Question> Questions { get; set; }
//        public DbSet<Student> Students { get; set; }
//        public LearningContext(DbContextOptions options) : base(options)
//        {

//        }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Example: Cascade delete for Course -> Lessons
//            modelBuilder.Entity<Course>()
//                .HasMany(c => c.Lessons)
//                .WithOne(l => l.Course)
//                .OnDelete(DeleteBehavior.Cascade);  // This enables cascading delete

//            // Example: Cascade delete for Cart -> CartItems
//            modelBuilder.Entity<Cart>()
//                .HasMany(c => c.CartItems)
//                .WithOne(ci => ci.Cart)
//                .OnDelete(DeleteBehavior.Cascade);

//            // Example: Cascade delete for Exam -> Questions
//            modelBuilder.Entity<Exam>()
//                .HasMany(e => e.Questions)
//                .WithOne(q => q.Exam)
//                .OnDelete(DeleteBehavior.Cascade);

//            // Example: Cascade delete for Question -> Answers
//            modelBuilder.Entity<Question>()
//                .HasMany(q => q.Answers)
//                .WithOne(a => a.Question)
//                .OnDelete(DeleteBehavior.Cascade);
//        }
//    }
//}
