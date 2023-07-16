using GiftoPngConvertor.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GiftoPngConvertor.Entities
{
    public class ConverterEntity
    {
        public string GifFilePath { get; set; }
        public string OutputFolderPath { get; set; }
        public string OutputFilePath { get;set; }
        public int DesiredHeight { get; set; } = 128;
        public int DesiredWidth { get; set; } = 128;
        public FileExtensionType FileExtensionType { get; set; } = FileExtensionType.PNG;
        public List<string> base64Images { get; set; } = new List<string>();
        public List<byte[]> bytesImages { get; set; } = new List<byte[]>(); 
    }
}
