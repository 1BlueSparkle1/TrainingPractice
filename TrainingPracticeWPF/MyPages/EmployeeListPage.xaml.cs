using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для EmployeeListPage.xaml
    /// </summary>
    public partial class EmployeeListPage : Page
    {
        public EmployeeListPage()
        {
            InitializeComponent();
            IEnumerable<Employee> employees = App.db.Employee;
            foreach (Employee employee in employees)
            {
                EmployeeWp.Children.Add(new EmployeeUserControl(employee));
            }
        }

        private void Refresh()
        {
            IEnumerable<Employee> employees = App.db.Employee; 
            if (PositionCb.SelectedIndex != 0)
            {
                if (PositionCb.SelectedIndex == 1)
                {
                    employees = employees.Where(x => x.Position == "преподаватель");
                }
                else if (PositionCb.SelectedIndex == 2)
                {
                    employees = employees.Where(x => x.Position == "зав. кафедрой");
                }
                else if (PositionCb.SelectedIndex == 3)
                {
                    employees = employees.Where(x => x.Position == "инженер");
                }
            }
            if (SalaryCb.SelectedIndex != 0)
            {
                if(SalaryCb.SelectedIndex == 1)
                {
                    employees = employees.OrderBy(x => x.Salary);
                }
                else if (SalaryCb.SelectedIndex == 2)
                {
                    employees = employees.OrderByDescending(x => x.Salary);
                }
            }
            employees = employees.Where(x => x.Surname.ToLower().Contains(SurnameTb.Text.ToLower()));
            EmployeeWp.Children.Clear();
            foreach (var e in employees)
            {
                EmployeeWp.Children.Add(new EmployeeUserControl(e));
            }
        }

        private void PositionCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SalaryCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SurnameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            navigation.NextPage(new PageComponent(new EditEmployeePage(new Employee(), 1), "Добавление"));
        }
    }
}
