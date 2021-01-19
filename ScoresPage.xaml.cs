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
using System.Windows.Shapes;

namespace Snowman
{
    /// <summary>
    /// Interaction logic for ScoresPage.xaml
    /// </summary>
    public partial class ScoresPage : Page
    {
        MainWindow mainWindow;
        public ScoresPage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage(mainWindow));
        }
    }
}
