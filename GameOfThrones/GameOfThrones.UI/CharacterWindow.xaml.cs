using GameOfThrones.Models;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GameOfThrones.UI
{
    public partial class CharacterWindow : Window
    {
        public CharacterWindow(Character character)
        {
            InitializeComponent();

            if (character.Image != null)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(character.Image);
                bitmap.EndInit();

                characterImage.Source = bitmap;
            }
            else
            {
                characterImage.Source = new BitmapImage(new Uri(@"\imageNotFound.png", UriKind.Relative));
            }

            nameTextBlock.Text = "Name: " + character.Name;
            genderTextBlock.Text = "Gender: " + character.Gender;
            houseTextBlock.Text = "House: " + character.House;
            birthTextBlock.Text = "Birth year: " + character.Birth;
            aliveTextBlock.Text = "Is alive: " + character.IsAlive;
            createdAtTextBlock.Text = "Created at: " + character.CreatedAt;
        }
    }
}