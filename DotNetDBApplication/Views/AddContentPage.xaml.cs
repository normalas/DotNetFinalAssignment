using System;
using System.Threading.Tasks;
using DotNet.DBApplication.ViewModels;
using DotNet.Models;
using DotNetDBApplication.DataAccess;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
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
        private async Task AddVideoGameAsync() => await videoGameDataAccess.AddVideoGameAsync(new VideoGame()
        {
                GameTitle = titleBox.Text,
                GameSubtitle = subtitleBox.Text,          
                DeveloperName = developerBox.Text,           
                PublisherName = publisherBox.Text,           
                CharacterName = characterBox.Text
            
        });
        private async void confirmButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await AddVideoGameAsync();
            
        }
    }
}
