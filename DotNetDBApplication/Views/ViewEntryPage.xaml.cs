using System;

using DotNetDBApplication.ViewModels;

using Windows.UI.Xaml.Controls;

namespace DotNetDBApplication.Views
{
    public sealed partial class ViewEntryPage : Page
    {
        public ViewEntryViewModel ViewModel { get; } = new ViewEntryViewModel();

        public ViewEntryPage()
        {
            InitializeComponent();
        }
    }
}
