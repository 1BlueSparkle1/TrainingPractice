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
    /// Логика взаимодействия для DepartmentUserControl.xaml
    /// </summary>
    public partial class DepartmentUserControl : UserControl
    {
        public static Department department;
        public DepartmentUserControl(Department _department)
        {
            InitializeComponent();
            department = _department;
            ClipherTb.Text = department.Clipher;
            TitleTb.Text = department.Title;
            //FacultyTb.Text = department.AbbreviationFaculty;
            IEnumerable<Faculty> faculties = App.db.Faculty;
            foreach (var fac in faculties)
            {
                if (fac.Abbreviation == department.AbbreviationFaculty)
                {
                    FacultyTb.Text = fac.Title;
                }
            }

        }
    }
}
