using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queries;

namespace EntityFrameworkLinqQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.ReadLine();
        }

        private static void LinqSyntax()
        {
            var context = new PlutoContext();

            // LINQ Syntax
            var query = from c in context.Courses
                where c.Name.Contains("C#")
                orderby c.Name
                select c;

            foreach (var course in query)
            {
                Console.WriteLine(course.Name);
            }

            // Extension Methods
            var courses = context.Courses
                .Where(c => c.Name.Contains("c#"))
                .OrderBy(c => c.Name);

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }

            // More Examples
            var queryCourses = from c in context.Courses
                where c.Author.Id == 1
                orderby c.Level descending, c.Name // orderding
                // select c;
                select new { Name = c.Name, Author = c.Author.Name }; // Projection

            // Grouping
            var queryGroupingCourses = from c in context.Courses
                group c by c.Level
                into g
                select g;

            foreach (var groupingCourse in queryGroupingCourses)
            {
                Console.WriteLine(groupingCourse.Key);
                foreach (var course in groupingCourse)
                {
                    Console.WriteLine("\t{0}", course.Name);
                }
            }

            // Count
            foreach (var groupingCourse in queryGroupingCourses)
            {
                Console.WriteLine("{0} ({1})", groupingCourse.Key, groupingCourse.Count());
            }

            // Joining
            var queryJoining1 = from c in context.Courses
                join a in context.Authors on c.AuthorId equals a.Id
                //select new {CourseName = c.Name, AuthorName = c.Author.Name};
                select new { CourseName = c.Name, AuthorName = a.Name };

            var queryJoining2 = from a in context.Authors
                join c in context.Courses on a.Id equals c.AuthorId into g
                select new { AuthorName = a.Name, Courses = g.Count() };

            foreach (var x in queryJoining2)
            {
                Console.WriteLine("{0} ({1})", x.AuthorName, x.Courses);
            }
        }

        private static void ExtensionMethods()
        {
            var context = new PlutoContext();

            var coursesLevel1 = context.Courses
                .Where(c => c.Level == 1)
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Level);

            // Projection
            var coursesProjection = context.Courses
                .Where(c => c.Level == 1)
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Level)
                // .Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name});
                .Select(c => c.Tags);

            foreach (var c in coursesProjection)
            {
                foreach (var tag in c)
                {
                    Console.WriteLine(tag.Name);
                }
            }

            var tags = context.Courses
                .Where(c => c.Level == 1)
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Level)
                // .Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name});
                .SelectMany(c => c.Tags); //.Distinc()

            foreach (var t in tags)
            {
                Console.WriteLine(t.Name);
            }

            // Grouping
            var groups = context.Courses.GroupBy(c => c.Level);

            foreach (var group in groups)
            {
                Console.WriteLine("Key: " + group.Key);

                foreach (var course in group)
                {
                    Console.WriteLine("\t" + course.Name);
                }
            }
            
            // Joining
            context.Courses.Join(context.Authors, 
                c => c.AuthorId, 
                a => a.Id, (course, author) => new
                {
                    CourseName = course.Name,
                    AuthorName = author.Name
                });

            // Group Joining
            context.Authors.GroupJoin(context.Courses,
                a => a.Id,
                c => c.AuthorId,
                (author, courses) => new
                {
                    AuthorName = author,
                    Courses = courses.Count()
                });

            context.Authors.SelectMany(a => context.Courses,
                (author, course) => new Course
                {
                    
                });

            // Partitioning
            context.Courses.Skip(10).Take(10);
        }

        private static void DeferredExecution()
        {
            var context = new PlutoContext();
            var courses = context.Courses;
            var filtered = courses.Where(c => c.Level == 1);
            var sorted = filtered.OrderBy(c => c.Name);

            //None of above code are executed, they are only extending the query.
            //Try not to use custom properties because it will throw an exception unless you execute toList() or something
            //similar first.

            foreach (var c in courses)
                Console.WriteLine(c.Name);
        }

        private static void IqueryableInterface()
        {
            // Allows us to extend the queries without executing them.
            var context = new PlutoContext();
            IQueryable<Course> courses = context.Courses;
            var filtered = courses.Where(c => c.Level == 1);

            // In the SQL profiler we are going to see that WHERE clouse is taken
            // into account as a whole query.
        }
    }
}
