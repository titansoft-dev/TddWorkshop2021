using FluentAssertions;
using NUnit.Framework;

namespace TitansoftTddWorkshop.UnitTests
{
    [TestFixture()]
    public class BowlingGameTest
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

        [Test]
        //[Ignore("not yet")]
        public void OneSpare()
        {
            _target.Roll(5);
            _target.Roll(5);
            _target.Roll(2);
            RollMany(17, 0);

            _target.Score().Should().Be(14);
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
        private int[] _rolls = new int[21];
        private int current;

        public void Roll(int pinsDown)
        {
            _rolls[current++] = pinsDown;
        }

        public int Score()
        {
            var score = 0;
            var rollIndex = 0;
            for (int i = 0; i < 10; i++)
            {
                if (_rolls[rollIndex] + _rolls[rollIndex + 1] == 10)
                {
                    score += 10 + _rolls[rollIndex + 2];
                }
                else
                {
                    score += _rolls[rollIndex] + _rolls[rollIndex + 1];
                }

                rollIndex += 2;
            }

            return score;
        }
    }
}