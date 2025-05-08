using System;

namespace web_model
{
    [Serializable]
    public class PictureInfo
    {
        public int Indexs { get; set; }

        public string Name { get; set; }
        public string PathSource { get; set; }
    
        public int Kindof { get; set; }
        public long Size { get; set; }

       
    }
}

