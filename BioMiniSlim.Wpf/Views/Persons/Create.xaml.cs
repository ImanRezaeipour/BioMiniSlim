using BioMiniSlim.Core.Models;
using BioMiniSlim.Service.Services.Device;
using BioMiniSlim.Service.Services.Persons;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Telerik.Windows.Media.Imaging;

namespace BioMiniSlim.Wpf.Views.Persons
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create
    {
        #region Private Fields

        private readonly IDeviceManager _deviceManager;
        private readonly IPersonService _personService;

        #endregion Private Fields

        #region Public Constructors

        public Create(IPersonService personService, IDeviceManager deviceManager)
        {
            _personService = personService;
            _deviceManager = deviceManager;
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

        public PersonModel Model { get; set; } = new PersonModel();

        #endregion Public Properties

        #region Private Methods

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            var captureImage = _deviceManager.GetImage();

            Model.Template = captureImage.Item1;
            Model.Image = captureImage.Item2;

            var previewImage = new BitmapImage();
            previewImage.BeginInit();
            previewImage.StreamSource = File.Open($"{Environment.CurrentDirectory}\\CapturedImages\\{captureImage.Item2}", FileMode.Open);
            previewImage.EndInit();

            var radPreviewImage = new RadBitmap(previewImage);

            FingerImage.Image = radPreviewImage;

            previewImage.StreamSource.Close();
            previewImage.StreamSource.Dispose();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Model.FirstName = FirstNameText.Text;
            Model.LastName = LastNameText.Text;
            Model.NationalCode = NationalCodeText.Text;

            _personService.CreateByModel(Model);
            MessageBox.Show("با موفقیت کاربر ایجاد شد");
        }

        #endregion Private Methods
    }
}