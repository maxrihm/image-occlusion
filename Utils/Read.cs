using System.Collections.Generic;
using System.IO;

namespace Learn
{
    public class Read
    {
        private readonly MainControl _mainControl;
        private readonly FilesPool _filesPool;
        private readonly List<string> _history;

        public Read(MainControl mainControl, FilesPool filesPool)
        {
            _mainControl = mainControl;
            _filesPool = filesPool;
            _history = new List<string>();
        }

        public void LoadMaterial(bool materialRandom)
        {
            var fileEntity = materialRandom ? _filesPool.GetRandomEntity() : _filesPool.GetEntity();

            if (fileEntity.Type == FileType.Link)
            {
                _mainControl.SetBrowser(fileEntity.Path);
            }
            else
            {
                _mainControl.SetPanel(fileEntity.Path);
            }

            _history.Add(fileEntity.Path);
        }
    }
}