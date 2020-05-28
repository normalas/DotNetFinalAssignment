using System;

using DotNet.DBApplication.ViewModels;
using DotNet.Models;
using DotNetDBApplication.DataAccess;
using Microsoft.Graphics.Canvas.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DotNetDBApplication.Views
{
    public sealed partial class ViewContentPage : Page
    {
        public ViewContentViewModel ViewModel { get; } = new ViewContentViewModel();
        public VideoGames videoGameDataAccess = new VideoGames();
        public VideoGame videoGame;

        public ViewContentPage()
        {
            InitializeComponent();
        }

        private async void ConfirmButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            videoGame.GameTitle = titleBox.Text;
            videoGame.GameSubtitle = subtitleBox.Text;
            videoGame.DeveloperName = developerBox.Text;
            videoGame.PublisherName = publisherBox.Text;

            await videoGameDataAccess.UpdateVideoGameAsync(videoGame);
        }

        private async void DeleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await videoGameDataAccess.DeleteVideoGameAsync(videoGame);
            Frame.Navigate(typeof(MasterDetailPage));
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
                videoGame = vg;

                titleBox.Text = vg.GameTitle != null ? vg.GameTitle : "";
                subtitleBox.Text = vg.GameSubtitle != null ? vg.GameSubtitle : "";
                developerBox.Text = vg.DeveloperName != null ? vg.DeveloperName : "";
                publisherBox.Text = vg.PublisherName != null ? vg.PublisherName : "";
            }
            
        }
    }
}
