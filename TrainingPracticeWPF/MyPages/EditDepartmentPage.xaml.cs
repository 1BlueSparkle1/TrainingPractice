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
    /// Логика взаимодействия для EditDepartmentPage.xaml
    /// </summary>
    public partial class EditDepartmentPage : Page
    {
        public Department department;
        public static int Variable;
        public EditDepartmentPage(Department _department, int x)
        {
            InitializeComponent();
            department = _department;
            Variable = x;
            this.DataContext = department;
            FacultyCb.ItemsSource = App.db.Faculty.ToList();
            FacultyCb.DisplayMemberPath = "Title";
            if (Variable == 0)
            {
                FacultyCb.Text = department.Faculty.Title;
            }
            
            
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClipherTb.Text == "" || TitleTb.Text == "" || FacultyCb.Text == "")
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                if (Variable == 0)
                {
                    IEnumerable<Faculty> faculties = App.db.Faculty;
                    foreach(var faculty in faculties)
                    {
                        if (faculty.Title == FacultyCb.Text)
                        {
                            department.AbbreviationFaculty = faculty.Abbreviation;
                        }
                    }
                    App.db.SaveChanges();
                    MessageBox.Show("Сохранено");
                    navigation.BackPage();
                }
                else if (Variable == 1)
                {
                    IEnumerable<Faculty> faculties = App.db.Faculty;
                    foreach (var faculty in faculties)
                    {
                        if (faculty.Title == FacultyCb.Text)
                        {
                            department.AbbreviationFaculty = faculty.Abbreviation;
                        }
                    }
                    department.Title = TitleTb.Text;
                    department.Clipher = ClipherTb.Text;
                    IEnumerable<Department> departments = App.db.Department;
                    foreach(var depart in departments)
                    {
                        if (ClipherTb.Text == depart.Clipher)
                        {
                            MessageBox.Show("Кафедра с таким шифром уже существует.");
                            break;
                        }
                        else
                        {
                            Variable = 5;
                        }
                    }
                    if (Variable == 5)
                    {
                        App.db.Department.Add(department);
                        App.db.SaveChanges();
                        MessageBox.Show("Сохранено");
                        navigation.BackPage();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Произошла ошибка!");
                }
            }
        }
    }
}
