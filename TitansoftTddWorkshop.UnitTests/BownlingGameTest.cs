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
        }

        [Test]
        public void AllZero()
        {
            _target = new BowlingGame();

            RollMany(20, 0);


            _target.Score().Should().Be(0);
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
        public void Roll(int pinsDown)
        {
        }

        public int Score()
        {
            return 0;
        }
    }
}