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
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void onClick(object sender, RoutedEventArgs e)
        {

            int[] arr1 = new int[6];
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                int randomNumber = random.Next(1,40);

                arr1[i] = randomNumber;
            }

            string lottonumbers = ConvertIntArrayToString(arr1);
            textBox_number.Text = lottonumbers;

        }

        static string ConvertIntArrayToString(int[] array)
        {
            //
            // Use string Join to concatenate the string elements.
            //
            string result = string.Join(" ", array);
            return result;
        }

    }
}
