using CourseDiscussions.Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using CourseDiscussions.Persistance.Entities;
using CourseDiscusions.Persistance.Entities;

namespace CourseDiscussions.Persistance.Repositories
{
    public sealed class CourseRepository : ICourseRepository, IDisposable
    {
        private bool _disposed;

        private ApplicationDbContext _applicationContext;

        public CourseRepository()
        {
            _applicationContext = ApplicationDbContext.Create();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(_applicationContext));

            return _applicationContext.Courses;
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
