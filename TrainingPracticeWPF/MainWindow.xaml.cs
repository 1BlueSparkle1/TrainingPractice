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
using TrainingPracticeWPF.Components;
using TrainingPracticeWPF.MyPages;

namespace TrainingPracticeWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            navigation.mainWindow = this;
            MenuPage.mainWindow = this;
            navigation.NextPage(new PageComponent(new AuthorizationPage(), "Авторизация"));
            ExitBtn.Visibility = Visibility.Hidden;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            navigation.BackPage();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            navigation.Clear();
            navigation.NextPage(new PageComponent(new AuthorizationPage(), "Авторизация"));
            App.person = "Guest";
            ExitBtn.Visibility = Visibility.Hidden;
        }
    }
}
