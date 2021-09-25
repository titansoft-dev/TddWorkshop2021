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

        [Test]
        public void OneSpare()
        {
            RollSpare();
            Roll(2);

            RollMany(17, 0);


            _target.Score().Should().Be(14);
        }

        [Test]
        public void OneStrike()
        {
            RollStrike();
            Roll(5);
            Roll(2);

            RollMany(16, 0);


            _target.Score().Should().Be(24);
        }
        [Test]
        public void PerfectScore()
        {
            RollMany(12, 10);

            _target.Score().Should().Be(300);
        }

        private void RollStrike()
        {
            Roll(10);
        }

        private void Roll(int pinsDown)
        {
            _target.Roll(pinsDown);
        }

        private void RollSpare()
        {
            _target.Roll(5);
            _target.Roll(5);
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
}