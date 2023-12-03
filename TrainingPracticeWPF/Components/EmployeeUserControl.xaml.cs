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

namespace TrainingPracticeWPF.Components
{
    /// <summary>
    /// Логика взаимодействия для EmployeeUserControl.xaml
    /// </summary>
    public partial class EmployeeUserControl : UserControl
    {
        public static Employee employee;
        public EmployeeUserControl(Employee _employee)
        {
            InitializeComponent();
            employee = _employee;
            NumberTb.Text = employee.TabNumber.ToString();
            IEnumerable<Department> departments = App.db.Department;
            foreach (var department in departments)
            {
                if (department.Clipher == employee.ClipherDepartment)
                {
                    DepartmentTb.Text = department.Title;
                }
            }
            SurnameTb.Text = employee.Surname;
            PositionTb.Text = employee.Position;
            SalaryTb.Text = employee.Salary.ToString();
            if (employee.TabNumber == employee.Chief)
            {
                ChiefSp.Visibility = Visibility.Collapsed;
            }
            else
            {
                IEnumerable<Employee> employees = App.db.Employee;
                foreach (var employee1 in employees)
                {
                    if (employee1.TabNumber == employee.Chief)
                    {
                        ChiefTb.Text = employee1.Surname;
                    }
                }
            }
            DegreeSp.Visibility = Visibility.Collapsed;
            SpecialtySp.Visibility = Visibility.Collapsed;
            TitleSp.Visibility = Visibility.Collapsed;
            SenioritySp.Visibility = Visibility.Collapsed;
            if (employee.Position == "зав. кафедрой")
            {
                IEnumerable<HeadDepartment> headDepartments = App.db.HeadDepartment;
                SenioritySp.Visibility = Visibility.Visible;
                foreach (var headDepartment in headDepartments)
                {
                    if (headDepartment.TabNumberEmployee == employee.TabNumber)
                    {
                        SeniorityTb.Text = headDepartment.Seniority.ToString();
                    }
                }
                
            }
            else if (employee.Position == "преподаватель")
            {
                IEnumerable<Educator> educators = App.db.Educator;
                TitleSp.Visibility = Visibility.Visible;
                DegreeSp.Visibility = Visibility.Visible;
                foreach(var educator in educators)
                {
                    if (educator.TabNumberEmployee == employee.TabNumber)
                    {
                        TitleTb.Text = educator.Title;
                        DegreeTb.Text = educator.Degree;
                    }
                }
            }
            else if (employee.Position == "инженер")
            {
                IEnumerable<Engineer> engineers = App.db.Engineer;
                SpecialtySp.Visibility = Visibility.Visible;
                foreach (var  engineer in engineers)
                {
                    if (engineer.TabNumberEmployee == employee.TabNumber)
                    {
                        SpecialtyTb.Text = engineer.Specialty;
                    }
                }

            }
        }
    }
}
