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
    /// Логика взаимодействия для DepartmentListPage.xaml
    /// </summary>
    public partial class DepartmentListPage : Page
    {
        public DepartmentListPage()
        {
            InitializeComponent();
            var departments = App.db.Department.ToList();
            foreach (var department in departments)
            {
                DepartmentWp.Children.Add(new DepartmentUserControl(department));
            }
        }
        private void Refresh()
        {
            IEnumerable<Department> departments = App.db.Department;
            departments = departments.Where(x => x.Title.ToLower().Contains(TextTb.Text.ToLower()));
            if (FacultyCb.SelectedIndex != 0)
            {
                if (FacultyCb.SelectedIndex == 1)
                {
                    departments = departments.OrderBy(x => x.AbbreviationFaculty);
                }
                else if (FacultyCb.SelectedIndex == 2)
                {
                    departments = departments.OrderByDescending(x => x.AbbreviationFaculty);
                }
            }
            DepartmentWp.Children.Clear();
            foreach (var department in departments)
            {
                DepartmentWp.Children.Add(new DepartmentUserControl(department));
            }
        }

        private void FacultyCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void TextTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            navigation.NextPage(new PageComponent(new EditDepartmentPage(new Department(), 1), "Добавление"));
        }
    }
}
