using MoviesApi.Models;

namespace MoviesApi.Repositories
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int CategoryId);
        bool ExistCategory(int CategoryId);
        bool ExistCategory(string CategoryName);
        bool CreateCategory(Category Category);
        bool UpdateCategory(Category Category);
        bool DeleteCategory(Category Category);
        bool Save();
    }
}
