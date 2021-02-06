using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MCTool
{
    public interface IButton
    {
        MCButton button { get; set; }
        Image image { get; set; }

        MatrixView ope1 { get; set; }
        MatrixView ope2 { get; set; }
        MatrixView rslt { get; set; }

        void Run(object sender, RoutedEventArgs e);
    }
}
