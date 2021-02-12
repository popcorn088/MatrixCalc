using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

using MCTool;
using System.Windows.Media.Imaging;

namespace PlusButton
{
    public class Plus : IButton 
    {
        public MCButton button { get; set; }
        public Image image
        {
            get
            {
                BitmapImage bmp = new BitmapImage(new Uri(@"C:\Users\popcorn\Desktop\MatrixCalc\MatrixCalc\bin\Debug\Det.png"));
                Image img = new Image();
                img.Source = bmp;
                return img;
            }
            set
            {
            }
        }

        public MatrixView ope1 { get; set; }
        public MatrixView ope2 { get; set; }
        public MatrixView rslt { get; set; }

        public Plus()
        {
            button = new MCButton();
            button.SetImage(image);
            button.Click += Run;
        }
        
        public void Run(object sender, RoutedEventArgs e)
        {
            rslt.mat = ope1.mat + ope2.mat;
        }
    }
}
