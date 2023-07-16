using GiftoPngConvertor.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace GiftoPngConvertor.Helpers
{
    public static class MemoryHelper
    {
        public static void AddBitMaps(ConverterEntity converterEntity, ObservableCollection<ImageData> bitmaps)
        {
            for (int i = 0; i < converterEntity.bytesImages.Count(); i++)
            {
                using (MemoryStream memoryStream = new MemoryStream(converterEntity.bytesImages[i]))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = memoryStream;
                    bitmapImage.EndInit();
                    bitmaps.Add(new ImageData { ImagePath = bitmapImage });
                }
            }
        }
    }
}
