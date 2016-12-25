using CourseDiscussions.Persistance.Entities;
using System.Collections.Generic;

namespace CourseDiscussions.Persistance.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
    }
}
