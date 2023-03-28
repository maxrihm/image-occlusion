using System.IO;
using System.Collections.Generic;

namespace Learn
{
    class ReadFiles : ReadTxt
    {
        static string folder = @"path\";
        static DirectoryInfo di;
        FileInfo[] files;
        public ReadFiles()
        {
            di = new DirectoryInfo(folder);
            files = di.GetFiles("*.*");
        }

        public List<string> GetFilesStringList()
        {
            List<string> lst = new List<string>();
            foreach (FileInfo file in files)
            {
                lst.Add(file.FullName);
            }
            lst.Remove(textFileDirectory);
            return lst;
        }
    }
}