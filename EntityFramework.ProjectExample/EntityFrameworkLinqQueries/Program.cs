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
                select new {Name = c.Name, Author = c.Author.Name}; // Projection

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
                select new {AuthorName = a.Name, Courses = g.Count()};

            foreach (var x in queryJoining2)
            {
                Console.WriteLine("{0} ({1})", x.AuthorName, x.Courses);
            }

            Console.ReadLine();
        }
    }
}
