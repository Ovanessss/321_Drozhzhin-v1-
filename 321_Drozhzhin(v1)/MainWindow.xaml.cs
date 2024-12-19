using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _321_Drozhzhin_v1_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) MainFrame.GoBack(); 
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Подтверждение выхода из приложения
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение выхода",
                                                       MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown(); // Закрытие приложения
            }
        }
        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"ProjectByDrozhzhin - {page.Title}";

            if (page is Pages.AuthPage)
                BackButton.Visibility = Visibility.Hidden;
            else
                BackButton.Visibility = Visibility.Visible;
        }
    }
}
