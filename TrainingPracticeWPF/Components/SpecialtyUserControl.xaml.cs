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
    /// Логика взаимодействия для SpecialtyUserControl.xaml
    /// </summary>
    public partial class SpecialtyUserControl : UserControl
    {
        public static Specialty specialty;
        public SpecialtyUserControl(Specialty _specialty)
        {
            InitializeComponent();
            specialty = _specialty;
            NumberTb.Text = specialty.Number;
            TitleTb.Text = specialty.Direction;
            DepartmentTb.Text = specialty.Department.Title;
        }
    }
}
