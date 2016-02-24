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
using System.Xml;


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
            xe = XElement.Load(GetFileNime());
            txtBlockFileName.Text = GetFileNime();

        }

        private void btnHaeViinit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                dgWine.Items.Clear();

                if (comboBoxMaa.SelectedItem == null)
                {
                    dgWine.DataContext = xe.Elements("wine");
                }
                else
                {
                    string selectedMaa = comboBoxMaa.SelectedItem.ToString();

                    foreach (XElement viini in xe.Elements("wine"))
                    {
                        if(viini.Element("maa").Value == selectedMaa)
                        {
                            dgWine.Items.Add(viini);
                        }
                    }
                }



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

         private void ComboBox_Loaded(object sender, RoutedEventArgs e)
         {
             List<string> maat = new List<string>();
 
             try
             {
                 //maat comboboxiin, ei lisätä duplikaatteja      
                 foreach (XElement maa in xe.Descendants("maa"))
                 {
                     if (!maat.Contains(maa.Value))
                     {
                         maat.Add(maa.Value);
                     }
                 }
 
                 // ... Get the ComboBox reference.
                 var comboBoxMaa = sender as ComboBox;
 
                 // ... Assign the ItemsSource to the List.
                 comboBoxMaa.ItemsSource = maat;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
    }
}
