using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace FirstUTProject
{
    public static class Solve
    {
        public static Tuple<double, double> Quadratic(double a, double b, double c)
        {
            var disc = b * b - 4 * a * c;
            if (disc < 0)
            {
                throw new Exception("Cannot solve with complex roots");
            }
            else
            {
                var root = Math.Sqrt(disc);
                return Tuple.Create(
                    (-b + root) / 2 / a,
                    (-b - root) / 2 / a
                );
            }
        }
    }

    [TestFixture]
    class EquationTests
    {
        [Test]
        public void Test()
        {
            var result = Solve.Quadratic(1, 10, 16);
        }

        [Test]
        public void Test2()
        {
            //var result = Solve.Quadratic(1, 1, 1);

            Assert.Throws<Exception>(() =>
            {
                Solve.Quadratic(1, 1, 1);
            });
        }
    }
}
