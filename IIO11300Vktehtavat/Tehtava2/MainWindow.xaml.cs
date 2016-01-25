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

namespace Tehtava2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
           
        }


        private void drawClick(object sender, RoutedEventArgs e)
        {

            Tehtava2.Lotto lotto = new Lotto();

            try
            {
                lotto.Times = int.Parse(textBox_number.Text);
            }

            catch
            {
                MessageBox.Show("Invalid input in Number of drawns textbox");
            }
            
            if(comboBox.SelectedIndex == 0) { listBox.Items.Add(lotto.DrawLottoNumbers()); }
            if(comboBox.SelectedIndex == 1) { listBox.Items.Add(lotto.DrawVikingNumbers()); }
            if (comboBox.SelectedIndex == 2) { listBox.Items.Add(lotto.DrawEuroNumbers()); }

        }

        private void clearClick(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
