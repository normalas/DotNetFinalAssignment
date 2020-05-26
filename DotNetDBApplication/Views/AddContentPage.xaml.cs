using System;

using DotNet.DBApplication.ViewModels;
using DotNet.Models;
using DotNetDBApplication.DataAccess;
using Windows.UI.Xaml.Controls;

namespace DotNetDBApplication.Views
{
    public sealed partial class AddContentPage : Page
    {
        public AddContentViewModel ViewModel { get; } = new AddContentViewModel();
        public AddContentPage()
        {
            InitializeComponent();
        }
        private VideoGames videoGameDataAccess = new VideoGames();
        private void confirmButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }
    }
}
