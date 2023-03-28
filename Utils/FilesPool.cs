using System;
using System.Collections.Generic;
using System.Linq;

namespace Learn
{
    class FilesPool
    {
        ReadTxt readTxt;
        ReadFiles readFiles;
        List<FileEntity> material;
        List<string> strLst;
        int indexCounter;
        public FilesPool()
        {
            readTxt = new ReadTxt();
            readFiles = new ReadFiles();
            strLst = JoinStringArrays();
            material = PrepareLearningMaterial(material);
            indexCounter = material.Count - 1;
        }

        List<string> JoinStringArrays()
        {
            return readTxt.GetLinksStringList().Concat(readFiles.GetFilesStringList()).ToList();
        }

        List<FileEntity> PrepareLearningMaterial(List<FileEntity> m)
        {
            m = new List<FileEntity>();
            foreach (string str in strLst)
            {
                switch (str)
                {
                    case var _ when str.Contains("http"):
                        m.Add(new FileEntity()
                        {
                            path = str,
                            type = FileType.Link
                        });
                        break;

                    default:
                        m.Add(new FileEntity()
                        {
                            path = str,
                            type = FileType.Image
                        });
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
            if (indexCounter == 0)
            {
                indexCounter = material.Count - 1;
                return material[0];
            }
            return material[indexCounter--];
        }

        public enum FileType
        {
            Link,
            Image
        }
    }

    internal class FileEntity
    {
        public string path;
        public FilesPool.FileType type;
    }
}