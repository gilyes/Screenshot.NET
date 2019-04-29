using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Media.Imaging;
using Size = System.Drawing.Size;

namespace GI.Screenshot
{
    public class Screenshot
    {
        public static BitmapSource CaptureAllScreens()
        {
            return CaptureRegion(new Rect(SystemParameters.VirtualScreenLeft,
                                          SystemParameters.VirtualScreenTop,
                                          SystemParameters.VirtualScreenWidth,
                                          SystemParameters.VirtualScreenHeight));
        }

        public static BitmapSource CaptureRegion(ScreenshotOptions options = null)
        {
            options = options ?? new ScreenshotOptions();

            var bitmap = CaptureAllScreens();

            var left = SystemParameters.VirtualScreenLeft;
            var top = SystemParameters.VirtualScreenTop;
            var right = left + SystemParameters.VirtualScreenWidth;
            var bottom = right + SystemParameters.VirtualScreenHeight;

            var window = new RegionSelectionWindow
                         {
                             WindowStyle = WindowStyle.None,
                             ResizeMode = ResizeMode.NoResize,
                             BorderThickness = new Thickness(0),
                             BackgroundImage =
                             {
                                 Source = bitmap,
                                 Opacity = options.BackgroundOpacity
                             },
                             InnerBorder = {BorderBrush = options.SelectionRectangleBorderBrush},
                             Left = left,
                             Top = top,
                             Width = right - left,
                             Height = bottom - top
                         };

            window.ShowDialog();

            if (window.SelectedRegion == null)
            {
                return null;
            }

            return GetBitmapRegion(bitmap, window.SelectedRegion.Value);
        }

        public static BitmapSource CaptureRegion(Rect rect)
        {
            using (var bitmap = new Bitmap((int) rect.Width, (int) rect.Height, PixelFormat.Format32bppArgb))
            {
                var graphics = Graphics.FromImage(bitmap);

                graphics.CopyFromScreen((int) rect.X, (int) rect.Y, 0, 0, new Size((int) rect.Size.Width, (int) rect.Size.Height),
                                        CopyPixelOperation.SourceCopy);

                return bitmap.ToBitmapSource();
            }
        }

        private static BitmapSource GetBitmapRegion(BitmapSource bitmap, Rect rect)
        {
            if (rect.Width <= 0 || rect.Height <= 0)
            {
                return null;
            }

            return new CroppedBitmap(bitmap, new Int32Rect
                                             {
                                                 X = (int) rect.X,
                                                 Y = (int) rect.Y,
                                                 Width = (int) rect.Width,
                                                 Height = (int) rect.Height
                                             });
        }
    }
}