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

namespace MCTool
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

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            dockPanel.Width = userControl.Width;
            dockPanel.Height = userControl.Height;
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            if (IsEnabled == false)
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

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            if (IsEnabled == false)
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

        private void dockPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            tb.Width = this.Width - stackPanel.Width - 1;
            tb.Height = this.Height;

            btnUp.Height = stackPanel.Height / 2;
            btnDown.Height = stackPanel.Height / 2;
        }

    }
}
