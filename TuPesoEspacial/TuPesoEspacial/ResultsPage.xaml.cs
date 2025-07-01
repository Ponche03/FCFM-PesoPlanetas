using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Markup;
using System.IO;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v3.Data;
using QRCoder;
using System.Drawing;
using Color = System.Windows.Media.Color;
using FontFamily = System.Windows.Media.FontFamily;
using Brushes = System.Windows.Media.Brushes;
using Size = System.Windows.Size;
using Image = System.Windows.Controls.Image;


namespace TuPesoEspacial
{
    public class PlanetInfo
    {
        public string Name { get; set; }
        public double GravityFactor { get; set; }
        public string CalculatedWeight { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }

    public partial class ResultsPage : Page
    {
        private readonly double _earthWeight;
        private List<PlanetInfo> _planets;

        private readonly BitmapImage _userImage;
        public string UserName { get; set; }

        public ResultsPage(string userName, double earthWeight, BitmapImage userImage)
        {
            InitializeComponent();
            _earthWeight = earthWeight;
            UserName = userName;

            _userImage = userImage;

            this.DataContext = this;
            LoadPlanetData();
        }

        private void LoadPlanetData()
        {
            _planets = new List<PlanetInfo>
            {
                new PlanetInfo
                {
                    Name = "Mercurio",
                    GravityFactor = 0.38,
                    ImagePath = "pack://application:,,,/Images/Planetas/MERCURIO.png",
                    Description = "¡Bienvenido a Mercurio! Es el planeta más cercano al Sol y también el más pequeño de todos. Aunque está muy cerca del Sol, no es el más caliente. ¡Eso sí, un día en Mercurio dura tanto como 176 días en la Tierra! Su gravedad es mucho menor que la de nuestro planeta, así que pesarías mucho menos aquí. Si en la Tierra pesas 30 kilos, en Mercurio pesarías solo unos 11. ¡Te sentirías superligero! No tiene atmósfera que lo proteja, así que el calor y el frío son extremos: durante el día puede alcanzar los 430 °C y en la noche bajar a -180 °C. ¡Menuda montaña rusa de temperaturas!"
                },
                new PlanetInfo
                {
                    Name = "Venus",
                    GravityFactor = 0.91,
                    ImagePath = "pack://application:,,,/Images/Planetas/VENUS.png",
                    Description = "Venus es casi del mismo tamaño que la Tierra, pero es muy diferente. Su atmósfera es tan espesa que atrapa el calor como un horno gigante. ¡La temperatura aquí puede superar los 460 °C, más caliente que un horno de pizza! El cielo de Venus siempre está cubierto de nubes de ácido sulfúrico, así que no podrías ver el Sol, ni respirar. Su gravedad es muy parecida a la de la Tierra, así que pesarías casi lo mismo. Pero si fueras allí, ¡tendrías que llevar un traje muy especial para no derretirte!"
                },
                new PlanetInfo
                {
                    Name = "Marte",
                    GravityFactor = 0.38,
                    ImagePath = "pack://application:,,,/Images/Planetas/MARTE.png",
                    Description = "¡Conoce el famoso Planeta Rojo! Marte recibe su color por el óxido de hierro en su superficie, ¡como si estuviera cubierto de polvo oxidado! Tiene la montaña más alta del sistema solar, el Monte Olimpo, que es tres veces más alto que el Monte Everest. Su gravedad es baja, así que podrías saltar mucho más alto que en la Tierra. ¡Un salto largo podría parecer un vuelo! Marte es muy frío y tiene tormentas de polvo que pueden cubrir todo el planeta. Los científicos sueñan con enviar humanos a vivir allá algún día, ¡tal vez tú seas uno de ellos!"
                },
                new PlanetInfo
                {
                    Name = "Júpiter",
                    GravityFactor = 2.34,
                    ImagePath = "pack://application:,,,/Images/Planetas/JUPITER.png",
                    Description = "¡Es hora de visitar al gigante del sistema solar! Júpiter es tan grande que cabrían todos los demás planetas dentro de él. Está hecho de gases como hidrógeno y helio, así que no podrías pararte en su superficie. Su gravedad es más del doble que la de la Tierra, lo que significa que pesarías mucho más. Si pesas 30 kg en la Tierra, ¡en Júpiter pesarías unos 70! También tiene la Gran Mancha Roja, una tormenta gigantesca que lleva activa más de 300 años. Además, tiene más de 90 lunas. ¡Es como un sistema solar en miniatura!"
                },
                new PlanetInfo
                {
                    Name = "Saturno",
                    GravityFactor = 1.06,
                    ImagePath = "pack://application:,,,/Images/Planetas/SATURNO.png",
                    Description = "¡Bienvenido al planeta con los anillos más bonitos del sistema solar! Saturno es un gigante gaseoso como Júpiter, pero aún más ligero: si pudieras meterlo en una bañera gigante (¡muy gigante!), flotaría. Sus anillos están hechos de hielo y rocas, y son tan anchos que podrías meter varias Tierras dentro de ellos. Su gravedad es casi igual a la de la Tierra, así que pesarías casi lo mismo. Pero cuidado: como no tiene superficie sólida, no podrías pararte en él. ¡Solo podrías flotar entre sus nubes!"
                },
                new PlanetInfo
                {
                    Name = "Urano",
                    GravityFactor = 0.92,
                    ImagePath = "pack://application:,,,/Images/Planetas/URANO.png",
                    Description = "Urano es un gigante de hielo con un secreto muy curioso: ¡rota de lado! Es como si estuviera acostado mientras gira alrededor del Sol. Eso hace que tenga estaciones extremadamente largas. Cada polo está expuesto a la luz solar por 42 años seguidos, ¡y luego pasa otros 42 años en oscuridad! Su color azul verdoso viene del gas metano en su atmósfera. Su gravedad es parecida a la de la Tierra, pero un poco menor. Y aunque parezca tranquilo, en realidad es muy frío, con temperaturas de hasta -224 °C. ¡Más frío que cualquier congelador!"
                },
                new PlanetInfo
                {
                    Name = "Neptuno",
                    GravityFactor = 1.19,
                    ImagePath = "pack://application:,,,/Images/Planetas/NEPTUNO.png",
                    Description = "¡El planeta más lejano del Sol! Neptuno es otro gigante de hielo, muy ventoso y muy frío. Sus vientos pueden alcanzar los 2,100 kilómetros por hora, más rápidos que cualquier huracán en la Tierra. Tiene un color azul intenso por el metano en su atmósfera. Su gravedad es un poco más fuerte que la de la Tierra, así que pesarías un poco más. Como está tan lejos del Sol, un año allí dura 165 años terrestres. ¡Si nacieras en Neptuno, no celebrarías tu primer cumpleaños hasta que fueras anciano en la Tierra!"
                },
                new PlanetInfo
                {
                    Name = "Luna",
                    GravityFactor = 0.166,
                    ImagePath = "pack://application:,,,/Images/Planetas/LUNA.png",
                    Description = "Nuestra Luna es el único satélite natural de la Tierra y el único cuerpo celeste donde los humanos han caminado. Su gravedad es muy baja, ¡solo un 16% de la gravedad terrestre! Por eso los astronautas rebotaban como si flotaran. Si pesas 30 kg en la Tierra, en la Luna pesarías solo unos 5 kg. Además, la Luna no tiene aire ni agua, pero influye mucho en nuestro planeta: su gravedad es la responsable de las mareas en los océanos. ¡Y cada noche nos regala su hermosa luz plateada!"
                },
                new PlanetInfo
                {
                    Name = "Sol",
                    GravityFactor = 27.9,
                    ImagePath = "pack://application:,,,/Images/Planetas/SOL.png",
                    Description = "¡Cuidado, está caliente! El Sol no es un planeta, sino una estrella, y es el corazón del sistema solar. Toda la vida en la Tierra depende de su luz y su calor. Su gravedad es tan fuerte que mantiene a todos los planetas girando a su alrededor. Si pudieras pararte en el Sol (lo cual es imposible, ¡te quemarías al instante!), pesarías casi 28 veces más que en la Tierra. Pero gracias a su energía, las plantas crecen, el clima se mueve y podemos vivir. ¡Es nuestra estrella especial!"
                },
            };

            foreach (var planet in _planets)
            {
                double weightOnPlanet = _earthWeight * planet.GravityFactor;
                planet.CalculatedWeight = $"{weightOnPlanet:F1} KG";
            }

            PlanetsItemsControl.ItemsSource = _planets;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new InputPage());
        }

