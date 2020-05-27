using System;

using DotNet.DBApplication.ViewModels;
using DotNet.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DotNetDBApplication.Views
{
    public sealed partial class ViewContentPage : Page
    {
        public ViewContentViewModel ViewModel { get; } = new ViewContentViewModel();

        public ViewContentPage()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is VideoGame)
            {

            }
        }
    }
}
