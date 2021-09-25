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

    public class BowlingGame
    {
        private int score;
        private readonly int[] _rolls = new int[21];
        private int current;
        private int _rollIndex;

        public void Roll(int pinsDown)
        {
            _rolls[current++] = pinsDown;
        }

        public int Score()
        {
            int score = 0;

            _rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsSpare())
                {
                    score += 10 + BonusForSpare();
                }
                else
                {
                    score += CurrentFrameScore();

                }
                AdvanceNextFrame();
            }


            return score;
        }

        private int AdvanceNextFrame()
        {
            return _rollIndex += 2;
        }

        private int CurrentFrameScore()
        {
            return _rolls[_rollIndex] + _rolls[_rollIndex + 1];
        }

        private int BonusForSpare()
        {
            return _rolls[_rollIndex + 2];
        }

        private bool IsSpare()
        {
            return _rolls[_rollIndex] + _rolls[_rollIndex + 1] == 10;
        }
    }
}