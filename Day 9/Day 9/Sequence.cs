using System;
using MorteTools;
namespace Day_9
{
    internal class Sequence
    {
        List<int> numbers;
        Sequence differences;
        public Sequence(List<int> input)
        {
            numbers = [.. input];
            // now calculate differences
            List<int> diffs = new List<int>();
            int zeroCtr = 0;
            for (int i = 0; i < numbers.Count() - 1; i++)
            {
                int tmp = numbers[i + 1] - numbers[i];
                diffs.Add(tmp);
                if (tmp == 0) { zeroCtr++; }
            }
            if (!(zeroCtr == diffs.Count()))
            {
                differences = new Sequence(diffs);
            }
            else { differences = null; }
        }

        public int Extrapolate()
        {
            int newTerm = 0;
            if (differences != null)
            {
                newTerm = numbers[numbers.Count() - 1] + differences.Extrapolate();
            }
            else { newTerm = numbers[numbers.Count() - 1]; }
            return newTerm;
        }

        public int ExtrapolateBackwards()
        {
            int newTerm = 0;
            if (differences != null)
            {
                newTerm = numbers[0] - differences.ExtrapolateBackwards();
            }
            else { newTerm = numbers[0]; }
            return newTerm;
        }
    }
}
