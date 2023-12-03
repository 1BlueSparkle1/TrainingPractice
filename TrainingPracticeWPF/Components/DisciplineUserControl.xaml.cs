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
    /// Логика взаимодействия для DisciplineUserControl.xaml
    /// </summary>
    public partial class DisciplineUserControl : UserControl
    {
        public static Discipline discipline;
        public DisciplineUserControl(Discipline _discipline)
        {
            InitializeComponent();
            discipline = _discipline;
            CodeTb.Text = discipline.Code.ToString();
            ScopeTb.Text = discipline.Scope.ToString();
            TitleTb.Text = discipline.Title;
            DepartmentTb.Text = discipline.ClipherDepartment;
        }
    }
}