        private void PlanetCard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border clickedBorder && clickedBorder.DataContext is PlanetInfo selectedPlanet)
            {
                // Ahora pasamos la imagen guardada a la PlanetDetailPage
                var detailPage = new PlanetDetailPage(selectedPlanet, _planets, UserName, _earthWeight, _userImage);
                this.NavigationService.Navigate(detailPage);
            }
        }

        private FrameworkElement CreatePrintVisual()
        {
            double pageWidth = 816;  // 8.5" * 96 dpi
            double pageHeight = 1056; // 11" * 96 dpi

            Grid root = new Grid
            {
                Width = pageWidth,
                // Height = pageHeight, ❌ QUÍTALO, causa el corte
                Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Fondos/FONDO 2.png")),
                    Stretch = Stretch.UniformToFill
                }
            };

            StackPanel mainPanel = new StackPanel
            {
                Margin = new Thickness(30),
                Orientation = Orientation.Vertical
            };

            // Imagen del usuario
            if (_userImage != null)
            {
                System.Windows.Controls.Image userImageControl = new System.Windows.Controls.Image
                {
                    Source = _userImage,
                    Width = 100,
                    Height = 100,
                    Stretch = Stretch.UniformToFill,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                // Make it perfectly round
                userImageControl.Clip = new EllipseGeometry
                {
                    Center = new System.Windows.Point(50, 50),  // Center = half of Width/Height
                    RadiusX = 50,
                    RadiusY = 50
                };

                mainPanel.Children.Add(new StackPanel
                {
                    Children = { userImageControl },
                    Margin = new Thickness(0, 0, 0, 20),
                    HorizontalAlignment = HorizontalAlignment.Center
                });


            }

            // Título
            TextBlock titleBlock = new TextBlock
            {
                FontSize = 28,
                FontWeight = FontWeights.Bold,
                FontFamily = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Funky Smile"),
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 20)
            };

            titleBlock.Inlines.Add(new Run("Pesos planetarios de ") { Foreground = System.Windows.Media.Brushes.White });
            titleBlock.Inlines.Add(new Run(UserName) { Foreground = new SolidColorBrush(Color.FromRgb(254, 208, 0)) }); // Amarillo

            mainPanel.Children.Add(titleBlock);

            // WrapPanel para las tarjetas
            WrapPanel wrap = new WrapPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center
            };

            foreach (var planet in _planets)
            {
                Border card = new Border
                {
                    Width = 200,
                    Height = 240,
                    Margin = new Thickness(10),
                    CornerRadius = new CornerRadius(20),
                    Background = new SolidColorBrush(Color.FromRgb(44, 62, 80)),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(254, 208, 0)),
                    BorderThickness = new Thickness(2),
                    Effect = new System.Windows.Media.Effects.DropShadowEffect
                    {
                        ShadowDepth = 0,
                        Color = Color.FromRgb(254, 208, 0),
                        Opacity = 0.7,
                        BlurRadius = 10
                    }
                };

                StackPanel content = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                content.Children.Add(new System.Windows.Controls.Image
                {
                    Source = new BitmapImage(new Uri(planet.ImagePath, UriKind.Absolute)),
                    Width = 60,
                    Height = 60,
                    Margin = new Thickness(0, 0, 0, 10)
                });

                content.Children.Add(new TextBlock
                {
                    Text = planet.Name,
                    FontWeight = FontWeights.Bold,
                    FontSize = 18,
                    FontFamily = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Funky Smile"),
                    Foreground = new SolidColorBrush(Color.FromRgb(254, 208, 0)),
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                content.Children.Add(new TextBlock
                {
                    Text = "Tu peso sería",
                    FontSize = 12,
                    FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Funky Smile"),
                    Foreground = Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 10, 0, 2)
                });

                content.Children.Add(new TextBlock
                {
                    Text = planet.CalculatedWeight,
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    FontFamily = new FontFamily("Franklin Gothic Heavy"),
                    Foreground = Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                card.Child = content;
                wrap.Children.Add(card);
            }

            mainPanel.Children.Add(wrap);
            root.Children.Add(mainPanel);
            return root;
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintTicket.PageOrientation = System.Printing.PageOrientation.Portrait;

            if (printDialog.ShowDialog() == true)
            {
                // Creamos el visual
                FrameworkElement visual = CreatePrintVisual();

                // Forzamos layout
                visual.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
                visual.Arrange(new Rect(0, 0, visual.DesiredSize.Width, visual.DesiredSize.Height));
                visual.UpdateLayout();

                // Renderizamos a imagen
                var renderBitmap = new RenderTargetBitmap(
                    (int)visual.ActualWidth,
                    (int)visual.ActualHeight,
                    96, 96, PixelFormats.Pbgra32);
                renderBitmap.Render(visual);

                // Creamos un Image control con esa imagen
                System.Windows.Controls.Image image = new System.Windows.Controls.Image
                {
                    Source = renderBitmap,
                    Width = printDialog.PrintableAreaWidth,
                    Height = printDialog.PrintableAreaHeight,
                    Stretch = Stretch.Uniform
                };

                FixedPage fixedPage = new FixedPage
                {
                    Width = printDialog.PrintableAreaWidth,
                    Height = printDialog.PrintableAreaHeight
                };
                fixedPage.Children.Add(image);

                PageContent pageContent = new PageContent();
                ((IAddChild)pageContent).AddChild(fixedPage);

                FixedDocument doc = new FixedDocument();
                doc.Pages.Add(pageContent);

                printDialog.PrintDocument(doc.DocumentPaginator, "Pesos planetarios");
            }
        }

        private async void QRCodeButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement visual = CreatePrintVisual();

            visual.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            visual.Arrange(new Rect(0, 0, visual.DesiredSize.Width, visual.DesiredSize.Height));
            visual.UpdateLayout();

            string path = SaveVisualAsPng(visual, "PesoEspacial.png");

            string driveUrl = await UploadFileToGoogleDriveAsync(path);

            BitmapImage qr = GenerateQRCode(driveUrl);

            ShowQRCodeWindow(qr);
        }

        private string SaveVisualAsPng(FrameworkElement visual, string fileName)
        {
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
                (int)visual.ActualWidth,
                (int)visual.ActualHeight,
                96, 96, PixelFormats.Pbgra32);
            renderBitmap.Render(visual);

            string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), fileName);

            using (FileStream outStream = new FileStream(tempPath, FileMode.Create))
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                encoder.Save(outStream);
            }

            return tempPath;
        }

        private async Task<string> UploadFileToGoogleDriveAsync(string filePath)
        {
            UserCredential credential;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                // ✅ Guardar token en AppData para que no se borre fácilmente
                string credPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "TuPesoEspacialTokens"
                );

                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { DriveService.Scope.DriveFile },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)  // Usa FileDataStore para guardar token.json
                );
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "TuPesoEspacial",
            });

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(filePath)
            };

            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, "image/png");
                request.Fields = "id";
                await request.UploadAsync();
            }

            var file = request.ResponseBody;

            // Compartir el archivo públicamente
            var permission = new Google.Apis.Drive.v3.Data.Permission
            {
                Role = "reader",
                Type = "anyone"
            };
            await service.Permissions.Create(permission, file.Id).ExecuteAsync();

            return $"https://drive.google.com/uc?id={file.Id}";
        }


        private BitmapImage GenerateQRCode(string url)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCode(qrCodeData))
            using (Bitmap qrBitmap = qrCode.GetGraphic(20))
            using (MemoryStream ms = new MemoryStream())
            {
                qrBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;

                BitmapImage qrImage = new BitmapImage();
                qrImage.BeginInit();
                qrImage.StreamSource = ms;
                qrImage.CacheOption = BitmapCacheOption.OnLoad;
                qrImage.EndInit();
                return qrImage;
            }
        }

        private void ShowQRCodeWindow(BitmapImage qrImage)
        {
            Window qrWindow = new Window
            {
                Title = "QR Code de tu Peso Espacial",
                Width = 300,
                Height = 350,
                Content = new Image
                {
                    Source = qrImage,
                    Stretch = Stretch.Uniform
                }
            };
            qrWindow.ShowDialog();
        }

    }

}
