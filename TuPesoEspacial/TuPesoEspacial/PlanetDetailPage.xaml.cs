using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
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

        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();

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

            SpeakPlanetInfo();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            synthesizer.SpeakAsyncCancelAll();

            var resultsPage = new ResultsPage(_userName, _earthWeight, _userImage);
            this.NavigationService.Navigate(resultsPage);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            synthesizer.SpeakAsyncCancelAll();

            int currentIndex = _allPlanets.FindIndex(p => p.Name == _selectedPlanet.Name);
            int nextIndex = (currentIndex + 1) % _allPlanets.Count;

            var nextPage = new PlanetDetailPage(_allPlanets[nextIndex], _allPlanets, _userName, _earthWeight, _userImage);
            this.NavigationService.Navigate(nextPage);

        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            synthesizer.SpeakAsyncCancelAll();

            int currentIndex = _allPlanets.FindIndex(p => p.Name == _selectedPlanet.Name);
            int prevIndex = (currentIndex - 1 + _allPlanets.Count) % _allPlanets.Count;

            var prevPage = new PlanetDetailPage(_allPlanets[prevIndex], _allPlanets, _userName, _earthWeight, _userImage);
            this.NavigationService.Navigate(prevPage);

        }

        private void SpeakPlanetInfo()
        {
            string planetName = _selectedPlanet.Name;
            double gravity = _selectedPlanet.GravityFactor;
            string userWeight = _selectedPlanet.CalculatedWeight;

            string text = $"Estás en el planeta {planetName}, debido a la gravedad que es {gravity}, tu peso es {userWeight}.";

            synthesizer.SpeakAsyncCancelAll();

            try
            {
                synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("es-MX"));
            }
            catch { }

            synthesizer.SpeakAsync(text);
        }
        private void SpeakerIcon_Click(object sender, RoutedEventArgs e)
        {
            // Cancelamos cualquier síntesis anterior
            synthesizer.SpeakAsyncCancelAll();

            // Leemos la descripción del planeta
            string description = _selectedPlanet.Description;

            try
            {
                synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("es-MX"));
            }
            catch
            {
                // Por si falla la selección de voz, no hacemos nada
            }

            synthesizer.SpeakAsync(description);
        }

    }
}