using GameOfThrones.Models;
using GameOfThrones.Services;
using GameOfThrones.Services.Abstract;
using Newtonsoft.Json;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GameOfThrones.UI
{
    public partial class MainWindow : Window
    {
        public Character[] Characters { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
            FillListBox();
        }
        
        private void WindowClosing(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void DoubleClickLeftMouseButton(object sender, MouseButtonEventArgs e)
        {
            var selectedCharacterName = charactersList.SelectedItem.ToString();

            var selectedCharacter = Characters.FirstOrDefault(c => c.Name == selectedCharacterName);
            
            CharacterWindow characterWindow = new CharacterWindow(selectedCharacter);
            characterWindow.ShowDialog();
        }

        private void FilterCharacter(object sender, TextChangedEventArgs e)
        {
            var charactersName = Characters.Select(c => c.Name);
            var sortedCharacters = charactersName.Where(c => c.ToLower().Contains(characterNameTextBox.Text.ToLower()));

            charactersList.ItemsSource = sortedCharacters;
        }

        private void FillListBox()
        {
            ILogger logger = new FileLogger();
            IDownloader downloader = new Downloader(logger);

            string json = downloader.DownloadDataJson("https://api.got.show/api/book/characters");
            Characters = JsonConvert.DeserializeObject<Character[]>(json);

            var charactersName = Characters.Select(c => c.Name);

            charactersList.ItemsSource = charactersName;
        }

        private void OpenInstagram(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/askar_kerimtay/");
        }
    }
}