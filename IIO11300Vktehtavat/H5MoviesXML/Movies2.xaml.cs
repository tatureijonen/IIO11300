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
using System.Windows.Shapes;
using System.Xml;

namespace H5MoviesXML
{
    /// <summary>
    /// Interaction logic for Movies2.xaml
    /// </summary>
    public partial class Movies2 : Window
    {
        public Movies2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //tallennetaan muuttunut tieto XML-tiedostoon
            try
            {
                string filu = xdpMovies.Source.LocalPath;
                xdpMovies.Document.Save(filu);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            if (lbMovies.SelectedIndex > -1)
            {
                //lisätään XML-dokumenttiin uusi elementti
                //HUOM! textboxit ja listbox bindattu dataan
                lbMovies.SelectedIndex = -1;
            }
            else
            {
                string filu = xdpMovies.Source.LocalPath;
                //viittaus xml-dokumenttiin ja sen juurielementtiin juurielementtiin
                XmlDocument doc = xdpMovies.Document;
                XmlNode root = doc.SelectSingleNode("/Movies");
                //luodaan uusi node
                XmlNode newMovie = doc.CreateElement("Movie");

                XmlAttribute attr = doc.CreateAttribute("Name"); //nimi
                newMovie.Attributes.Append(attr);
                attr.Value = txtName.Text;
                newMovie.Attributes.Append(attr);

                XmlAttribute attr2 = doc.CreateAttribute("Director"); //ohjaaja
                attr2.Value = txtDirector.Text;
                newMovie.Attributes.Append(attr2);

                XmlAttribute attr3 = doc.CreateAttribute("Country"); //maa
                attr3.Value = txtCountry.Text;
                newMovie.Attributes.Append(attr3);

                root.AppendChild(newMovie);
                //tallennetaan filuun
                xdpMovies.Document.Save(filu);
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Poistetaan XML-dokumentista valittu elementti
        }
    }
}
