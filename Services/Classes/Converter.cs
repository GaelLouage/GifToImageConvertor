using GiftoPngConvertor.Entities;
using GiftoPngConvertor.Enums;
using GiftoPngConvertor.Extensions;
using GiftoPngConvertor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Resources.ResXFileRef;

namespace GiftoPngConvertor.Services.Classes
{
    public class Converter : IConverter 
    {
        public string GifConverter(ConverterEntity converter) 
        {
            try
            {
                using (FileStream gifStream = new FileStream(converter.GifFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    GifBitmapDecoder decoder = new GifBitmapDecoder(gifStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    int frameCount = decoder.Frames.Count;

                    for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                    {
                        BitmapFrame frame = decoder.Frames[frameIndex];

                        // Calculate the desired width and height while maintaining the aspect ratio
                        double widthRatio = (double)converter.DesiredWidth / frame.PixelWidth;
                        double heightRatio = (double)converter.DesiredHeight / frame.PixelHeight;
                        double scaleFactor = Math.Min(widthRatio, heightRatio);

                        int newWidth = (int)(frame.PixelWidth * scaleFactor);
                        int newHeight = (int)(frame.PixelHeight * scaleFactor);

                        // Resize the image
                        TransformedBitmap resizedBitmap = new TransformedBitmap(frame, new ScaleTransform(scaleFactor, scaleFactor));

                        converter.OutputFilePath = converter.OutputFilePath.SetFileExtension(converter.OutputFolderPath, frameIndex, converter.FileExtensionType);

                        PngBitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(resizedBitmap));

                        using (FileStream pngStream = new FileStream(converter.OutputFilePath, FileMode.Create, FileAccess.Write))
                        {
                            encoder.Save(pngStream);
                        }
                    }
                }
                return "Successfully created frames";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void GifConverterToByteArray(ConverterEntity converter)
        {
            try
            {
                    using (Stream gifStream = File.OpenRead(converter.GifFilePath))
                    {
                        GifBitmapDecoder decoder = new GifBitmapDecoder(gifStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                        int frameCount = decoder.Frames.Count;

                        for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                        {
                            BitmapFrame frame = decoder.Frames[frameIndex];
                            byte[] frameBytes = frame.StreamToByteArray();
                            converter.bytesImages.Add(frameBytes);
                        }
                    }
            }
            catch {}
        }
    }
}
