using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace MatrixCalc
{
    /// <summary>
    /// NumericUpDown.xaml の相互作用ロジック
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        public NumericUpDown()
        {
            InitializeComponent();
        }

        public delegate void ValueChangedDelegate();
        public ValueChangedDelegate ValueChanged;

        int _Value = 1;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (_Value == value)
                {
                    return;
                }

                _Value = value;

                if (ValueChanged != null)
                {
                    ValueChanged();
                }
            }
        }

        int _MinValue = 1;
        public int MinValue
        {
            get
            {
                return _MinValue;
            }
            set
            {
                if (_MinValue == value)
                {
                    return;
                }

                _MinValue = value;
            }
        }

        int _MaxValue = 100;
        public int MaxValue
        {
            get
            {
                return _MaxValue;
            }
            set
            {
                if (_MaxValue == value)
                {
                    return;
                }

                _MaxValue = value;
            }
        }

        bool _Enable = true;
        public bool Enable
        {
            get
            {
                return _Enable;
            }
            set
            {
                if (_Enable == value)
                {
                    return;
                }

                _Enable = value;
                if (_Enable == false)
                {
                    tb.IsEnabled = false;
                    upButton.IsEnabled = false;
                    downButton.IsEnabled = false;
                    upButton.Source = (BitmapImage)this.Resources["up_disable"];
                    downButton.Source = (BitmapImage)this.Resources["down_disable"];
                }
                else
                {
                    tb.IsEnabled = true;
                    upButton.IsEnabled = true;
                    downButton.IsEnabled = true;
                    upButton.Source = (BitmapImage)this.Resources["up_enable"];
                    downButton.Source = (BitmapImage)this.Resources["down_enable"];
                }
            }
        }

        private void tb_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void upButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Enable == false)
            {
                return;
            }

            if (Value + 1 > MaxValue)
            {
                return;
            }

            Value++;
            tb.Text = Value.ToString();
        }

        private void donwButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Enable == false)
            {
                return;
            }

            if (Value - 1 < MinValue)
            {
                return;
            }

            Value--;
            tb.Text = Value.ToString();
        }
    }
}
