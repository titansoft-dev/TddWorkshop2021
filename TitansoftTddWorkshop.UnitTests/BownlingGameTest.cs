using FluentAssertions;
using NUnit.Framework;

namespace TitansoftTddWorkshop.UnitTests
{

    [TestFixture()]
    public class BownlingGameTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AllZero()
        {
            //Arrange
            var target = new BowlingGame();

            for (int i = 0; i < 20; i++)
            {
                target.Roll(0);

            }

            //Act
            int score = target.Score();

            //Assert
            score.Should().Be(0);
        }

        [TearDown]
        public void CleanUp()
        {
        }

    }

    public class BowlingGame
    {
        public void Roll(int pinsDown)
        {
        }

        public int Score()
        {
            return 0;
        }
    }
}