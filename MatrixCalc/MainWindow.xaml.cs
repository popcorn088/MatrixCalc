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

using MCTool;

using PlusButton;

namespace MatrixCalc
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {

            BitmapImage bmp = new BitmapImage(new Uri(@"C:\Users\popcorn\Desktop\MatrixCalc\MatrixCalc\bin\Debug\Det.png"));
            Image img = new Image();
            img.Source = bmp;
            Plus btn = new Plus(img);

            button_grid.Children.Add(btn.button);
            Grid.SetColumn(btn.button, 1);
            Grid.SetRow(btn.button, 1);

            btn.ope1 = ope1;
            btn.ope2 = ope2;
            btn.rslt = rslt;
        }
    }
}
