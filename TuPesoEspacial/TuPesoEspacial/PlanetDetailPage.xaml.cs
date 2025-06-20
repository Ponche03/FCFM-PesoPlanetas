using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging; 
using System.Windows.Navigation;

namespace TuPesoEspacial
{
    public partial class PlanetDetailPage : Page
    {
        private PlanetInfo _selectedPlanet;
        private List<PlanetInfo> _allPlanets;
        private string _userName;
        private double _earthWeight;

        private readonly BitmapImage _userImage;

        public PlanetDetailPage(PlanetInfo selectedPlanet, List<PlanetInfo> allPlanets, string userName, double earthWeight, BitmapImage userImage)
        {
            InitializeComponent();

            _selectedPlanet = selectedPlanet;
            _allPlanets = allPlanets;
            _userName = userName;
            _earthWeight = earthWeight;

            _userImage = userImage;

            this.DataContext = new
            {
                SelectedPlanet = _selectedPlanet,
                UserName = _userName,
                CalculatedWeight = _selectedPlanet.CalculatedWeight
            };

            this.Loaded += PlanetDetailPage_Loaded;
        }

        private void PlanetDetailPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            if (_userImage != null)
            {
                UserPhotoBorder.Background = new ImageBrush(_userImage)
                {
                    Stretch = Stretch.UniformToFill
                };
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var resultsPage = new ResultsPage(_userName, _earthWeight, _userImage);
            this.NavigationService.Navigate(resultsPage);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            int currentIndex = _allPlanets.FindIndex(p => p.Name == _selectedPlanet.Name);
            int nextIndex = (currentIndex + 1) % _allPlanets.Count;

            var nextPage = new PlanetDetailPage(_allPlanets[nextIndex], _allPlanets, _userName, _earthWeight, _userImage);
            this.NavigationService.Navigate(nextPage);
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            int currentIndex = _allPlanets.FindIndex(p => p.Name == _selectedPlanet.Name);
            int prevIndex = (currentIndex - 1 + _allPlanets.Count) % _allPlanets.Count;

            var prevPage = new PlanetDetailPage(_allPlanets[prevIndex], _allPlanets, _userName, _earthWeight, _userImage);
            this.NavigationService.Navigate(prevPage);
        }
    }
}