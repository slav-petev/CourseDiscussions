using CourseDiscusions.Persistance.Entities;

namespace CourseDiscussions.Persistance.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ApplicationUser GetUserByName(string name);
    }
}
