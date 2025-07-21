using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace TuPesoEspacial
{
    public partial class QRCodePage : Page
    {
        public QRCodePage(BitmapImage qrImage)
        {
            InitializeComponent();
            QRCodeImage.Source = qrImage;
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
