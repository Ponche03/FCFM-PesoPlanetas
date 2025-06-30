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

    public partial class NameInputPage : Page
    {
        private readonly double _earthWeight;
        public NameInputPage(double earthWeight)
        {
            InitializeComponent();
            _earthWeight = earthWeight;
            Loaded += (s, e) => NameTextBox.Focus();
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Text = "";
            string userName = NameTextBox.Text;

            if (string.IsNullOrWhiteSpace(userName))
            {
                ErrorTextBlock.Text = "Por favor, escribe tu nombre.";
                return;
            }
            this.NavigationService.Navigate(new CameraPage(userName, _earthWeight));
        }
        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NextButton_Click(this, new RoutedEventArgs());
            }
        }



    }

}
