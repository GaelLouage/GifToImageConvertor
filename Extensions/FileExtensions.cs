using GiftoPngConvertor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftoPngConvertor.Extensions
{
    public static class FileExtensions
    {
        public static string SetFileExtension(this string outputFilePath, string outputfolderPath,int frameIndex, FileExtensionType extensionType)
        {
            var extensionsDictionary = new Dictionary<FileExtensionType, string>()
            {
                {FileExtensionType.PNG, System.IO.Path.Combine(outputfolderPath, $"frame_{frameIndex}.png") },
                {FileExtensionType.JPG, System.IO.Path.Combine(outputfolderPath, $"frame_{frameIndex}.jpg")},
                {FileExtensionType.JPEG, System.IO.Path.Combine(outputfolderPath, $"frame_{frameIndex}.jpeg")}
            };
            return extensionsDictionary[extensionType];
        }
    }
}
