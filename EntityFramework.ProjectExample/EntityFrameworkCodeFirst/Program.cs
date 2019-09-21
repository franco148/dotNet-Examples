using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    /// <summary>
    /// For installing EntityFramework in our CodeFirst Project
    /// - Install-Package EntityFramework -Version:6.1.3
    /// 
    /// After create the domain models and database context, we need to add the migration.
    /// - The first time we need to enable-migrations (Only once, the first time)
    ///     * Enable-Migrations
    /// 
    /// Once added the migration, we need to udpate our database
    /// - Update-Database
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // Here we are going to create our DBContext
    public class PlutoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        // Because we are not following the convention in our configuration file (Named SQL Connection String), we need to do the following
        // steps in our constructor method.
        public PlutoContext()
            : base("PlutoCodeFirst")
        {
            // I had an issue with the following syntax
            // : base("name=DefaultConnection")
            // : base("DefaultConnection")
        }
    }

    // Here we are going to create our DomainModels
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }
        public IList<Tag> Tags { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }
}
