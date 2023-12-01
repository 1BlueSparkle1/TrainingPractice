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

namespace TrainingPracticeWPF.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void EntryGuestBtn_Click(object sender, RoutedEventArgs e)
        {
            navigation.Clear();
            navigation.NextPage(new PageComponent(new MenuPage(), "Меню"));
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text == "1" && PasswordPb.Password == "1")
            {
                App.person = "Educator";
                navigation.Clear();
                navigation.NextPage(new PageComponent(new MenuPage(), "Меню"));
            }
            else if (LoginTb.Text == "2" && PasswordPb.Password == "2")
            {
                App.person = "Engineer";
                navigation.Clear();
                navigation.NextPage(new PageComponent(new MenuPage(), "Меню"));
            }
            else if(LoginTb.Text == "3" && PasswordPb.Password == "3")
            {
                App.person = "HeadDepartment";
                navigation.Clear();
                navigation.NextPage(new PageComponent(new MenuPage(), "Меню"));
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}
