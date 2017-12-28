using System;
using Moq;
using NUnit.Framework;

namespace MockingProject
{
    public class Bar 
    {
        protected bool Equals(Bar other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Bar) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public string Name { get; set; }
    }

    public interface IBaz
    {
        string Name { get; }
    }

    public interface IFoo
    {
        bool DoSomething(string value);
        string ProcessString(string value);
        bool TryParse(string value, out string outputValue);
        bool Submit(ref Bar bar);
        int GetCount();
        bool Add(int amount);

        string Name { get; set; }
        IBaz SomeBaz { get; set; }
        int SomeOtherProperty { get; set; }
    }


    [TestFixture]
    public class MethodSamples
    {
        [Test]
        public void OrdinaryMethodCalls()
        {
            var mock = new Mock<IFoo>();

            //Setup controlls the behavior of the mock object.
            mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            //mock.Setup(foo => foo.DoSomething("pong")).Returns(false);
            mock.Setup(foo => foo.DoSomething(It.IsIn("pong", "foo"))).Returns(false);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(mock.Object.DoSomething("ping"));
                Assert.IsFalse(mock.Object.DoSomething("pong"));
            });
        }

        [Test]
        public void ArgumentDependentMatching()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Returns(false);

            mock.Setup(foo => foo.Add(It.Is<int>(x => x % 2 == 0)))
                .Returns(true);

            mock.Setup(foo => foo.Add(It.IsInRange<int>(1, 10, Range.Inclusive)))
                .Returns(false);

            mock.Setup(foo => foo.DoSomething(It.IsRegex("[a-z]+")))
                .Returns(false);
        }

        [Test]
        public void OutAndRefArguments()
        {
            var mock = new Mock<IFoo>();
            var requiredOuput = "ok";
            mock.Setup(foo => foo.TryParse("ping", out requiredOuput))
                .Returns(true);

            string result;

            Assert.Multiple(() =>
            {
                Assert.IsTrue(mock.Object.TryParse("ping", out result));
                Assert.That(result, Is.EqualTo(requiredOuput));

                var thisShouldBeFalse = mock.Object.TryParse("pong", out result);
                Console.WriteLine(thisShouldBeFalse);
                Console.WriteLine(result);
            });

            var bar = new Bar();
            mock.Setup(foo => foo.Submit(ref bar)).Returns(true);

            Assert.That(mock.Object.Submit(ref bar), Is.EqualTo(true));

            var someOtherBar = new Bar();
            Assert.IsFalse(mock.Object.Submit(ref someOtherBar));
        }
    }
}
