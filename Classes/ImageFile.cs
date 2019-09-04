using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageChopper.Classes
{
    public class ImageFile
    {
        public string Filename { get; set; }
        //public bool HasChanges { get; set; }
        public bool HasBeenSaved { get; set; }
        public string Person { get; set; }
        public string SaveFilePath { get; set; }
        
        public float ZoomFactor { get; set; }

        
        public ImageFile()
        {
           
            Person = string.Empty;
            Filename = string.Empty;
            ZoomFactor = 1;
           
        }


        public ImageFile(string f, string p, float z)
        {

            Filename = f;

            Person = p;
            ZoomFactor = z;
        }
        
    }
}
