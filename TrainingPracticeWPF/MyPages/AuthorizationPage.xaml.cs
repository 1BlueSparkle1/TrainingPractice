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
        public static MainWindow mainWindow;
        public AuthorizationPage()
        {
            InitializeComponent();
            MainWindow.authorizationPage = this;
        }

        private void EntryGuestBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainTitleTb.Text = "Гость";
            mainWindow.MainNameTb.Visibility = Visibility.Collapsed;
            navigation.Clear();
            navigation.NextPage(new PageComponent(new MenuPage(), "Меню"));
        }
        public int a = 0;
        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Educator> educators = App.db.Educator;
            foreach (var educator in educators)
            {
                if (LoginTb.Text == educator.Login && PasswordPb.Password == educator.Password)
                {
                    a = 1;
                    App.person = "Educator";
                    mainWindow.MainNameTb.Text = educator.Employee.Surname;
                    mainWindow.MainTitleTb.Text = educator.Employee.Position;
                    navigation.Clear();
                    navigation.NextPage(new PageComponent(new MenuPage(), "Меню"));
                }
            }
            IEnumerable<Engineer> engineers = App.db.Engineer;
            foreach (var engineer in engineers)
            {
                if (LoginTb.Text == engineer.Login && PasswordPb.Password ==engineer.Password)
                {
                    a = 1;
                    App.person = "Engineer";
                    mainWindow.MainNameTb.Text = engineer.Employee.Surname;
                    mainWindow.MainTitleTb.Text= engineer.Employee.Position;
                    navigation.Clear();
                    navigation.NextPage(new PageComponent(new MenuPage(), "Меню"));
                }
            }
            IEnumerable<HeadDepartment> headDepartments = App.db.HeadDepartment;
            foreach (var headDepartment in headDepartments)
            {
                if (LoginTb.Text == headDepartment.Login && PasswordPb.Password == headDepartment.Password)
                {
                    a = 1;
                    App.person = "HeadDepartment";
                    mainWindow.MainNameTb.Text = headDepartment.Employee.Surname;
                    mainWindow.MainTitleTb.Text = headDepartment.Employee.Position;
                    navigation.Clear();
                    navigation.NextPage(new PageComponent(new MenuPage(), "Меню"));
                }
            }
            if (a != 1)
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
                
            
        }
    }
}
