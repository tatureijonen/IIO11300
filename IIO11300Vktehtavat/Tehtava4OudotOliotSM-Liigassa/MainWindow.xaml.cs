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
using JAMK.IT.IIO11300;
using Microsoft.Win32;

namespace Tehtava4OudotOliotSM_Liigassa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        List<Liiga> pelaajat;
        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }

        public void InitializeMyStuff()
        {
            pelaajat = new List<Liiga>();
        }

        private void buttonLuoPelaaja_Click(object sender, RoutedEventArgs e)
        {
            Liiga pelaaja = new Liiga();
            try
            {
                
                listBox.Items.Add(pelaaja.EsitysNimi);
            }
            catch
            {
                MessageBox.Show("No go");
            }
            

        }
    }
}
