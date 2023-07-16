using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace GiftoPngConvertor.Extensions
{
    public static class StreamExtensions
    {
        public static byte[] StreamToByteArray(this BitmapFrame frame)
        {
            byte[] frameBytes;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(frame);
                encoder.Save(memoryStream);
                frameBytes = memoryStream.ToArray();
            }
            return frameBytes;
        }
    }
}
