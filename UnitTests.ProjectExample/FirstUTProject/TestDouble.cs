using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.dotMemoryUnit;
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

    public class SolveClass
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

        [Test]
        public void DotMemoryUnitTest()
        {
            dotMemory.Check(memory =>
            {
                Assert.That(memory.GetObjects(
                    where => where.Type.Is<SolveClass>()
                ).ObjectsCount, Is.EqualTo(0));
            });
        }

        [Test]
        public void DotMemoryUnitTest_Second()
        {
            var checkpoint1 = dotMemory.Check();

            // ... Manipulate here some logic.
            var chekpoint2 = dotMemory.Check(memory =>
            {
                Assert.That(memory.GetTrafficFrom(checkpoint1)
                      .Where(obj => obj.Interface.Is<IEnumerable<int>>())
                      .AllocatedMemory.SizeInBytes, Is.LessThan(1000));
            });
        }
    }
}
