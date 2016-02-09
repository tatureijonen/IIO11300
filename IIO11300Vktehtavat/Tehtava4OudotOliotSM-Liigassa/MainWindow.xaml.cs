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
            bool valid = false;
            bool pelaajavalid = true;
            valid = textBoxValidator();
            if(valid == true)
            {
                pelaaja.Etunimi = txtBoxEtunimi.Text;
                pelaaja.Sukunimi = txtBoxSukunimi.Text;
                pelaaja.Siirtohinta = txtBoxHinta.Text;
                pelaaja.Seura = comboBoxSeura.Text;
                int index = pelaajat.Count;
                for (int i = 0; i < index; i++)
                {
                    if(index == i)
                    {
                        break;
                    }
                    if(pelaaja.KokoNimi != pelaajat[i].KokoNimi)
                    {
                        pelaajavalid = true;
                    }
                    else
                    {
                        statusBar.Text = "Pelaaja on jo olemassa";
                        pelaajavalid = false;
                        break;
                    }
                }
                if (pelaajavalid == true)
                {
                    statusBar.Text = "Pelaaja " + pelaaja.KokoNimi + " lisätty!";
                    pelaajat.Add(pelaaja);
                    listBoxNimi.Items.Add(pelaaja.EsitysNimi);
                }
                  
            }
        }


        public bool textBoxValidator()
        {
            if (string.IsNullOrWhiteSpace(txtBoxEtunimi.Text) ||
                string.IsNullOrWhiteSpace(txtBoxSukunimi.Text) ||
                string.IsNullOrWhiteSpace(txtBoxHinta.Text) ||
                string.IsNullOrWhiteSpace(comboBoxSeura.Text))
            {
                MessageBox.Show("Syötä puuttuvat tiedot");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void list_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            if (listBoxNimi.SelectedValue == null) return;

            var pelaaja = pelaajat.FirstOrDefault<Liiga>(p => p.EsitysNimi == listBoxNimi.SelectedValue.ToString());

            if (pelaaja != null)
            {
                txtBoxEtunimi.Text = pelaaja.Etunimi;
                txtBoxSukunimi.Text = pelaaja.Sukunimi;
                txtBoxHinta.Text = pelaaja.Siirtohinta;
                comboBoxSeura.SelectedValue = pelaaja.Seura;
                
            }
        }

       
    }
}
