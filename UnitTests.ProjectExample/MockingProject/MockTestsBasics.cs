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

    public delegate void AlienAbductionEventHandler(int galaxy, bool returned);

    public interface IAnimal
    {
        event EventHandler FallsIll;
        void Stumble();
        event AlienAbductionEventHandler AbductedByAliens;
    }

    public class Doctor
    {
        public int TimesCured;
        public int AbductionsObserved;

        public Doctor(IAnimal animal)
        {
            animal.FallsIll += (sender, args) =>
            {
                Console.WriteLine("I will cure you!");
                TimesCured++;
            };

            animal.AbductedByAliens += (galaxy, returned) => ++AbductionsObserved;
        }
    }

    public class Consumer
    {
        private IFoo foo;

        public Consumer(IFoo foo)
        {
            this.foo = foo;
        }

        public void Hello()
        {
            foo.DoSomething("ping");
            var name = foo.Name;
            foo.SomeOtherProperty = 123;
        }
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

        [Test]
        public void ExceptionsTests()
        {
            var mock = new Mock<IFoo>();

            mock.Setup(foo => foo.ProcessString(It.IsAny<string>()))
                .Returns((string s) => s.ToLowerInvariant());

            Assert.Multiple(() =>
            {
                Assert.That(mock.Object.ProcessString("ABC"), Is.EqualTo("abc"));
            });
        }

        [Test]
        public void ExceptionsAndReturnsTests1()
        {
            var mock = new Mock<IFoo>();
            var calls = 0;

            mock.Setup(foo => foo.GetCount())
                .Returns(() => calls)
                .Callback(() => ++calls);

            mock.Object.GetCount();
            mock.Object.GetCount();

            Assert.Multiple(() =>
            {
                Assert.That(mock.Object.GetCount(), Is.EqualTo(2));
            });
        }

        [Test]
        public void ExceptionsAndReturnsTests2()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething("kill"))
                .Throws<InvalidOperationException>();

            Assert.Throws<InvalidOperationException>(() =>
                mock.Object.DoSomething("kill")
            );
        }

        [Test]
        public void ExceptionsAndReturnsTests3()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.DoSomething(null))
                .Throws(new ArgumentException("cmd"));

            Assert.Throws<ArgumentException>(() =>
            {
                mock.Object.DoSomething(null);
            }, "cmd");

            //mock.Object.DoSomething("akdkdkh");
        }

        [Test]
        public void MockingPropertiesTests1()
        {
            var mock = new Mock<IFoo>();
            mock.Setup(foo => foo.Name)
                .Returns("bar");

            mock.Object.Name = "will not be assigned";

            Assert.That(mock.Object.Name, Is.EqualTo("bar"));

            mock.Setup(foo => foo.SomeBaz.Name)
                .Returns("hello");

            Assert.That(mock.Object.SomeBaz.Name, Is.EqualTo("hello"));
        }

        [Test]
        public void MockingPropertiesTests2()
        {
            var mock = new Mock<IFoo>();
            var setterCalled = false;

            mock.SetupSet(foo =>
            {
                foo.Name = It.IsAny<string>();
            })
            .Callback<string>(value =>
            {
                setterCalled = true;
            });

            mock.Object.Name = "def";
            mock.VerifySet(foo =>
            {
                foo.Name = "def";
            }, Times.AtLeastOnce);
        }

        [Test]
        public void ValueTrackingTests1()
        {
            var mock = new Mock<IFoo>();

            //mock.SetupAllProperties();
            mock.SetupProperty(foo => foo.Name);

            IFoo iFoo = mock.Object;
            iFoo.Name = "abc";

            Assert.That(mock.Object.Name, Is.EqualTo("abc"));
        }

        [Test]
        public void ValueTrackingTests2()
        {
            var mock = new Mock<IFoo>();

            mock.SetupAllProperties();
            //mock.SetupProperty(foo => foo.Name);

            IFoo iFoo = mock.Object;
            iFoo.Name = "abc";

            Assert.That(mock.Object.Name, Is.EqualTo("abc"));

            iFoo.Name = "abcd";
            iFoo.SomeOtherProperty = 123;

            Assert.That(mock.Object.SomeOtherProperty, Is.EqualTo(123));
        }

        [Test]
        public void MockingEventsTests1()
        {
            var mock = new Mock<IAnimal>();
            var doctor = new Doctor(mock.Object);

            mock.Raise(
                    a => a.FallsIll += null,
                    new EventArgs()
                );

            Assert.That(doctor.TimesCured, Is.EqualTo(1));

            mock.Setup(a => a.Stumble())
                .Raises(a => a.FallsIll += null,
                    new EventArgs());

            mock.Object.Stumble();

            Assert.That(doctor.TimesCured, Is.EqualTo(2));

            mock.Raise(a => a.AbductedByAliens += null, 42, true);

            Assert.That(doctor.AbductionsObserved, Is.EqualTo(1));
        }

        [Test]
        public void MoqCallbacksTests1()
        {
            var mock = new Mock<IFoo>();

            int x = 0;
            mock.Setup(foo => foo.DoSomething("ping"))
                .Returns(true)
                .Callback(() => x++);

            mock.Object.DoSomething("ping");

            Assert.That(x, Is.EqualTo(1));

            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Returns(true)
                .Callback((string s) => x = +s.Length);

            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Returns(true)
                .Callback<string>(s => x = +s.Length);

            mock.Setup(foo => foo.DoSomething("pong"))
                .Callback(() => Console.WriteLine("Before pong"))
                .Returns(false)
                .Callback(() => Console.WriteLine("after pong"));

            mock.Object.DoSomething("pong");
        }

        [Test]
        public void VerificationsTests1()
        {
            var mock = new Mock<IFoo>();
            var consumer = new Consumer(mock.Object);

            consumer.Hello();

            mock.Verify(foo => foo.DoSomething("ping"), Times.AtLeastOnce);

            mock.Verify(foo => foo.DoSomething("pong"), Times.Never);

            mock.VerifyGet(foo => foo.Name);

            mock.VerifySet(foo => foo.SomeOtherProperty = It.IsInRange(100, 200, Range.Inclusive));
        }
    }
}
