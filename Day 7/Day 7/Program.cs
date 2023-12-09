using System;
using System.Collections.Generic;
using MorteTools;
namespace Day_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();
            MorteTools.List<string> lines = fp.GetLinesFromTxt("input.txt");
            MorteTools.List<Hand> hands = new MorteTools.List<Hand>();
            System.Collections.Generic.Dictionary<string, int> bids = new System.Collections.Generic.Dictionary<string, int>();
            int sum = 0;
            for(int i = 0; i < lines.Count(); i++)
            {
                hands.Add(new Hand(lines[i].Substring(0, 5)));
                bids.Add(hands[i].ToString(), Convert.ToInt32(lines[i].Substring(6)));
            }
            hands = MergeSort(hands);
            for(int i = 1; i <= hands.Count(); i++)
            {
                sum += i * bids[hands[i-1].ToString()];
                Console.WriteLine(i+" x "+ bids[hands[i - 1].ToString()] + " : "+hands[i-1].ToString());
            }
            Console.WriteLine(sum);
        }

        static public MorteTools.List<Hand> MergeSort(MorteTools.List<Hand> list)
        {
            //exit recursion
            if (list.Count() <= 1) return list;

            //split list into two
            int midpoint = list.Count() / 2;
            MorteTools.List<Hand> left = new MorteTools.List<Hand>();
            MorteTools.List<Hand> right = new MorteTools.List<Hand>();
            for (int x = 0; x < midpoint; x++)
            {
                left.Add(list[x]);
            }
            for (int x = midpoint; x < list.Count(); x++)
            {
                right.Add(list[x]);
            }
            //recurse with each half
            left = MergeSort(left);
            right = MergeSort(right);
            MorteTools.List<Hand> sorted = Merge(left, right);
            return sorted;
        }

        static private MorteTools.List<Hand> Merge(MorteTools.List<Hand> left, MorteTools.List<Hand> right)
        {
            MorteTools.List<Hand> ret = new MorteTools.List<Hand>();
            // combine and sort elements
            while (left.Count() > 0 || right.Count() > 0)
            {
                //check both lists have elemnts to compare
                if (left.Count() > 0 && right.Count() > 0)
                {
                    //compare and reorder elemnts
                    if (left[0].CompareTo(right[0]) < 0)
                    {
                        ret.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        ret.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }//otherwise add remaining contents of list
                else if (left.Count() > 0)
                {
                    ret.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    ret.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            return ret;
        }

    }
}
