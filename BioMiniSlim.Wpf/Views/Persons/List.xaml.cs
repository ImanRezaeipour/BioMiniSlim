using BioMiniSlim.Service.Services.Persons;
using System.Windows;
using System.Windows.Input;
using BioMiniSlim.Core.Models;
using BioMiniSlim.Wpf.Framework.DependencyResolver;
using Ninject;
using Telerik.Windows.Controls;

namespace BioMiniSlim.Wpf.Views.Persons
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List
    {
        #region Private Fields

        private readonly IPersonService _personService;

        #endregion Private Fields

        #region Public Constructors

        public List(IPersonService personService)
        {
            _personService = personService;
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        private void PersonGridView_OnLoaded(object sender, RoutedEventArgs e)
        {
            var persons = _personService.GetAll();

            PersonGridView.ItemsSource = persons;
        }

        #endregion Private Methods

        private void PersonGridView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (PersonGridView.SelectedItem == null)
                return;

            var id = ((PersonModel) PersonGridView.SelectedItem).Id;

            var model = _personService.GetModelById(id);

            var editForm = NinjectDependencyResolver.Container.Get<Edit>();
            editForm.Model = model;

            if (NavigationService != null)
                NavigationService.Content = editForm;
        }

    }
}