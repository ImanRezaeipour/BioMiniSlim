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
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit
    {
        #region Private Fields

        private readonly IDeviceManager _deviceManager;
        private readonly IPersonService _personService;

        #endregion Private Fields

        #region Public Constructors

        public Edit(IDeviceManager deviceManager, IPersonService personService)
        {
            _deviceManager = deviceManager;
            _personService = personService;
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

        public PersonModel Model { get; set; }

        #endregion Public Properties

        #region Private Methods

        private void Edit_OnLoaded(object sender, RoutedEventArgs e)
        {
            FirstNameText.Text = Model.FirstName;
            LastNameText.Text = Model.LastName;
            NationalCodeText.Text = Model.NationalCode;

            
            var previewImage = new BitmapImage();
            previewImage.BeginInit();
            previewImage.StreamSource = File.Open($"{Environment.CurrentDirectory}\\CapturedImages\\{Model.Image}", FileMode.Open);
            previewImage.EndInit();

            var radPreviewImage = new RadBitmap(previewImage);

            FingerImage.Image = radPreviewImage;

            previewImage.StreamSource.Close();
            previewImage.StreamSource.Dispose();
        }

        private void LoadImageButton_OnClick(object sender, RoutedEventArgs e)
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

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            Model.FirstName = FirstNameText.Text;
            Model.LastName = LastNameText.Text;
            Model.NationalCode = NationalCodeText.Text;

            _personService.EditByModel(Model);
            MessageBox.Show("با موفقیت کاربر ویرایش شد");
        }

        #endregion Private Methods

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("آیا از حذف کاربر اطمینان دارید؟", "", MessageBoxButton.YesNo, MessageBoxImage.Warning,
                MessageBoxResult.No, MessageBoxOptions.RightAlign);

            if (result == MessageBoxResult.Yes)
            {
                _personService.DeleteById(Model.Id);
                MessageBox.Show("کاربر با موفقیت حذف شد");
            }
        }
    }
}