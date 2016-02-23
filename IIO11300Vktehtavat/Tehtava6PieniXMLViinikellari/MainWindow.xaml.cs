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
using System.Xml.Linq;
using System.Linq;

namespace Tehtava6PieniXMLViinikellari
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XElement xe;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHaeViinit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                xe = XElement.Load(GetFileNime());
                txtBlockFileName.Text = GetFileNime();
                dgWine.DataContext = xe.Elements("wine");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private string GetFileNime()
        {
            return Tehtava6PieniXMLViinikellari.Properties.Settings.Default.XMLTiedosto;
        }
    }
}
