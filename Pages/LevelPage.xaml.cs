using Snowman.RainDropFactory;
using System;
using System.Collections.Generic;
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

namespace Snowman.Pages
{
    /// <summary>
    /// Interaction logic for LevelPage.xaml
    /// </summary>
    public partial class LevelPage : Page
    {
        public LevelPage()
        {
            InitializeComponent();
        }

        // event after clicking difficulty easy button
        private void EasyLevel_Click(object sender, RoutedEventArgs e)
        {
            MediumLevelButton.IsChecked = false;
            HardLevelButton.IsChecked = false;
        }

        // event after clicking difficulty normal button
        private void MediumLevel_Click(object sender, RoutedEventArgs e)
        {
            EasyLevelButton.IsChecked = false;
            HardLevelButton.IsChecked = false;
        }

        // event after clicking difficulty hard button
        private void HardLevel_Click(object sender, RoutedEventArgs e)
        {
            MediumLevelButton.IsChecked = false;
            EasyLevelButton.IsChecked = false;
        }

        // checking checkbox
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {

        }

        // changing view to previous view after clicking back button
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage());
        }

        // starting the game after clicking start button
        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            // checking game level
            if (EasyLevelButton.IsChecked == true) {
                App.GameBuilder.setDifficultyEasy();

            } else if(MediumLevelButton.IsChecked == true){
                App.GameBuilder.setDifficultyNormal();

            } else if(HardLevelButton.IsChecked == true){
                App.GameBuilder.setDifficultyHard();

            } else {
                MessageBox.Show("You have to choose game level");
                return;
            }
            // checking checkbox
            if(SnowmanCheckBox.IsChecked == true)
            {
                App.GameBuilder.setGamemodeOn();
            } else
            {
                App.GameBuilder.setGamemodeOff();
            }
            // starting the game
            App.newGame();
            this.NavigationService.Navigate(new GamePage());
        }
    }
}
