using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    public partial class ColorPicker : UserControl
    {
        private readonly BitmapImage bitmap;
        
        public ColorPicker()
        {
            InitializeComponent();
            
            bitmap = new BitmapImage(new Uri("pack://application:,,,/Resources/colormap.png"));
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition((IInputElement)sender);
            var a = new Pixel[bitmap.PixelHeight, bitmap.PixelWidth];
            var JUST_BREAKPOINT = string.Empty;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct Pixel
    {
        public byte Red;
        public byte Green;
        public byte Blue;
        public byte Alpha;
    }
}
