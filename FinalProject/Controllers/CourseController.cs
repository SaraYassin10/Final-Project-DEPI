using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CourseController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public IActionResult Index(int page = 1)
        {
            return View("Index",_context.Courses.Include(u=>u.InstructorCourse).ToList());
        }
        //public IActionResult ShowCourse(int courseId)
        //{
        //    Course selectedcourse= _context.Courses.Include(c=>c.Category).FirstOrDefault(c => c.CourseId == courseId);
        //    if (selectedcourse != null) 
        //    {
        //        return View("ShowCourse", selectedcourse);
        //    }
        //    return RedirectToAction("Index");
        //}
        public IActionResult Enroll(int courseId)
        {
            List<Lesson> lessons=_context.Lessons.Where(l=>l.CourseId == courseId).ToList();
            if (lessons.Any())
            {
                return View("Enroll", lessons);
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Showcourse(int courseId)
        {
            var course = await _context.Courses
                .Include(c => c.InstructorCourse)    
                .ThenInclude(ic => ic.User)           
                .FirstOrDefaultAsync(c => c.CourseId == courseId);

            if (course == null)
            {
                return NotFound();
            }
            var instructorCourse = course.InstructorCourse.FirstOrDefault();
            if (instructorCourse == null)
            {
                return NotFound("No instructor found for this course.");
            }

            var instructor = await _userManager.FindByIdAsync(instructorCourse.UserId);

            if (instructor == null)
            {
                return NotFound("Instructor not found.");
            }
            ViewBag.CourseId = courseId;
            var courseDetailsViewModel = new CourseDetailsViewModel
            {
                CourseTitle = course.Title,
                CourseDescription = course.Description,
                InstructorName = instructor.UserName 
            };

            return View(courseDetailsViewModel);
            //var course = await _context.Courses
            //    .Include(c => c.InstructorCourse)  
            //    .ThenInclude(ic => ic.User)       
            //    .FirstOrDefaultAsync(c => c.CourseId == courseId);

            //if (course == null)
            //{
            //    return NotFound();
            //}

            //// Retrieve instructor information from UserManager
            //var instructor = await _userManager.FindByIdAsync(InstructorCourse);

            //// Create a ViewModel to pass the data to the view
            //var courseDetailsViewModel = new CourseDetailsViewModel
            //{
            //    CourseTitle = course.Title,
            //    CourseDescription = course.Description,
            //    InstructorName = instructor.UserName
            //};

            //return View(courseDetailsViewModel);
        }
    }

   public class CourseDetailsViewModel
{
    public string CourseTitle { get; set; }
    public string CourseDescription { get; set; }
    public string InstructorName { get; set; }
}

}

