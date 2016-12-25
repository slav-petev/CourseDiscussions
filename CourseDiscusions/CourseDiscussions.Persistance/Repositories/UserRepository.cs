using CourseDiscussions.Persistance.Repositories.Interfaces;
using System;
using System.Linq;
using CourseDiscusions.Persistance.Entities;

namespace CourseDiscussions.Persistance.Repositories
{
    public sealed class UserRepository : IUserRepository, IDisposable
    {
        private bool _disposed;

        private readonly ApplicationDbContext _applicationContext;

        public UserRepository()
        {
            _applicationContext = ApplicationDbContext.Create();
        }

        public ApplicationUser GetUserByName(string name)
        {
            if (_disposed)
                throw new ObjectDisposedException(null);

            return _applicationContext.Users
                .First(u => u.Email == name);
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
        
        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (!disposing) return;

            _applicationContext?.Dispose();
            _disposed = true;
        } 
    }
}
