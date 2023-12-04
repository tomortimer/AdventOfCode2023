namespace MorteTools
{
    public class FileParser
    {
        public FileParser() { }

        public string ReadFromTxt(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }

        public List<string> GetLinesFromTxt(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            List<string> lines = new List<string>();
            string line = reader.ReadLine();
            while (line != null)
            {

                lines.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();
            return lines;
        }

        public List<string> GetLinesFromTxtTrimmed(string filename, int startIndex)
        {
            StreamReader reader = new StreamReader(filename);
            List<string> lines = new List<string>();
            string line = reader.ReadLine();
            while (line != null)
            {

                lines.Add(line.Substring(startIndex));
                line = reader.ReadLine();
            }
            reader.Close();
            return lines;
        }
    }
}
