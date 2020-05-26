using System;

using DotNet.DBApplication.Core.Models;
using DotNet.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DotNetDBApplication.Views
{
    public sealed partial class MasterDetailDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }
        public VideoGame VideoGameItem
        {
            get { return GetValue(VideoGameItemProperty) as VideoGame; }
            set { SetValue(VideoGameItemProperty, value); }
        }
        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(MasterDetailDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));
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
