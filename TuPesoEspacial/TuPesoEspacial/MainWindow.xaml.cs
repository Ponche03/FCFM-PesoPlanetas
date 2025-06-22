using System.Text;
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

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
      
            MainFrame.Navigate(new WelcomePage());
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11)
            {
                if (WindowStyle != WindowStyle.None)
                {
                    // Enter fullscreen
                    WindowStyle = WindowStyle.None;
                    WindowState = WindowState.Maximized;
                    Topmost = true;
                }
                else
                {
                    // Exit fullscreen
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    WindowState = WindowState.Normal;
                    Topmost = false;
                }
            }
        }

    }
}