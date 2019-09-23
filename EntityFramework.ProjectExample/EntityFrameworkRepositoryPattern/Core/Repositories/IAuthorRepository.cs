using EntityFrameworkRepositoryPattern.Core.Domain;

namespace EntityFrameworkRepositoryPattern.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorWithCourses(int id);
    }
}