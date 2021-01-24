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

using System.Data;
using System.Numerics;
using NuCalc;
using Microsoft.Win32;

namespace MatrixCalc
{
    /// <summary>
    /// MatrixView.xaml の相互作用ロジック
    /// </summary>
    public partial class MatrixView : UserControl
    {
        public MatrixView()
        {
            InitializeComponent();
            dg.AutoGenerateColumns = true;
            dg.CanUserAddRows = false;
            dg.DataContext = dt;

            nudRowSize.ValueChanged += nudRowSizeChanged;
            nudColSize.ValueChanged += nudColSizeChanged;
        }

        int _RowSize = 1;
        public int RowSize 
        { 
            get
            {
                return _RowSize;
            }
            set
            {
                _RowSize = value;

                mat = new matrix(_RowSize, _ColSize, false);
            }
        }
        int _ColSize = 1;
        public int ColSize
        {
            get
            {
                return _ColSize;
            }
            set
            {
                _ColSize = value;
                mat = new matrix(_RowSize, _ColSize, false);
            }
        }

        public DataTable dt { get; set; } = new DataTable();
        List<int> RowIndex { get; set; } = new List<int>();

        public matrix mat
        {
            get
            {
                matrix ret = new matrix(dt.Rows.Count, dt.Columns.Count - 1, false);
                for (int row = 0; row < ret.row_size; row++)
                {
                    for (int col = 0; col < ret.col_size; col++)
                    {
                        ret[row, col] = (Complex)dt.Rows[row][col + 1];
                    }
                }

                return ret;
            }
            set
            {
                dg.DataContext = null;
                dt.Rows.Clear();
                dt.Columns.Clear();
                if (value == null)
                {
                    return;
                }
                dt.Columns.Add("RowIndex", typeof(int));
                for (int col = 0; col < value.col_size; col++)
                {
                    dt.Columns.Add(col.ToString(), typeof(Complex));
                }

                for (int row = 0; row < value.row_size; row++)
                {
                    DataRow dr = dt.NewRow();
                    dr["RowIndex"] = row;
                    for (int col = 0; col < value.col_size; col++)
                    {
                        dr[col + 1] = value[row, col];
                    }
                    dt.Rows.Add(dr);
                }

                dg.DataContext = dt;

                RowIndex.Clear();
                for (int i = 0; i < value.row_size; i++)
                {
                    RowIndex.Add(i);
                }

                dg.Columns[0].Visibility = Visibility.Hidden;
                dg.Columns[0].CanUserResize = true;
            }
        }

        bool _Enable = false;
        public bool Enable
        {
            get
            {
                return _Enable;
            }
            set
            {
                _Enable = value;

                if (_Enable == false)
                {
                    dg.IsEnabled = false;
                    nudRowSize.Enable = false;
                    nudColSize.Enable = false;
                }
                else
                {
                    dg.IsEnabled = true;
                    nudRowSize.Enable = true;
                    nudColSize.Enable = true;
                }
            }
        }

        private void dg_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int target_row_display_index = e.Row.GetIndex();
            int target_col_display_index = e.Column.DisplayIndex;

            string value = ((TextBox)e.EditingElement).Text;
            value = value.Replace("(", "");
            value = value.Replace(")", "");
            string[] cmp_str = value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (cmp_str.Length != 2)
            {
                e.EditingElement.DataContext = dt.Rows[target_row_display_index][target_col_display_index - 1];
                return;
            }
            double re = 0, im = 0;
            if (double.TryParse(cmp_str[0], out re) == false)
            {
                e.EditingElement.DataContext = dt.Rows[target_row_display_index][target_col_display_index - 1];
                return;
            }
            if (double.TryParse(cmp_str[1], out im) == false)
            {
                e.EditingElement.DataContext = dt.Rows[target_row_display_index][target_col_display_index - 1];
                return;
            }
            Complex cmp = new Complex(re, im);
            dt.Rows[e.Row.GetIndex()][e.Column.DisplayIndex] = cmp;
        }

        void nudRowSizeChanged()
        {
            RowSize = nudRowSize.Value;
        }
        void nudColSizeChanged()
        {
            ColSize = nudColSize.Value;
        }

        private void ReadClick(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != true)
            {
                return;
            }

            mat = matrix.Load(ofd.FileName);
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != true)
            {
                return;
            }

            matrix.Save(mat, sfd.FileName, "E");
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
