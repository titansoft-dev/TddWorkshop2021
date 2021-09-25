using FluentAssertions;
using NUnit.Framework;

namespace TitansoftTddWorkshop.UnitTests
{

    [TestFixture()]
    public class BownlingGameTest
    {
        private BowlingGame _target;

        [SetUp]
        public void Setup()
        {
            _target = new BowlingGame();

        }

        [Test]
        public void AllZero()
        {

            RollMany(20, 0);


            _target.Score().Should().Be(0);
        }
        [Test]
        public void AllOne()
        {

            RollMany(20, 1);


            _target.Score().Should().Be(20);
        }

        private void RollMany(int rounds, int pinsDown)
        {
            for (int i = 0; i < rounds; i++)
            {
                _target.Roll(pinsDown);
            }
        }

        [TearDown]
        public void CleanUp()
        {
        }

    }

    public class BowlingGame
    {
        private int score;

        public void Roll(int pinsDown)
        {
            score += pinsDown;
        }

        public int Score()
        {
            return score;
        }
    }
}