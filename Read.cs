using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Learn
{

    public class Read
    {
        MainControl mainControl;
        FilesPool material;
        List<string> history;
        

        public Read(MainWindow mw) 
        {
            mainControl = new(mw);
            material = new();
            history = new();
        }

        public void LoadMaterial(bool materialRandom)
        {
            FileEntity materialEntity;
            if (materialRandom)
            {
                do
                {
                    materialEntity = material.GetRandomEntity();
                    history.Add(materialEntity.path);
                }
                while (materialEntity.path == history.Take(history.Count - 1).LastOrDefault() && history.Count > 1);
            }
            else
            {
                materialEntity = material.GetEntity();
            }

            if(materialEntity.type == FileEntity.Type.Link)
            {
                mainControl.SetBrowser(materialEntity.path);
            }
            else
            {
                mainControl.SetPanel(materialEntity.path);
            }

        }
    }

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

    class ReadFiles : ReadTxt
    {
        static string folder = @"C:\Users\Maxim\Desktop\learn";
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

    class FilesPool
    {
        ReadTxt readTxt;
        ReadFiles readFiles;
        List<FileEntity> material;
        List<string> strLst;
        int indexCounter;

        public FilesPool() 
        {
            readTxt = new();
            readFiles = new();
            strLst = JoinStringArrays();
            material = PrepareLearningMaterial(material);
            indexCounter = material.Count-1;
        }

        List<string> JoinStringArrays()
        {
            return readTxt.GetLinksStringList().Concat(readFiles.GetFilesStringList()).ToList();
        }

        List<FileEntity> PrepareLearningMaterial(List<FileEntity> m)
        {
            m = new();
            foreach(string str in strLst)
            {
                switch (str)
                {
                    case var _ when str.Contains("http"):
                        m.Add(new FileEntity()
                            {
                                path = str,
                                type = FileEntity.Type.Link
                            }
                        );
                        break;

                    default:
                        m.Add(new FileEntity()
                            {
                                path = str,
                                type = FileEntity.Type.Image
                            }
                        );
                        break;
                }
            }
            return ShuffleObjectList(m);
        }

        List<FileEntity> ShuffleObjectList(List<FileEntity> objList)
        {
            var rnd = new Random();
            return objList.OrderBy(item => rnd.Next()).ToList();
        }

        public FileEntity GetRandomEntity()
        {
            var rnd = new Random();
            int index = rnd.Next(material.Count);
            return material[index];
        }

        public FileEntity GetEntity()
        {
            if(indexCounter == 0)
            {
                indexCounter = material.Count - 1;
                return material[0];
            }
            return material[indexCounter--];
        }

    }

    internal class FileEntity
    {
        public string path;
        public Type type;

       public enum Type
        {
            Link,
            Image
        }
    }
}
