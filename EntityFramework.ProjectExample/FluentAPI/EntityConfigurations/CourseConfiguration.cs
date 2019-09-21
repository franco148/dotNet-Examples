using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotations;

namespace FluentAPI.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            // Table Override
            ToTable("tbl_Course");

            // Primary keys Override
            HasKey(c => c.Id);

            // Property Configurations
            Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255);

            Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(2000);

            // Relationships configuration
            HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);


            HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m =>
                {
                    m.ToTable("CourseTags");
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("TagId");
                });


            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);
        }
    }
}
