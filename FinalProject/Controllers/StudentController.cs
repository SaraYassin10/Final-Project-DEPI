using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
