using Snowman.GameBuilding;
using Snowman.GameLevel;
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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void BuffedGameButton_Click(object sender, RoutedEventArgs e)
        {
            App.GameBuilder = new BuffedGameBuilder();
            this.NavigationService.Navigate(new LevelPage());
        }

        private void NormalGameButton_Click(object sender, RoutedEventArgs e)
        {
            App.GameBuilder = new NormalGameBuilder();
            this.NavigationService.Navigate(new LevelPage());
        }

        private void ScoresButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ScoresPage());
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingsPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
