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

namespace Snowman
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

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("START GAME");
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
            System.Windows.Application.Current.Shutdown();
        }
    }
}
