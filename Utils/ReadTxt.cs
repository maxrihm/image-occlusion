using System.IO;
using System.Collections.Generic;

namespace Learn
{
    class ReadTxt
    {
        string[] lines;
        public static string textFileDirectory = $@"C:\Users\Maxim\Desktop\learn\links.txt";

        public ReadTxt()
        {
            lines = File.ReadAllLines($@"{textFileDirectory}");
        }

        public List<string> GetLinksStringList()
        {
            List<string> lst = new List<string>(lines);
            return lst;
        }

    }
}