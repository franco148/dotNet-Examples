using System;
using EntityFrameworkRepositoryPattern.Core.Repositories;

namespace EntityFrameworkRepositoryPattern.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IAuthorRepository Authors { get; }
        int Complete();
    }
}