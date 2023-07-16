using GiftoPngConvertor.Entities;
using GiftoPngConvertor.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftoPngConvertor.Services.Interfaces
{
    public interface IConverter
    {
        string GifConverter(ConverterEntity converter);
        void GifConverterToByteArray(ConverterEntity converter);
    }
}
