using FluentAssertions;
using NUnit.Framework;

//An Environment Test
namespace TitansoftTddWorkshop.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            "TestFluentAssertionIsReady".Length.Should().BeGreaterOrEqualTo(1);

            Assert.Pass("Your environment is ready");
        }


    }
}