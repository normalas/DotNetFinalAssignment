using System;

using DotNet.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DotNetDBApplication.Views
{
    public sealed partial class MasterDetailDetailControl : UserControl
    {

        
        public VideoGame VideoGameItem
        {
            get { return GetValue(VideoGameItemProperty) as VideoGame; }
            set { SetValue(VideoGameItemProperty, value); }
        }
        public static readonly DependencyProperty VideoGameItemProperty = DependencyProperty.Register("VideoGameItem", typeof(VideoGame), typeof(MasterDetailDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public MasterDetailDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MasterDetailDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }

    }
}
