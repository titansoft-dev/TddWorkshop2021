using System.Collections.Generic;
using System.Linq;

namespace TitansoftTddWorkshop
{
    public class BowlingGame
    {
        private List<int> _Rolls = new List<int>(21);

        public void Roll(int pinsDown)
        {
            _Rolls.Add(pinsDown);
        }

        public int Score()
        {
            return _Rolls.ToFrames().Take(10).Sum(frame => frame.Sum());
        }

    }

    public static class BowlingFrame
    {
        public static IEnumerable<IEnumerable<int>> ToFrames(this IEnumerable<int> rolls)
        {
            yield return rolls.Take(rolls.RollsToScore());

            foreach (var frame in rolls.Skip(rolls.AdvanceToNextFrame()).ToFrames())
            {
                yield return frame;
            }

        }

        private static int AdvanceToNextFrame(this IEnumerable<int> rolls)
        {
            return rolls.IsStrike() ? 1 : 2;
        }
        private static int RollsToScore(this IEnumerable<int> rolls)
        {
            return rolls.IsBonus() ? 3 : 2;
        }

        private static bool IsBonus(this IEnumerable<int> rolls)
        {
            return rolls.IsSpare() || rolls.IsStrike();
        }
        private static bool IsSpare(this IEnumerable<int> rolls)
        {
            return rolls.Take(2).Sum().Equals(10);
        }
        private static bool IsStrike(this IEnumerable<int> rolls)
        {
            return rolls.Take(1).Sum().Equals(10);
        }
    }
}