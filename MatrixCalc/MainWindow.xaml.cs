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
using System.Numerics;

using NuCalc;

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
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            btClear_Click(null, new RoutedEventArgs());
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            ope1.mat = new matrix(1, 1, false);
            ope1.Enable = true;

            ope2.mat = new matrix(1, 1, false);
            ope2.Enable = true;

            res.mat = null;
            res.Enable = false;
        }

        private void btEqual_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ope1.Enable = !ope1.Enable;
        }

        private void btNewMatrix_Click(object sender, RoutedEventArgs e)
        {
            matrix x = new matrix(2, 3, false);
            x[0, 0] = new Complex(0, 1); x[0, 1] = new Complex(1, 0); x[0, 2] = new Complex(1, 1);
            x[1, 0] = new Complex(-1, 1); x[1, 1] = new Complex(2, 0); x[1, 2] = new Complex(0, -2);
            x.transposed = true;

            MatrixView mv2 = new MatrixView();
            mv2.mat = x;

            grid.Children.Add(mv2);

            
        }

        private void btPlus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                res.mat = ope1.mat + ope2.mat;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            res.mat = ope1.mat - ope2.mat;
        }

        private void btMultiply_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            res.mat = ope1.mat * ope2.mat;
        }

        private void btInv_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btTrans_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ope1.mat.transposed = !ope1.mat.transposed;
            matrix tmp = new matrix(ope1.mat);
            tmp.transposed = true;
            res.mat = tmp;
        }

        private void btDet_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Complex det = ope1.mat.Determinant();
            matrix tmp = new matrix(1, 1, false);
            tmp[0, 0] = det;
            res.mat = tmp;
        }
    }
}
