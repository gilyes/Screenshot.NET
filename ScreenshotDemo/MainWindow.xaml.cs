using System.Windows;
using GI.Screenshot;

namespace ScreenshotDemo
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CaptureRegion_OnClick(object sender, RoutedEventArgs e)
        {
            ImageControl.Source = Screenshot.CaptureRegion();
        }
    }
}