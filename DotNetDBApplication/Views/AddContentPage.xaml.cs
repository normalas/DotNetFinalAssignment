using System;

using DotNet.DBApplication.ViewModels;

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
    }
}
