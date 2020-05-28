using System;

using DotNet.DBApplication.ViewModels;
using DotNet.Models;
using DotNetDBApplication.DataAccess;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DotNetDBApplication.Views
{
    public sealed partial class ViewContentPage : Page
    {
        public ViewContentViewModel ViewModel { get; } = new ViewContentViewModel();
        public VideoGames videoGameDataAccess = new VideoGames();

        public ViewContentPage()
        {
            InitializeComponent();
        }

        private async void ConfirmButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await videoGameDataAccess.UpdateVideoGameAsync(new VideoGame() //må få inn objektet fra der den kommer fra
            {
                Game = new Game()
                {
                    GameTitle = titleBox.Text,
                    GameSubtitle = subtitleBox.Text,
                },
                Developer = new Developer()
                {
                    DeveloperName = developerBox.Text
                },
                Publisher = new Publisher()
                {
                    PublisherName = publisherBox.Text
                }
            });
        }

        private void DeleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var vg = (VideoGame)e.Parameter;
            if (vg == null)
            {
                titleBox.Text = "Nothing selected";
            }
            else
            { 
                titleBox.Text = vg.Game.GameTitle;
                subtitleBox.Text = vg.Game.GameSubtitle;
                developerBox.Text = vg.Developer.DeveloperName;
                publisherBox.Text = vg.Publisher.PublisherName;
            }
            
        }
    }
}
