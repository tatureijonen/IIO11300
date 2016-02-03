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

        //luodaan kokoelma mittaus-olioille
        List<MittausData> mitatut;
        public MainWindow()
        {
            InitializeComponent();
            IniMySuff();
        }

        private void IniMySuff()
        {
            //omat ikkunaan liittyvät alustukset
            txtToday.Text = DateTime.Today.ToShortDateString();
            mitatut = new List<MittausData>();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            //luodaan uusi mittausdata-olio ja näytetään se käyttäjälle
            MittausData md = new MittausData(txtClock.Text, txtData.Text);
            //lbData.Items.Add(md);//alkuperäinen tapa
            //lisätään mittaus-olio kokoelmaan
            mitatut.Add(md);
            ApplyChanges();

        }

        private void ApplyChanges()
        {
            //päivitetään UI vastaamaan kokoelman tietoja
            lbData.ItemsSource = null;
            lbData.ItemsSource = mitatut;
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

   

        private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            //TODO kutsu BL:n tallennusmetodia
            try
            {
                MittausData.SaveDataToFile(mitatut, txtFileName.Text);
                MessageBox.Show("Tiedot tallennettu onnistuneesti tiedostoon " + txtFileName.Text);
            }
            catch (Exception ex)
            {
            
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetFromFile_Click(object sender, RoutedEventArgs e)
        {
            //luetaan datat käyttäjän antamasta tiedostosta
            try
            {
                mitatut = null;
                mitatut = MittausData.ReadDataFromFile(txtFileName.Text);
                ApplyChanges();
                MessageBox.Show("Tiedot luettu onnistuneesti tiedostosta " + txtFileName.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveToXML_Click(object sender, RoutedEventArgs e)
        {
            //serialisuoidaan XML:ksi
            JAMK.IT.IIO11300.Serialisointi.SerialisoiXml(@"d:\testi.xml", mitatut);
        }
    }
}
