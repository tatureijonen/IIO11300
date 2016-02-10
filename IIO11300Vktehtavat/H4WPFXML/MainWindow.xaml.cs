﻿using System;
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
using System.Xml;
using System.Xml.Linq;

namespace H4WPFXML
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

        private void btnGetXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ladataan XML-tiedosto ja asetetaan se Datagridin data context:ksi
                xe = XElement.Load(GetFileNime());
                dgData.DataContext = xe.Elements("tyontekija");

                //lasketaan työntekijöiden määrä ja palkkasumma ja näytetään ne käyttäjälle
                int lkm = 0;
                lkm = xe.Elements().Count();
                tbMessage.Text = string.Format("Akun tehtaalla on kaikkiaan {0} työntekijää, joista vakituisia {2} ja palkat yhteensä {1}", lkm, CalculateSalarySum(), CountWorkers("vakituinen"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetFileNime()
        {
            //älä kovakoodaa muuttuvia asioita koodiin
            //return "d:\\tyontekijat.xml";

            //parempi tapa on sijoittaa ne App.config
            return H4WPFXML.Properties.Settings.Default.XMLTiedosto;
        }

        private decimal CalculateSalarySum()
        {
            decimal result = 0;

            //haetaan työntekijöiden palkat xml:stä (XElement-olioon) LINQ-kyselyllä
            var palkat = from ele in xe.Elements()
                         select ele.Element("palkka");
            foreach (var item in palkat)
            {
                result += decimal.Parse(item.Value);
            }
            return result;
        }

        private int CountWorkers(string tyosuhde)
        {
            //lasketaan työsuhteen mukaiset työntekijät LINQ-kyselyllä
            var tyontekijat = from ele in xe.Elements()
                              where ele.Element("tyosuhde").Value == tyosuhde
                              select ele.Element("etunimi");

            //palautetaan lukumäärä
            return tyontekijat.Count();
        }
    }
}
