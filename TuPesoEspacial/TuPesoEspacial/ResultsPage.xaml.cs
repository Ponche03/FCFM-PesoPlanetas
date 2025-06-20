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
                    ImagePath = "/Images/Planetas/MERCURIO.png",
                    Description = "¡Bienvenido a Mercurio! Es el planeta más cercano al Sol y también el más pequeño de todos. Aunque está muy cerca del Sol, no es el más caliente. ¡Eso sí, un día en Mercurio dura tanto como 176 días en la Tierra! Su gravedad es mucho menor que la de nuestro planeta, así que pesarías mucho menos aquí. Si en la Tierra pesas 30 kilos, en Mercurio pesarías solo unos 11. ¡Te sentirías superligero! No tiene atmósfera que lo proteja, así que el calor y el frío son extremos: durante el día puede alcanzar los 430 °C y en la noche bajar a -180 °C. ¡Menuda montaña rusa de temperaturas!"
                },
                new PlanetInfo
                {
                    Name = "Venus",
                    GravityFactor = 0.91,
                    ImagePath = "/Images/Planetas/VENUS.png",
                    Description = "Venus es casi del mismo tamaño que la Tierra, pero es muy diferente. Su atmósfera es tan espesa que atrapa el calor como un horno gigante. ¡La temperatura aquí puede superar los 460 °C, más caliente que un horno de pizza! El cielo de Venus siempre está cubierto de nubes de ácido sulfúrico, así que no podrías ver el Sol, ni respirar. Su gravedad es muy parecida a la de la Tierra, así que pesarías casi lo mismo. Pero si fueras allí, ¡tendrías que llevar un traje muy especial para no derretirte!"
                },
                new PlanetInfo
                {
                    Name = "Marte",
                    GravityFactor = 0.38,
                    ImagePath = "/Images/Planetas/MARTE.png",
                    Description = "¡Conoce el famoso Planeta Rojo! Marte recibe su color por el óxido de hierro en su superficie, ¡como si estuviera cubierto de polvo oxidado! Tiene la montaña más alta del sistema solar, el Monte Olimpo, que es tres veces más alto que el Monte Everest. Su gravedad es baja, así que podrías saltar mucho más alto que en la Tierra. ¡Un salto largo podría parecer un vuelo! Marte es muy frío y tiene tormentas de polvo que pueden cubrir todo el planeta. Los científicos sueñan con enviar humanos a vivir allá algún día, ¡tal vez tú seas uno de ellos!"
                },
                new PlanetInfo
                {
                    Name = "Júpiter",
                    GravityFactor = 2.34,
                    ImagePath = "/Images/Planetas/JUPITER.png",
                    Description = "¡Es hora de visitar al gigante del sistema solar! Júpiter es tan grande que cabrían todos los demás planetas dentro de él. Está hecho de gases como hidrógeno y helio, así que no podrías pararte en su superficie. Su gravedad es más del doble que la de la Tierra, lo que significa que pesarías mucho más. Si pesas 30 kg en la Tierra, ¡en Júpiter pesarías unos 70! También tiene la Gran Mancha Roja, una tormenta gigantesca que lleva activa más de 300 años. Además, tiene más de 90 lunas. ¡Es como un sistema solar en miniatura!"
                },
                new PlanetInfo
                {
                    Name = "Saturno",
                    GravityFactor = 1.06,
                    ImagePath = "/Images/Planetas/SATURNO.png",
                    Description = "¡Bienvenido al planeta con los anillos más bonitos del sistema solar! Saturno es un gigante gaseoso como Júpiter, pero aún más ligero: si pudieras meterlo en una bañera gigante (¡muy gigante!), flotaría. Sus anillos están hechos de hielo y rocas, y son tan anchos que podrías meter varias Tierras dentro de ellos. Su gravedad es casi igual a la de la Tierra, así que pesarías casi lo mismo. Pero cuidado: como no tiene superficie sólida, no podrías pararte en él. ¡Solo podrías flotar entre sus nubes!"
                },
                new PlanetInfo
                {
                    Name = "Urano",
                    GravityFactor = 0.92,
                    ImagePath = "/Images/Planetas/URANO.png",
                    Description = "Urano es un gigante de hielo con un secreto muy curioso: ¡rota de lado! Es como si estuviera acostado mientras gira alrededor del Sol. Eso hace que tenga estaciones extremadamente largas. Cada polo está expuesto a la luz solar por 42 años seguidos, ¡y luego pasa otros 42 años en oscuridad! Su color azul verdoso viene del gas metano en su atmósfera. Su gravedad es parecida a la de la Tierra, pero un poco menor. Y aunque parezca tranquilo, en realidad es muy frío, con temperaturas de hasta -224 °C. ¡Más frío que cualquier congelador!"
                },
                new PlanetInfo
                {
                    Name = "Neptuno",
                    GravityFactor = 1.19,
                    ImagePath = "/Images/Planetas/NEPTUNO.png",
                    Description = "¡El planeta más lejano del Sol! Neptuno es otro gigante de hielo, muy ventoso y muy frío. Sus vientos pueden alcanzar los 2,100 kilómetros por hora, más rápidos que cualquier huracán en la Tierra. Tiene un color azul intenso por el metano en su atmósfera. Su gravedad es un poco más fuerte que la de la Tierra, así que pesarías un poco más. Como está tan lejos del Sol, un año allí dura 165 años terrestres. ¡Si nacieras en Neptuno, no celebrarías tu primer cumpleaños hasta que fueras anciano en la Tierra!"
                },
                new PlanetInfo
                {
                    Name = "Luna",
                    GravityFactor = 0.166,
                    ImagePath = "/Images/Planetas/LUNA.png",
                    Description = "Nuestra Luna es el único satélite natural de la Tierra y el único cuerpo celeste donde los humanos han caminado. Su gravedad es muy baja, ¡solo un 16% de la gravedad terrestre! Por eso los astronautas rebotaban como si flotaran. Si pesas 30 kg en la Tierra, en la Luna pesarías solo unos 5 kg. Además, la Luna no tiene aire ni agua, pero influye mucho en nuestro planeta: su gravedad es la responsable de las mareas en los océanos. ¡Y cada noche nos regala su hermosa luz plateada!"
                },
                new PlanetInfo
                {
                    Name = "Sol",
                    GravityFactor = 27.9,
                    ImagePath = "/Images/Planetas/SOL.png",
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

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
          
        }

    }

}
