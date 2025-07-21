using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using FontFamily = System.Windows.Media.FontFamily;
using Image = System.Windows.Controls.Image;
using Point = System.Windows.Point;
using Size = System.Windows.Size;


namespace TuPesoEspacial
{
    public class DrawingHost : FrameworkElement
    {
        public Visual Visual { get; set; }

        protected override int VisualChildrenCount => Visual != null ? 1 : 0;

        protected override Visual GetVisualChild(int index) => Visual;
    }

    public class PlanetInfo
    {
        public string Name { get; set; }
        public double GravityFactor { get; set; }
        public string CalculatedWeight { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public double ImageSize { get; set; }  
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
                    Name = "Sol",
                    GravityFactor = 27.9,
                    ImagePath = "pack://application:,,,/Images/Planetas/SOL.png",
                    ImageSize = 110,
                    Description = "La estrella más cercana a la Tierra, mejor conocida como el Sol, es ¡ENORME!. Es tan grande que si lo comparas con la Tierra, es 1,300,000 veces más grande que ella. Debido a esto, el Sol tiene una masa tan grande que su gravedad es 28 veces más fuerte que la de la Tierra. Eso significa que si pesas 40 kilos en la Tierra, en el Sol pesarías 1,120 kilos, por lo tanto te sería muy difícil moverte. ¡Eso es muy impresionante!.\r\n¡El Sol es muy, muy viejo! Nació hace muchísimo tiempo, hace unos 4,600,000,000 de años."
                },
                new PlanetInfo
                {
                    Name = "Mercurio",
                    GravityFactor = 0.38,
                    ImagePath = "pack://application:,,,/Images/Planetas/MERCURIO.png",
                    ImageSize = 60,
                    Description = "¡Conoce a Mercurio, el planeta más pequeño y rápido del sistema solar! Los antiguos griegos lo llamaban el mensajero de los dioses porque se mueve muy rápido alrededor del Sol, ¡a una velocidad de 172,800 kilómetros por hora!\r\nMercurio es tan pequeño que podríamos meter 18 Mercurios dentro de la Tierra. ¡Eso es muy pequeño! Y como tiene menos materia que la Tierra, su gravedad es 2.65 veces menor. ¿Qué significa eso? Que si estuvieras en Mercurio, podrías saltar mucho más alto que en la Tierra. ¡Imagina poder brincar como un superhéroe en Mercurio!"
                },
                new PlanetInfo
                {
                    Name = "Venus",
                    GravityFactor = 0.91,
                    ImagePath = "pack://application:,,,/Images/Planetas/VENUS.png",
                    ImageSize = 75,
                    Description = "¡Conoce a Venus, el planeta más brillante del cielo! Aunque es casi del mismo tamaño que la Tierra, Venus es muy diferente. Tiene una atmósfera espesa y tóxica que atrapa el calor, ¡alcanzando temperaturas de más de 460 °C! Es el planeta más caliente del sistema solar.\r\n\r\nVenus gira muy lento y al revés: un día allí dura más que un año, y el Sol sale por el oeste. Por eso los antiguos lo llamaban la estrella de la mañana y la estrella de la tarde. ¡Todo en Venus parece al revés y muy, muy caliente!"
                },
                    new PlanetInfo
                {
                    Name = "Tierra",
                    GravityFactor = 1.0,
                    ImagePath = "pack://application:,,,/Images/Planetas/TIERRA.png",
                    ImageSize = 75,
                    Description = "¡Conoce a la Tierra, nuestro hogar en el vasto universo! Es el único planeta conocido donde existe vida, gracias al agua líquida, el aire que respiramos y una temperatura ideal. La Tierra gira rápidamente: un día dura 24 horas y un año, 365 días.\r\n\r\nEstá protegida por una atmósfera que nos cuida del espacio y por un campo magnético que desvía la radiación solar. Vistas desde lejos, sus nubes, océanos y continentes la hacen parecer una joya azul flotando en la oscuridad. ¡La Tierra es única y debemos cuidarla siempre!"
                },
                new PlanetInfo
                {
                    Name = "Luna",
                    GravityFactor = 0.166,
                    ImagePath = "pack://application:,,,/Images/Planetas/LUNA.png",
                    ImageSize = 55,
                    Description = "¡Conoce a la Luna, el único satélite natural de la Tierra! Es el cuerpo celeste más cercano a nosotros y el único que ha sido visitado por humanos. Aunque parece brillar, en realidad refleja la luz del Sol.\r\n\r\nLa Luna no tiene aire ni agua, y sus días son larguísimos: duran unos 29 días terrestres. Su gravedad es seis veces menor que la de la Tierra, ¡así que podrías dar saltos gigantescos! Además, gracias a la Luna, tenemos mareas en los océanos. ¡Es nuestra fiel compañera en el cielo nocturno!"
                },
                new PlanetInfo
                {
                    Name = "Marte",
                    GravityFactor = 0.38,
                    ImagePath = "pack://application:,,,/Images/Planetas/MARTE.png",
                    ImageSize = 60,
                    Description = "¡Conoce a Marte, el planeta rojo! Su color viene del polvo de óxido de hierro que cubre su superficie.Tiene una atmósfera muy delgada, por lo que hace mucho frío.\r\n\r\nMarte tiene los volcanes más grandes del sistema solar y cañones gigantescos. Aunque es seco y rocoso, los científicos creen que alguna vez tuvo agua. Por eso lo estudian tanto, ¡incluso con robots que exploran su suelo! Su gravedad es menor que la de la Tierra, así que podrías saltar más alto. ¡Marte podría ser nuestro próximo hogar en el futuro!"
                },
                new PlanetInfo
                {
                    Name = "Júpiter",
                    GravityFactor = 2.34,
                    ImagePath = "pack://application:,,,/Images/Planetas/JUPITER.png",
                    ImageSize = 100,
                    Description = "¡Conoce a Júpiter, el gigante del sistema solar! Es el planeta más grande, tan enorme que más de 1,300 Tierras cabrían dentro de él. Está hecho de gas, así que no tiene una superficie sólida donde pararse.\r\n\r\nJúpiter tiene una gran mancha roja, una tormenta gigante que lleva siglos girando. También tiene al menos 95 lunas, ¡incluyendo algunas tan grandes como planetas pequeños! Su fuerte gravedad lo convierte en un escudo para la Tierra, desviando asteroides.\r\n\r\n¡Es un mundo asombroso, lleno de misterios y con el campo magnético más poderoso del sistema solar!"
                },
                new PlanetInfo
                {
                    Name = "Saturno",
                    GravityFactor = 1.06,
                    ImagePath = "pack://application:,,,/Images/Planetas/SATURNO.png",
                    ImageSize = 95,
                    Description = "¡Conoce a Saturno, el señor de los anillos del sistema solar! Es un planeta gigante hecho de gas, famoso por sus impresionantes anillos formados por hielo y rocas. Aunque es enorme, es tan ligero que flotaría en agua.\r\n\r\nSu atmósfera está llena de nubes y vientos súper rápidos.\r\n\r\nComo Júpiter, no tiene una superficie sólida, y su gravedad también es muy fuerte. ¡Saturno es uno de los planetas más hermosos y sorprendentes que podemos ver con un telescopio!"
                },
                new PlanetInfo
                {
                    Name = "Urano",
                    GravityFactor = 0.92,
                    ImagePath = "pack://application:,,,/Images/Planetas/URANO.png",
                    ImageSize = 80,
                    Description = "¡Conoce a Urano, el gigante helado del sistema solar! Es el tercer planeta más grande y está tan lejos del Sol que su temperatura puede bajar hasta -224 °C. Su color azul verdoso se debe al gas metano en su atmósfera.\r\n\r\n¡Ningún otro planeta lo hace! Tiene anillos delgados y al menos 27 lunas con nombres de personajes de Shakespeare.\r\n\r\nUrano es un mundo frío, misterioso y único. ¡Un verdadero extraño entre los planetas del sistema solar!"
                },
                new PlanetInfo
                {
                    Name = "Neptuno",
                    GravityFactor = 1.19,
                    ImagePath = "pack://application:,,,/Images/Planetas/NEPTUNO.png",
                    ImageSize = 80,
                    Description = "¡Conoce a Neptuno, el planeta más lejano del sistema solar! Es un gigante helado de color azul profundo, también por el metano en su atmósfera. A pesar de su distancia, tiene los vientos más rápidos del sistema solar, ¡hasta 2,000 km/h!\r\n\r\nNeptuno tiene anillos delgados y al menos 14 lunas, siendo Tritón la más grande, que gira en dirección contraria al planeta. Su clima es extremo y su superficie es un misterio, ya que está envuelto en nubes densas.\r\n\r\n¡Neptuno es un mundo frío, azul y salvaje, girando en la oscuridad del espacio!"
                },
                new PlanetInfo
                {
                    Name = "Ceres",
                    GravityFactor = 0.028,
                    ImagePath = "pack://application:,,,/Images/Planetas/CERES.png",
                    ImageSize = 50,
                    Description = "¡Conoce a Ceres, el asteroide más grande del cinturón que se encuentra entre Marte y Júpiter! Aunque es mucho más pequeño que los planetas, Ceres es tan grande que es visible con telescopios desde la Tierra.\r\n\r\nCeres tiene una gravedad muy baja, y los científicos creen que podría tener agua bajo su superficie.\r\n\r\n¡Es un asteroide fascinante, lleno de secretos, que nos ayuda a entender más sobre el origen del sistema solar!"
                }
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





