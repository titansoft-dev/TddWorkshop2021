using FluentAssertions;
using NUnit.Framework;

namespace TitansoftTddWorkshop.UnitTests
{

    [TestFixture()]
    public class MyStackTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NewStackShouldBeEmpty()
        {
            //Arrange
            int maxSize = 5;
            var target = new MyStack<int>(maxSize);


            //Act
            int size = target.Size;

            //Assert
            size.Should().Be(0);

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