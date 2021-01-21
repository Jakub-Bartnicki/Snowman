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
        MainWindow mainWindow;

        public SettingsPage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage(mainWindow));
        }

        private void LightThemeButton_Click(object sender, RoutedEventArgs e)
        {
            Theme.getInstance().setLightTheme();
        }

        private void DarkThemeButton_Click(object sender, RoutedEventArgs e)
        {
            Theme.getInstance().setDarkTheme();
        }
    }
}
