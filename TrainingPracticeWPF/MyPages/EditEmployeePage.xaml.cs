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
    /// Логика взаимодействия для EditEmployeePage.xaml
    /// </summary>
    public partial class EditEmployeePage : Page
    {
        public Employee employee;
        public static int Variable;
        public EditEmployeePage(Employee _employee, int x)
        {
            InitializeComponent();
            employee = _employee;
            this.DataContext = employee;
            Variable = x;

            ChiefCb.ItemsSource = App.db.Employee.ToList();
            ChiefCb.DisplayMemberPath = "Surname";
            DepartmentCb.ItemsSource = App.db.Department.ToList();
            DepartmentCb.DisplayMemberPath = "Title";
            SpecialtyCb.ItemsSource = App.db.Specialty.ToList();
            SpecialtyCb.DisplayMemberPath = "Direction";

            if (Variable == 0)
            {
                DepartmentCb.Text = employee.Department.Title;
            }
            

            if (NumberTb.Text == employee.TabNumber.ToString())
            {
                NumberTb.IsReadOnly = true;
            }
            else
            {
                NumberTb.IsReadOnly = false;
            }

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
                        ChiefCb.Text = employee1.Surname;
                    }
                }
            }

            DegreeSp.Visibility = Visibility.Collapsed;
            SpecialtySp.Visibility = Visibility.Collapsed;
            TitleSp.Visibility = Visibility.Collapsed;
            SenioritySp.Visibility = Visibility.Collapsed;
            LoginTb.Visibility = Visibility.Collapsed;
            PasswordTb.Visibility = Visibility.Collapsed;
            if (employee.Position == "зав. кафедрой")
            {
                IEnumerable<HeadDepartment> headDepartments = App.db.HeadDepartment;
                SenioritySp.Visibility = Visibility.Visible;
                LoginTb.Visibility = Visibility.Visible;
                PasswordTb.Visibility = Visibility.Visible;
                foreach (var headDepartment in headDepartments)
                {
                    if (headDepartment.TabNumberEmployee == employee.TabNumber)
                    {
                        SeniorityTb.Text = headDepartment.Seniority.ToString();
                        LoginTb.Text = headDepartment.Login;
                        PasswordTb.Text = headDepartment.Password;

                    }
                }

            }
            else if (employee.Position == "преподаватель")
            {
                IEnumerable<Educator> educators = App.db.Educator;
                TitleSp.Visibility = Visibility.Visible;
                DegreeSp.Visibility = Visibility.Visible;
                LoginTb.Visibility = Visibility.Visible;
                PasswordTb.Visibility = Visibility.Visible;
                foreach (var educator in educators)
                {
                    if (educator.TabNumberEmployee == employee.TabNumber)
                    {
                        TitleTb.Text = educator.Title;
                        DegreeTb.Text = educator.Degree;
                        LoginTb.Text = educator.Login;
                        PasswordTb.Text = educator.Password;
                    }
                }
            }
            else if (employee.Position == "инженер")
            {
                IEnumerable<Engineer> engineers = App.db.Engineer;
                SpecialtySp.Visibility = Visibility.Visible;
                LoginTb.Visibility = Visibility.Visible;
                PasswordTb.Visibility = Visibility.Visible;
                foreach (var engineer in engineers)
                {
                    if (engineer.TabNumberEmployee == employee.TabNumber)
                    {
                        SpecialtyCb.Text = engineer.Specialty;
                        LoginTb.Text = engineer.Login;
                        PasswordTb.Text = engineer.Password;
                    }
                }

            }
            

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Variable == 0)
            {
                if (employee.Position == "зав. кафедрой")
                {
                    IEnumerable<HeadDepartment> headDepartments = App.db.HeadDepartment;
                    foreach (var headDepartment in headDepartments)
                    {
                        if (headDepartment.TabNumberEmployee == employee.TabNumber)
                        {
                            headDepartment.Seniority = int.Parse(SeniorityTb.Text);
                            headDepartment.Login = LoginTb.Text;
                            headDepartment.Password = PasswordTb.Text;
                        }
                    }

                }
                else if (employee.Position == "преподаватель")
                {
                    IEnumerable<Educator> educators = App.db.Educator;
                    foreach (var educator in educators)
                    {
                        if (educator.TabNumberEmployee == employee.TabNumber)
                        {
                            educator.Login = LoginTb.Text;
                            educator.Password = PasswordTb.Text;
                            educator.Title = TitleTb.Text;
                            educator.Degree = DegreeTb.Text;
                        }
                    }
                }
                else if (employee.Position == "инженер")
                {
                    IEnumerable<Engineer> engineers = App.db.Engineer;
                    foreach (var engineer in engineers)
                    {
                        if (engineer.TabNumberEmployee == employee.TabNumber)
                        {
                            engineer.Login = LoginTb.Text;
                            engineer.Password = PasswordTb.Text;
                            engineer.Specialty = SpecialtyCb.Text;
                        }
                    }

                }
                App.db.SaveChanges();
                MessageBox.Show("Сохранено!");
                navigation.BackPage();
            }
            else if (Variable == 1)
            {
                Employee employeeSave;
                IEnumerable<Employee> employees1 = App.db.Employee;
                foreach(var emp in employees1)
                {
                    if (NumberTb.Text == emp.TabNumber.ToString())
                    {
                        Variable = 5; 
                        break;
                    }
                }
                if (Variable != 5)
                {
                    employeeSave = employee;
                    employeeSave.TabNumber = int.Parse(NumberTb.Text);
                    IEnumerable<Employee> ems = App.db.Employee;
                    foreach (var em in ems)
                    {
                        if (ChiefCb.Text == em.Surname.ToString())
                        {
                            employeeSave.Chief = em.TabNumber;
                        }
                    }
                    IEnumerable<Department> depts = App.db.Department;
                    foreach (var dept in depts)
                    {
                        if (DepartmentCb.Text == dept.Title)
                        {
                            employeeSave.ClipherDepartment = dept.Clipher;
                        }
                    }
                    if (employee.Position == "зав. кафедрой")
                    {
                        HeadDepartment headDepartment = new HeadDepartment();
                        headDepartment.Seniority = int.Parse(SeniorityTb.Text);
                        headDepartment.TabNumberEmployee = int.Parse(NumberTb.Text);
                        headDepartment.Login = LoginTb.Text;
                        headDepartment.Password = PasswordTb.Text;
                        App.db.HeadDepartment.Add(headDepartment);
                    }
                    else if (employee.Position == "преподаватель")
                    {
                        Educator educatorSave = new Educator();
                        educatorSave.TabNumberEmployee = int.Parse(NumberTb.Text);
                        educatorSave.Login = LoginTb.Text;
                        educatorSave.Degree = DegreeTb.Text;
                        educatorSave.Title= TitleTb.Text;
                        educatorSave.Password = PasswordTb.Text;
                        App.db.Educator.Add(educatorSave);
                    }
                    else if (employee.Position == "инженер")
                    {
                        Engineer engineerSave = new Engineer();
                        engineerSave.Login = LoginTb.Text;
                        engineerSave.Password = PasswordTb.Text;
                        engineerSave.Specialty = SpecialtyCb.Text;
                        engineerSave.TabNumberEmployee= int.Parse(NumberTb.Text);
                        App.db.Engineer.Add(engineerSave);
                    }
                    App.db.Employee.Add(employeeSave);
                    App.db.SaveChanges();
                    MessageBox.Show("Сохранено");
                    navigation.BackPage();
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже существует!");
                }
            }
            else
            {
                MessageBox.Show("Произошла ошибка!");
                navigation.NextPage(new PageComponent(new MenuPage(), "Меню"));
            }

        }

        private void PositionTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            DegreeSp.Visibility = Visibility.Collapsed;
            SpecialtySp.Visibility = Visibility.Collapsed;
            TitleSp.Visibility = Visibility.Collapsed;
            SenioritySp.Visibility = Visibility.Collapsed;
            LoginTb.Visibility = Visibility.Collapsed;
            PasswordTb.Visibility = Visibility.Collapsed;
            if (Variable == 0)
            {
                if (PositionTb.Text != "")
                {
                    if (employee.Position == "зав. кафедрой")
                    {
                        IEnumerable<HeadDepartment> headDepartments = App.db.HeadDepartment;
                        SenioritySp.Visibility = Visibility.Visible;
                        LoginTb.Visibility = Visibility.Visible;
                        PasswordTb.Visibility = Visibility.Visible;
                        foreach (var headDepartment in headDepartments)
                        {
                            if (headDepartment.TabNumberEmployee == employee.TabNumber)
                            {
                                SeniorityTb.Text = headDepartment.Seniority.ToString();
                                LoginTb.Text = headDepartment.Login;
                                PasswordTb.Text = headDepartment.Password;

                            }
                        }

                    }
                    else if (employee.Position == "преподаватель")
                    {
                        IEnumerable<Educator> educators = App.db.Educator;
                        TitleSp.Visibility = Visibility.Visible;
                        DegreeSp.Visibility = Visibility.Visible;
                        LoginTb.Visibility = Visibility.Visible;
                        PasswordTb.Visibility = Visibility.Visible;
                        foreach (var educator in educators)
                        {
                            if (educator.TabNumberEmployee == employee.TabNumber)
                            {
                                TitleTb.Text = educator.Title;
                                DegreeTb.Text = educator.Degree;
                                LoginTb.Text = educator.Login;
                                PasswordTb.Text = educator.Password;
                            }
                        }
                    }
                    else if (employee.Position == "инженер")
                    {
                        IEnumerable<Engineer> engineers = App.db.Engineer;
                        SpecialtySp.Visibility = Visibility.Visible;
                        LoginTb.Visibility = Visibility.Visible;
                        PasswordTb.Visibility = Visibility.Visible;
                        foreach (var engineer in engineers)
                        {
                            if (engineer.TabNumberEmployee == employee.TabNumber)
                            {
                                SpecialtyCb.Text = engineer.Specialty;
                                LoginTb.Text = engineer.Login;
                                PasswordTb.Text = engineer.Password;
                            }
                        }
                    }
                }
            }
            else if (Variable == 1)
            {
                if (PositionTb.Text != "")
                {
                    if (employee.Position == "зав. кафедрой")
                    {
                        SenioritySp.Visibility = Visibility.Visible;
                        LoginTb.Visibility = Visibility.Visible;
                        PasswordTb.Visibility = Visibility.Visible;
                    }
                    else if (employee.Position == "преподаватель")
                    {
                        TitleSp.Visibility = Visibility.Visible;
                        DegreeSp.Visibility = Visibility.Visible;
                        LoginTb.Visibility = Visibility.Visible;
                        PasswordTb.Visibility = Visibility.Visible;
                    }
                    else if (employee.Position == "инженер")
                    {
                        SpecialtySp.Visibility = Visibility.Visible;
                        LoginTb.Visibility = Visibility.Visible;
                        PasswordTb.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                MessageBox.Show("Произошла ошибка!");
                navigation.NextPage(new PageComponent(new MenuPage(), "Меню"));
            }
        }
    }
}
