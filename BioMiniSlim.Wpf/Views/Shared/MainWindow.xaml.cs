using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BioMiniSlim.Core.Models;
using BioMiniSlim.Service.Services.Device;
using BioMiniSlim.Service.Services.Persons;
using BioMiniSlim.Wpf.Framework.DependencyResolver;
using Ninject;
using Telerik.Windows.Controls;

namespace BioMiniSlim.Wpf.Views.Shared
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            //StyleManager.ApplicationTheme = new MaterialTheme();
            InitializeComponent();

            
        }


        public void SetFrame(object page)
        {
            Frame.Content = page;
        }

        private void PersonListButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = NinjectDependencyResolver.Container.Get<Persons.List>();
        }

        private void PersonCreateButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = NinjectDependencyResolver.Container.Get<Persons.Create>();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (this.Parent is Window)
            {
                Window thisWindow = this.Parent as Window;
                thisWindow.ShowInTaskbar = true;
                thisWindow.Title = this.Header.ToString();
            }
        }

        private void PersonFindButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("لطفا اثر انگشت را قرار دهید");

            var device = NinjectDependencyResolver.Container.Get<IDeviceManager>();
            var person = NinjectDependencyResolver.Container.Get<IPersonService>();

            var capturedImage = device.GetImage();
            var template = capturedImage.Item1;

            var findPerson = person.FindByTemplate(template);

            if (findPerson == null)
                MessageBox.Show("کاربری یافت نشد");
            else
            {
                var edit = NinjectDependencyResolver.Container.Get<Persons.Edit>();
                var model = new PersonModel
                {
                    NationalCode = findPerson.NationalCode,
                    FirstName = findPerson.FirstName,
                    CreatedOn = findPerson.CreatedOn,
                    Gender = findPerson.Gender,
                    Id = findPerson.Id,
                    LastName = findPerson.LastName,
                    Image = findPerson.Templates.FirstOrDefault().FingerImage,
                    Template = findPerson.Templates.FirstOrDefault().FingerTemplate
                };
                edit.Model = model;

                Frame.Content = edit;
            }

        }
    }
}
