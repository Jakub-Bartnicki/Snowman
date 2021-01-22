using Snowman.Themes;
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
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        // changing view to previous after clicking Back button
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage());
        }

        // changing theme to light after clicking Light Theme button
        private void LightThemeButton_Click(object sender, RoutedEventArgs e)
        {
            Theme.getInstance().setLightTheme();
        }

        // changing theme to light after clicking Dark Theme button
        private void DarkThemeButton_Click(object sender, RoutedEventArgs e)
        {
            Theme.getInstance().setDarkTheme();
        }
    }
}
