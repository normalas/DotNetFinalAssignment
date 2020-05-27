using System;

using DotNet.DBApplication.ViewModels;

using Windows.UI.Xaml.Controls;

namespace DotNetDBApplication.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            MainTextBlock.Text = "Welcome to Oiran\nAn application to look up games in a database";
        }
    }
}
