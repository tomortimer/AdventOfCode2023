using MorteTools;
using System.Windows.Markup;
namespace Day_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();
            string input = fp.GetLinesFromTxt("input.txt")[0];
            string[] parts = input.Split(',');
            int sum = 0;
            foreach (string part in parts)
            {
                sum += Hash(part);
            }
            Console.WriteLine("Part One: "+sum);
        }

        static int Hash(string inp)
        {
            int currentValue = 0;
            foreach(char c in inp)
            {
                currentValue += c;
                currentValue *= 17;
                currentValue %= 256;
            }
            return currentValue;
        }
    }
}
