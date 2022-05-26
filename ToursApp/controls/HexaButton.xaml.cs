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

namespace ToursApp.controls
{
    /// <summary>
    /// Логика взаимодействия для HexaButton.xaml
    /// </summary>
    public partial class HexaButton : UserControl
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public ImageSource ColoredSource { get; set; }

        public ImageSource BlacWhiteSource => (ColoredSource == null) ? null : new FormatConvertedBitmap((BitmapSource) ColoredSource, PixelFormats.Gray8, null, 0);

        public HexaButton()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void BtnAction_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
