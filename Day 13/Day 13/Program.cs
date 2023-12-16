namespace Day_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MorteTools.FileParser fp = new MorteTools.FileParser();
            MorteTools.List<string> lines = fp.GetLinesFromTxt("input.txt");
            List<Map> maps = new List<Map>();
            int lineCtr = 0;
            while (lineCtr < lines.Count())
            {
                List<string> tmp = new List<string>();
                while (lineCtr < lines.Count() && lines[lineCtr] != "") 
                {
                    tmp.Add(lines[lineCtr]);
                    lineCtr++;
                }
                maps.Add(new Map(tmp));
                lineCtr++;
            }
        }
    }
}