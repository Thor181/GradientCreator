using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GradientCreator.View
{
    /// <summary>
    /// Логика взаимодействия для ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        private BitmapImage bitmap;
        public ColorPicker()
        {
            InitializeComponent();
            Uri uri = new Uri("pack://application:,,,/Resources/colormap.png");
            bitmap = new BitmapImage(uri);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            

            Point p = e.GetPosition((IInputElement)sender);
            Pixel[,] pixels = new Pixel[bitmap.PixelHeight, bitmap.PixelWidth];
            bitmap.CopyPixels(pixels, bitmap.PixelWidth * 4, 0);

            var JUST_BREAKPOINT = string.Empty;
        }
    }
    public struct Pixel
    {
        public byte Red;
        public byte Green;
        public byte Blue;
        public byte Alpha;
    }
}
