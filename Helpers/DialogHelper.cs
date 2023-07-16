using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftoPngConvertor.Helpers
{
    public static class DialogHelper
    {
        public static (bool? isDialog, string fileName) FileDialog()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Select a file";
            dialog.DefaultExt = "*.*";
            dialog.Filter = "All Files (*.*)|*.*";
            return (isDialog: dialog.ShowDialog(), fileName: dialog.FileName);
        }
    }
}
