using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "Instructor")]
    public class InstructorController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public InstructorController(UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _environment = environment;
        }

        // GET: InstructorProfile
        public async Task<IActionResult> InstructorProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile([Bind("Description")] ApplicationUser model, IFormFile ProfileImage)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Update the description only if it's not empty
            if (!string.IsNullOrWhiteSpace(model.Description))
            {
                user.Description = model.Description;
            }

            // Handle Profile Image Upload only if a file was provided
            if (ProfileImage != null && ProfileImage.Length > 0)
            {
                // Validate file extension
                var extension = Path.GetExtension(ProfileImage.FileName).ToLower();
                if (extension != ".jpg" && extension != ".png")
                {
                    ModelState.AddModelError("ProfileImage", "Image must be in png or jpg format.");
                    return View("InstructorProfile", user);
                }

                // Create user-specific directory in wwwroot/images
                var userDirectory = Path.Combine(_environment.WebRootPath, "images", user.Id);
                if (!Directory.Exists(userDirectory))
                {
                    Directory.CreateDirectory(userDirectory);
                }

                // Generate unique file name
                var fileName = Guid.NewGuid().ToString() + extension;
                var filePath = Path.Combine(userDirectory, fileName);

                // Save the image to the specified path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfileImage.CopyToAsync(stream);
                }

                // Optionally delete the old image
                if (!string.IsNullOrEmpty(user.Image_URL))
                {
                    var oldImagePath = Path.Combine(_environment.WebRootPath, user.Image_URL.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Update Image_URL in the database
                user.Image_URL = $"/images/{user.Id}/{fileName}";
            }

            // Update the user in the database
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Profile updated successfully!";
                return RedirectToAction("InstructorProfile");
            }
            else
            {
                // Add errors to ModelState
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Return the view with existing user data if ModelState is invalid
            return View("InstructorProfile", user);
        }

    }
}
