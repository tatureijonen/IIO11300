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

namespace H3MittausData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IniMySuff();
        }

        private void IniMySuff()
        {
            //omat ikkunaan liittyvät alustukset
            txtToday.Text = DateTime.Today.ToShortDateString();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            //luodaan uusi mittausdata-olio ja näytetään se käyttäjälle
            MittausData md = new MittausData(txtClock.Text, txtData.Text);
            lbData.Items.Add(md);

        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = txtFileName.Text;
            dlg.Filter = "Text Files (*.txt)|*.txt|Dat Files(*.dat)|*.dat|All files(*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                txtFileName.Text = dlg.FileName;
            }
        }

        private void btnSerialisoi_Click(object sender, RoutedEventArgs e)
        {
            try {
                JAMK.ICT.IO.Serialisointi.Serialisoi(txtFileName.Text, ); //MITÄ HELVETTIÄ TÄNNE TULEE?
            }
            catch
            {
                MessageBox.Show("No can do");
            }
        }
    }
}
