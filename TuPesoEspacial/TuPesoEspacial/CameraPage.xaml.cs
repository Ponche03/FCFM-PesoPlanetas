using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Windows.Navigation;
using AForge.Video;
using AForge.Video.DirectShow;

namespace TuPesoEspacial
{
    public partial class CameraPage : Page
    {
        private FilterInfoCollection videoDevices;
        private IVideoSource videoSource;


        // Nuevas variables para guardar los datos que vienen de NameInputPage
        private readonly string _userName;
        private readonly double _earthWeight;

        public CameraPage(string userName, double earthWeight)
        {
            InitializeComponent();
            _userName = userName;
            _earthWeight = earthWeight;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Obtener la lista de dispositivos de video (cámaras)
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count > 0)
            {
                // Iniciar la primera cámara encontrada
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Start();
            }
            else
            {
                ErrorTextBlock.Text = "No se encontró ninguna cámara en este dispositivo.";
                TakePhotoButton.IsEnabled = false;
            }
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
          
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                    bitmap.Save(memoryStream, ImageFormat.Bmp); 
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    Dispatcher.Invoke(() =>
                    {
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                        CameraFeedImage.Source = bitmapImage;
                    });
                }
            }
            catch (Exception) { /* Ignorar errores si el frame se pierde */ }
        }

        private void TakePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage capturedImage = null;
            if (CameraFeedImage.Source != null)
            {
                // Captura la imagen actual
                capturedImage = (BitmapImage)CameraFeedImage.Source;
            }

            StopCamera();

    
            this.NavigationService.Navigate(new ResultsPage(_userName, _earthWeight, capturedImage));
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            StopCamera();
        }

        private void StopCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.NewFrame -= new NewFrameEventHandler(videoSource_NewFrame);
                videoSource = null;
            }
        }
    }
}