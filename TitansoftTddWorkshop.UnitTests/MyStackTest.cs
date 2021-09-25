using FluentAssertions;
using NUnit.Framework;

namespace TitansoftTddWorkshop.UnitTests
{

    [TestFixture()]
    public class MyStackTest
    {
        private MyStack<int> _target;
        private int _maxSize = 5;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NewStackShouldBeEmpty()
        {

            _target = new MyStack<int>(_maxSize);

            _target.Size.Should().Be(0);
        }

        [TearDown]
        public void CleanUp()
        {
        }

    }

    public class MyStack<T>
    {
        public MyStack(int maxSize)
        {
        }

        public int Size { get; set; }
    }
}