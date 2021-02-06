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
    /// MCButton.xaml の相互作用ロジック
    /// </summary>
    public partial class MCButton : UserControl
    {
        public MCButton()
        {
            InitializeComponent();
        }

        public void SetImage(Image image)
        {
            ImageBrush imageBrush = new ImageBrush(image.Source);
            Background = imageBrush;
            imageBrush.Stretch = Stretch.Fill;
            UpdateLayout();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click(sender, e);
            }
        }

        public RoutedEventHandler Click;
    }
}
