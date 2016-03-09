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


namespace Tehtava7SalasananVahvuudenTarkistaja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string salasana;
        int maara;
        int isot;
        int pienet;
        int numerot;
        int symbolit;


        public MainWindow()
        {
            InitializeComponent();


        }

        private void txtBoxSalasana_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                salasana = txtBoxSalasana.Text;
                maara = salasana.Count(char.IsLetterOrDigit);
                txtBlockMerkkeja.Text = "Merkkien määrä: " + maara.ToString();
                txtBlockIsoja.Text = "Isojen kirjainten määrä: " + Isot().ToString();
                txtBlockPienia.Text = "Pienten kirjainten määrä: " + Pienet().ToString();
                txtBlockNumeroita.Text = "Numeroiden määrä: " + Numerot().ToString();
                txtBlockErikoismerkkeja.Text = "Erikoismerkkien määrä: " + Symbolit().ToString();
                BackgroundValidator();

            }
            catch
            {
                MessageBox.Show("Jotain tapahtui");
            }

        }

        private int Isot()
        {
            isot = 0;
            for (int i = 0; i < maara; i++)
            {
                if (char.IsUpper(txtBoxSalasana.Text[i]))
                {
                    isot++;
                }
            }
            return isot;

        }

        private int Pienet()
        {
            pienet = 0;
            for (int i = 0; i < maara; i++)
            {
                if (char.IsLower(txtBoxSalasana.Text[i]))
                {
                    pienet++;
                }
            }
            return pienet;

        }

        private int Numerot()
        {
            numerot = 0;
            for (int i = 0; i < maara; i++)
            {
                if (char.IsDigit(txtBoxSalasana.Text[i]))
                {
                    numerot++;
                }
            }
            return numerot;

        }

        private int Symbolit()
        {
            symbolit = 0;
            for (int i = 0; i < maara; i++)
            {
                if (!char.IsLetterOrDigit(txtBoxSalasana.Text[i]))
                {
                    symbolit++;
                }
            }
            return symbolit;

        }

        private int SecurityValidator()
        {
            int turvallisuus = 0;
            if (Isot() != 0)
            {
                turvallisuus++;
            }
            if (Pienet() != 0)
            {
                turvallisuus++;
            }
            if (Symbolit() != 0)
            {
                turvallisuus++;
            }
            if (Numerot() != 0)
            {
                turvallisuus++;
            }
            return turvallisuus;
        }

        private void BackgroundValidator()
        {
            if (maara < 8)
            {
                txtBlockBG.Background = Brushes.Red;
                txtBlockBG.Text = "Huono";
            }

            if (maara >= 8 && SecurityValidator() > 1)
            {
                txtBlockBG.Background = Brushes.Orange;
                txtBlockBG.Text = "Välttävä";
            }

            if (maara >= 12 && SecurityValidator() > 2)
            {
                txtBlockBG.Background = Brushes.Yellow;
                txtBlockBG.Text = "Ei huono!";
            }
            if (maara >= 16 && SecurityValidator() > 3)
            {
                txtBlockBG.Background = Brushes.Green;
                txtBlockBG.Text = "Kunnon hyvä!";
            }
        }


    }
}
