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

        public CourseController()
        {
            _userRepository = new UserRepository();
        }

        [Authorize]
        public ActionResult Index()
        {
            var coursesForCurrentUser =
                _userRepository.GetUserByName(User.Identity.Name).Courses;
            var coursesToDisplay = coursesForCurrentUser
                .Select(c => new CourseViewModel
                {
                    Name = $"{c.Name} - {c.StartDate.Year}"
                });

            return View(coursesToDisplay);
        }
    }
}