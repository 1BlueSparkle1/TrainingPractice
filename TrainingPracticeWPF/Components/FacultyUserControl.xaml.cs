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
    /// Логика взаимодействия для FacultyUserControl.xaml
    /// </summary>
    public partial class FacultyUserControl : UserControl
    {
        public static Faculty faculty;
        public FacultyUserControl(Faculty _faculty)
        {
            InitializeComponent();
            faculty = _faculty;
            AbbrTb.Text = faculty.Abbreviation;
            TitleTb.Text = faculty.Title;
        }
    }
}
