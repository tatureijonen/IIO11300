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

namespace Harjoitus1MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadMediaFile();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

        private void LoadMediaFile()
        {
            try
            {
                //ladataan käyttäjän valitsema mediatiedosto
                string filu = @"D:\H8510\Media\TestVideo1.wmv";
                //tutkitaan onko tiedosto olemassa
                if (System.IO.File.Exists(filu))
                {
                    
                    mediaElement.Source = new Uri(filu);
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnPause(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }
    }
}
