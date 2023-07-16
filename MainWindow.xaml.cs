using GiftoPngConvertor.Constants;
using GiftoPngConvertor.Entities;
using GiftoPngConvertor.Enums;
using GiftoPngConvertor.Helpers;
using GiftoPngConvertor.Services.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GiftoPngConvertor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IConverter _converter;
        private ConverterEntity _converterEntity;
        private ObservableCollection<ImageData> bitmaps = new ObservableCollection<ImageData>();
        public MainWindow(IConverter converter)
        {
            _converter = converter;
            _converterEntity = new ConverterEntity();
        }

        public MainWindow() : this(new GiftoPngConvertor.Services.Classes.Converter())
        {
            InitializeComponent();
            convertComboBox.ItemsSource = Enum.GetValues(typeof(FileExtensionType)).Cast<FileExtensionType>().ToList();
            // loop through the class and getfields
            cmbPixelSize.ItemsSource = typeof(PixelSize)
                                       .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                       .Where(f => f.FieldType == typeof(int))
                                       .Select(f => f.GetValue(null))
                                       .Cast<int>();
        }

        private void OutputFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                _converterEntity.OutputFolderPath = dialog.SelectedPath;
                outputFolderTextBox.Text = _converterEntity.OutputFolderPath;
            }
        }
        private void FileDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            imgsBytes.ItemsSource = null;
            bitmaps.Clear();
            _converterEntity.bytesImages.Clear();
            var dialog = DialogHelper.FileDialog();
            if (dialog.isDialog == true)
            {
                _converterEntity.GifFilePath = dialog.fileName;
                fileDirectoryTextBox.Text = _converterEntity.GifFilePath;
                _converter.GifConverterToByteArray(_converterEntity);
            }
            MemoryHelper.AddBitMaps(_converterEntity, bitmaps);
            imgsBytes.ItemsSource = bitmaps;
            bitmaps = new ObservableCollection<ImageData>();
        }
        private void cmbPixelSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbPixelSize.SelectedItem != null)
            {
                _converterEntity.DesiredWidth = (int)cmbPixelSize.SelectedItem;
                _converterEntity.DesiredHeight = (int)cmbPixelSize.SelectedItem;
            }
        }
        private void convertComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmbSelections = new Dictionary<FileExtensionType, FileExtensionType>()
            {
                {FileExtensionType.PNG, FileExtensionType.PNG },
                {FileExtensionType.JPG,FileExtensionType.JPG},
                {FileExtensionType.JPEG,FileExtensionType.JPEG }
            };
            if (cmbSelections.ContainsKey((FileExtensionType)convertComboBox.SelectedValue))
            {
                _converterEntity.FileExtensionType = cmbSelections[(FileExtensionType)convertComboBox.SelectedValue];
            }
        }
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            var validation = _converterEntity.ConverterPathsValidation();
            if (!validation.isValid)
            {
                System.Windows.MessageBox.Show(validation.errorText, "Error", MessageBoxButton.OK);
                return;
            }
            var gifConverter = _converter.GifConverter(_converterEntity);
            validation.errorText = gifConverter;
            System.Windows.MessageBox.Show(gifConverter, "", MessageBoxButton.OK);
        }
    }
}
