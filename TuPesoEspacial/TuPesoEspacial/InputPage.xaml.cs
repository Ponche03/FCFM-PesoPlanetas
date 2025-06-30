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

namespace TuPesoEspacial
{
    public partial class InputPage : Page
    {
        public InputPage()
        {
            InitializeComponent();
            Loaded += (s, e) => WeightTextBox.Focus();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Text = "";

            // Validar el peso
            if (double.TryParse(WeightTextBox.Text, out double earthWeight))
            {
                if (earthWeight > 0)
                {
                    this.NavigationService.Navigate(new NameInputPage(earthWeight));
                }
                else
                {
                    ErrorTextBlock.Text = "Por favor, introduce un peso mayor a cero.";
                }
            }
            else
            {
                ErrorTextBlock.Text = "Por favor, introduce un número válido para tu peso.";
            }
        }

        private void WeightTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CalculateButton_Click(this, new RoutedEventArgs());
            }
        }

    }
}
