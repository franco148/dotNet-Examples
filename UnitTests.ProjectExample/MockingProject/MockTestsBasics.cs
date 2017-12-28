using Moq;
using NUnit.Framework;

namespace MockingProject
{
    public class Bar
    {
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
    }
}
