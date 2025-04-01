using MoviesApi.Data;
using MoviesApi.Models;

namespace MoviesApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateCategory(Category Category)
        {
            Category.CreationDate = DateTime.Now;
            _context.Categories.Add(Category);
            return Save();
        }

        public bool DeleteCategory(Category Category)
        {
            _context.Categories.Remove(Category);
            return Save();
        }

        public bool ExistCategory(int CategoryId)
        {
            return _context.Categories.Any(c => c.Id == CategoryId);
        }

        public bool ExistCategory(string CategoryName)
        {
            return _context.Categories.Any(c => c.Name.ToLower().Trim() == CategoryName.ToLower().Trim());
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Name).ToList();
        }

        public Category GetCategory(int CategoryId)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == CategoryId);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public bool UpdateCategory(Category Category)
        {
            Category.CreationDate = DateTime.Now;
            _context.Categories.Update(Category);
            return Save();
        }
    }
}
