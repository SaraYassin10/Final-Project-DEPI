using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class CourseController : Controller
    {

        private readonly ApplicationContext _context;
        public CourseController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            return View("Index", _context.Courses.Include(u => u.InstructorCourse).ToList());
        }



        public IActionResult ShowCourse(int courseId)
        {
            Course selectedcourse = _context.Courses.Include(c => c.Category).FirstOrDefault(c => c.CourseId == courseId);
            if (selectedcourse != null)
            {
                return View("ShowCourse", selectedcourse);
            }
            return RedirectToAction("Index");
        }
    }

}

