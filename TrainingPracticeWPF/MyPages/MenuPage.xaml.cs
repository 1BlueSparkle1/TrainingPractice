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

namespace TrainingPracticeWPF.MyPages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public static MainWindow mainWindow;
        public MenuPage()
        {
            InitializeComponent();
            mainWindow.ExitBtn.Visibility = Visibility.Visible;
            if (App.person == "Guest")
            {
                ExamBtn.Visibility = Visibility.Collapsed;
                EmployeeBtn.Visibility = Visibility.Collapsed;
                DepartmentBtn.Visibility = Visibility.Collapsed;
                DisciplineBtn.Visibility = Visibility.Visible;
            }
            else if (App.person == "Educator")
            {
                ExamBtn.Visibility = Visibility.Visible;
                EmployeeBtn.Visibility = Visibility.Collapsed;
                DepartmentBtn.Visibility = Visibility.Collapsed;
                DisciplineBtn.Visibility = Visibility.Collapsed;
            }
            else if (App.person == "Engineer")
            {
                ExamBtn.Visibility = Visibility.Collapsed;
                EmployeeBtn.Visibility = Visibility.Visible;
                DepartmentBtn.Visibility = Visibility.Collapsed;
                DisciplineBtn.Visibility = Visibility.Collapsed;
            }
            else if (App.person == "HeadDepartment")
            {
                ExamBtn.Visibility = Visibility.Collapsed;
                EmployeeBtn.Visibility = Visibility.Collapsed;
                DepartmentBtn.Visibility = Visibility.Visible;
                DisciplineBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }
    }
}
