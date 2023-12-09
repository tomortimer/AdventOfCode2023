using System;
using MorteTools;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Day_7
{
    class Hand
    {
        private int[] hand = new int[5];
        //0 - 6
        private int power;

        public Hand(string input) 
        {
            for(int i  = 0; i < 5; i++)
            {
                string tmp = input.Substring(i, 1);
                switch (tmp)
                {
                    case "T":
                        tmp = "10";
                        break;
                    case "J":
                        tmp = "1";
                        break;
                    case "Q":
                        tmp = "12";
                        break;
                    case "K":
                        tmp = "13";
                        break;
                    case "A":
                        tmp = "14";
                        break;
                }
                hand[i] = Convert.ToInt32(tmp);
            }
            //now parse type of hand#
            int jkrCount = CountChar(input, 'J');
            if (Regex.IsMatch(input, "([AQKJT2-9])\\1\\1\\1\\1")) { power = 6; }//5 of a kind
            else
            {
                //otherwise need to parse differently
                List<char> testedChars = new List<char>();
                int numQuad = 0;
                int numTrip = 0;
                int numPairs = 0;
                
                input = input.Replace('J', ' ');
                for (int x = 0; x < 5; x++)
                {
                    char tmp = input[x];
                    if (!testedChars.Contains(tmp) && tmp != ' ')
                    {
                        int ctr = CountChar(input, tmp);
                        switch (ctr)
                        {
                            case 4: numQuad++; break;
                            case 3: numTrip++; break;
                            case 2: numPairs++; break;
                        }
                        testedChars.Add(tmp);
                    }
                }
                if(numQuad == 1) { power = 5; } // four of a kind
                else if (numTrip == 1 && numPairs == 1) { power = 4; } // full house
                else if(numTrip == 1) { power = 3; } // three of a kind
                else if(numPairs == 2) {  power = 2; } // two pair
                else if(numPairs == 1) { power = 1; } // one pair
                else { power = 0; } // hjhfahfdwhauduah
            }
            
            if (power == 5 && jkrCount == 1) { 
                power = 6; }
            else if (power == 4 && jkrCount == 1) { 
                power = 5; }
            else if(power == 3 && jkrCount == 2) { 
                power = 6; }
            else if(power == 3 && jkrCount == 1){
                power = 5; }
            else if(power == 2 && jkrCount == 1) { 
                power = 4; }
            else if(power == 1 && jkrCount == 3) { 
                power = 6; }
            else if(power == 1 && jkrCount == 2) { 
                power = 5; }
            else if(power == 1 && jkrCount == 1) { 
                power = 3; }
            else if(power == 0 && jkrCount == 5) { 
                power = 6; }
            else if (power == 0 && jkrCount == 4) { 
                power = 6; }
            else if (power == 0 && jkrCount == 3) { 
                power = 5; }
            else if (power == 0 && jkrCount == 2) { 
                power = 3; }
            else if(power == 0 && jkrCount == 1) { 
            power = 1; }
        }

        public int CompareTo(Hand comp)
        {
            int ret = 0;
            if(power < comp.GetPower()) { ret = -1; }
            else if (power > comp.GetPower()) { ret = 1; }
            else
            {
                int i = 0;
                int[] compHand = comp.GetHand();
                while(ret == 0 && i < 5)
                {
                    if (hand[i] < compHand[i])
                    {
                        ret = -1;
                    }else if (hand[i] > compHand[i]) { ret = 1; }
                    i++;
                }
            }
            return ret;
        }

        private int CountChar(string input, char c)
        {
            int ctr = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == c)
                {
                    ctr++;
                }
            }
            return ctr;
        }

        public int GetPower() { return power; }
        public int[] GetHand() { return hand; }
        public string ToString()
        {
            string tmp = "";
            for(int x = 0; x < 5; x++) { tmp += hand[x] + ","; }
            return tmp;
        }

    }
}