        private FrameworkElement CreateVisualWithWeightsOnTemplate(BitmapImage userImage)
        {
            var backgroundImage = new BitmapImage(new Uri("pack://application:,,,/Images/PesosPlanetariosPlantilla.png"));
            double width = backgroundImage.PixelWidth;
            double height = backgroundImage.PixelHeight;

            var drawingVisual = new DrawingVisual();
            using (var dc = drawingVisual.RenderOpen())
            {
                // 1. Fondo (la plantilla)
                dc.DrawImage(backgroundImage, new Rect(0, 0, width, height));

                double profileX = 1850;
                double profileY = 1100;
                double profileSize = 900;

                // 2. Imagen del usuario en círculo
                if (userImage != null)
                {                   
                    dc.PushClip(new EllipseGeometry(
                        new Point(profileX + profileSize / 2, profileY + profileSize / 2),
                        profileSize / 2, profileSize / 2));

                    var croppedUserImage = CropToCenteredSquare(userImage);
                    dc.DrawImage(croppedUserImage, new Rect(profileX, profileY, profileSize, profileSize));

                    dc.Pop();
                }

                // 3. Nombre del usuario
                var customFont = new Typeface(new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Funky Smile"),
                              FontStyles.Normal,
                              FontWeights.Normal,
                              FontStretches.Normal);



                var nameText = new FormattedText(
                    UserName,
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    customFont,
                    300, // tamaño de fuente
                    Brushes.White,
                    1.0);

                // Centramos el texto bajo la imagen del usuario
                double nameX = profileX + (profileSize / 2) - (nameText.Width / 2);
                double nameY = profileY + profileSize + 50; // 50 píxeles debajo de la imagen

                dc.DrawText(nameText, new Point(nameX, nameY));


                // Leyenda: "TU PESO EN EL SISTEMA SOLAR"
                var legendText = new FormattedText(
                    "Mi Peso en el Sistema Solar",
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    customFont, // usa la misma fuente que el nombre
                    200,        // tamaño de fuente más pequeño
                    Brushes.White,
                    1.0);

                // Centrar leyenda igual que el nombre
                double legendX = profileX + (profileSize / 2) - (legendText.Width / 2);
                double legendY = nameY + nameText.Height + 30; // 30 píxeles debajo del nombre

                dc.DrawText(legendText, new Point(legendX, legendY));

                // 4. Posiciones predefinidas por planeta (ajústalas según tu plantilla)
                var weightPositions = new Dictionary<string, Point>
                {
                    { "Sol",      new Point(530, 4080) },
                    { "Mercurio", new Point(1590, 4080) },
                    { "Venus",    new Point(2560, 4080) },
                    { "Tierra",   new Point(3540, 4080) },
                    { "Luna",     new Point(580, 5430) },
                    { "Marte",    new Point(1580, 5430) },
                    { "Júpiter",  new Point(2540, 5430) },
                    { "Saturno",  new Point(3540, 5430) },
                    { "Urano",    new Point(1190, 6750) },
                    { "Neptuno",  new Point(2120, 6750)},
                    { "Ceres",    new Point(3160, 6750) }
                };

                var weightTypeface = new Typeface(new FontFamily("Franklin Gothic Heavy"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal);

                foreach (var planet in _planets)
                {
                    if (weightPositions.TryGetValue(planet.Name, out Point pos))
                    {
                        var weightText = new FormattedText(
                            planet.CalculatedWeight,
                            CultureInfo.CurrentCulture,
                            FlowDirection.LeftToRight,
                            weightTypeface,
                            100,
                            Brushes.White,
                            1.0);

                        dc.DrawText(weightText, pos);
                    }
                }
            }

            return new DrawingHost { Visual = drawingVisual, Width = width, Height = height };
        }

        private CroppedBitmap CropToCenteredSquare(BitmapImage source)
        {
            int size = Math.Min(source.PixelWidth, source.PixelHeight);
            int x = (source.PixelWidth - size) / 2;
            int y = (source.PixelHeight - size) / 2;

            return new CroppedBitmap(source, new Int32Rect(x, y, size, size));
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintTicket.PageOrientation = System.Printing.PageOrientation.Portrait;

            if (printDialog.ShowDialog() == true)
            {
                // Creamos el visual
                FrameworkElement visual = CreateVisualWithWeightsOnTemplate(_userImage);

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
                    Stretch = Stretch.Uniform // Llena vertical respetando proporciones
                };

                // Posicionamos la imagen en la esquina superior izquierda
                FixedPage.SetLeft(image, 0);
                FixedPage.SetTop(image, 0);

                // Página fija con tamaño de área imprimible y fondo azul
                FixedPage fixedPage = new FixedPage
                {
                    Width = printDialog.PrintableAreaWidth,
                    Height = printDialog.PrintableAreaHeight,
                    Background = new SolidColorBrush(System.Windows.Media.Colors.White) // Fondo
                };
                fixedPage.Children.Add(image);

                // Agregamos la página al documento
                PageContent pageContent = new PageContent();
                ((IAddChild)pageContent).AddChild(fixedPage);

                FixedDocument doc = new FixedDocument();
                doc.Pages.Add(pageContent);

                // Imprimimos el documento
                printDialog.PrintDocument(doc.DocumentPaginator, "Pesos Planetarios");
            }
        }



        private async void QRCodeButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement visual = CreateVisualWithWeightsOnTemplate(_userImage);

            visual.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            visual.Arrange(new Rect(0, 0, visual.DesiredSize.Width, visual.DesiredSize.Height));
            visual.UpdateLayout();

            string path = SaveVisualAsPng(visual, "PesoEspacial.png");

            string driveUrl = await UploadFileToGoogleDriveAsync(path);

            BitmapImage qr = GenerateQRCode(driveUrl);

            NavigationService.Navigate(new QRCodePage(qr));
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

    }

}
