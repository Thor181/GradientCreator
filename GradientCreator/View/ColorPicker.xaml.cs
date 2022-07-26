using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using Media = System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace GradientCreator.View
{
    public partial class ColorPicker : UserControl
    {
        private readonly Bitmap bitmap;
        private Media.Color _selectedColor;

        public Media.Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                PopupToggleButton.Background = new Media.SolidColorBrush(Media.Color.FromRgb(value.R, value.G, value.B));
            }
        }

        public Media.Brush ColorStr { get; set; }

        public ColorPicker()
        {
            InitializeComponent();
            bitmap = (Bitmap)System.Drawing.Image.FromFile(@"Resources\colorMap.png");
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var color = GetColorFromPoint(e.GetPosition((IInputElement)sender));
            SelectedColor = Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            MainPopup.IsOpen = false;
        }
        private Color GetColorFromPoint(System.Windows.Point point)
        {
            return bitmap.GetPixel((int)point.X, (int)point.Y);
        }

        private void ImagePlace_MouseMove(object sender, MouseEventArgs e)
        {
            var color = GetColorFromPoint(e.GetPosition((IInputElement)sender));
            ColorStr = new Media.SolidColorBrush(Media.Color.FromRgb(color.R, color.G, color.B));
            PreviewPopup.SetPopupOffset();
            PreviewPopupGrid.Background = ColorStr;
        }

    }
    public static class Extensions
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out System.Drawing.Point point);

        public static void SetPopupOffset(this Popup popup)
        {
            GetCursorPos(out System.Drawing.Point mousePointOfScreen);
            popup.HorizontalOffset = mousePointOfScreen.X + 5;
            popup.VerticalOffset = mousePointOfScreen.Y + 5;
        }

    }

}
