using System.Data.Entity;
using EntityFrameworkRepositoryPattern.Core.Domain;
using EntityFrameworkRepositoryPattern.Persistence.EntityConfigurations;

namespace EntityFrameworkRepositoryPattern.Persistence
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("PlutoQueries")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
        }
    }
}
