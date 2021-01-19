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
        MainWindow mainWindow;
        public LevelPage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void EasyLevel_Click(object sender, RoutedEventArgs e)
        {
            MediumLevelButton.IsChecked = false;
            HardLevelButton.IsChecked = false;
        }

        private void MediumLevel_Click(object sender, RoutedEventArgs e)
        {
            EasyLevelButton.IsChecked = false;
            HardLevelButton.IsChecked = false;
        }

        private void HardLevel_Click(object sender, RoutedEventArgs e)
        {
            MediumLevelButton.IsChecked = false;
            EasyLevelButton.IsChecked = false;
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage(mainWindow));
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
