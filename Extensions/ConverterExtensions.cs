using GiftoPngConvertor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftoPngConvertor.Helpers
{
    public static class ConverterExtensions
    {
        public static (bool isValid, string errorText) ConverterPathsValidation(this ConverterEntity _converterEntity)
        {
            if (string.IsNullOrEmpty(_converterEntity.GifFilePath))
            {
                return (false, "GifFilePath is empty!");
            }
            else if (string.IsNullOrEmpty(_converterEntity.OutputFolderPath))
            {
                return (false, "OutputFolderPath is empty!");
            }
            return (isValid: true, errorText: "");
        }
    }
}
