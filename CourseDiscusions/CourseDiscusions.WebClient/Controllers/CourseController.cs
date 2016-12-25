using CourseDiscusions.WebClient.Models;
using CourseDiscussions.Persistance.Repositories;
using CourseDiscussions.Persistance.Repositories.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace CourseDiscusions.WebClient.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;

        public CourseController()
        {
            _userRepository = new UserRepository();
            _courseRepository = new CourseRepository();
        }

        [Authorize]
        public ActionResult Index()
        {
            var coursesForCurrentUser =
                _userRepository.GetUserByName(User.Identity.Name).Courses;
            if (!coursesForCurrentUser.Any())
            {
                return RedirectToAction("EnrollInCourses");
            }

            var coursesToDisplay = coursesForCurrentUser
                .Select(c => new CourseViewModel
                {
                    Name = $"{c.Name} - {c.StartDate.Year}"
                });

            return View(coursesToDisplay);
        }

        [Authorize]
        public ActionResult EnrollInCourses()
        {
            var availableCourses = _courseRepository
                .GetAllCourses();
            var availableCoursesToDisplay = availableCourses
                .Select(c => new CourseViewModel
                {
                    Name = $"{c.Name} - {c.StartDate.Year}"
                });

            return View(availableCoursesToDisplay);
        }
    }
}