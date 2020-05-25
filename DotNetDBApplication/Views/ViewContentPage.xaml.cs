using System;

using DotNet.DBApplication.ViewModels;

using Windows.UI.Xaml.Controls;

namespace DotNetDBApplication.Views
{
    public sealed partial class ViewContentPage : Page
    {
        public ViewContentViewModel ViewModel { get; } = new ViewContentViewModel();

        public ViewContentPage()
        {
            InitializeComponent();
        }
    }
}
