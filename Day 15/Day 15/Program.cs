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
            //int sum = 0;
            Box[] boxes = new Box[256];
            for(int i = 0; i < boxes.Length; i++)
            {
                boxes[i] = new Box();
            }
            foreach (string part in parts)
            {
                if (part.Contains('='))
                {
                    string half = part.Split('=')[0];
                    int hash = Hash(half);
                    boxes[hash].AddLens(part);
                }
                else
                {
                    string half = part.Split('-')[0];
                    int hash = Hash(half);
                    boxes[hash].RemoveFront(half);
                }
                //sum += hash;
            }
            //Console.WriteLine("Part One: "+sum);
            int total = 0;
            for(int i = 0; i < boxes.Length; i++) 
            {
                int boxValue = boxes[i].GetBoxPower();
                int val = (i + 1) * boxValue;
                Console.WriteLine("Box " + i + ": " + (i + 1) + " * " + boxValue + " = " + val);
                total += val;
            }
            Console.WriteLine("Part Two: " + total);
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
