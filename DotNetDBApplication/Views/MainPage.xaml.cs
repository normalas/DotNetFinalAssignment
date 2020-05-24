using System;

using DotNetDBApplication.ViewModels;

using Windows.UI.Xaml.Controls;

namespace DotNetDBApplication.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
