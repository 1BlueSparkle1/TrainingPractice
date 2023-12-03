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
    /// Логика взаимодействия для FacultyListPage.xaml
    /// </summary>
    public partial class FacultyListPage : Page
    {
        public FacultyListPage()
        {
            InitializeComponent();
            IEnumerable<Faculty> faculties = App.db.Faculty;
            foreach (var faculty in faculties)
            {
                FacultyWp.Children.Add(new FacultyUserControl(faculty));
            }
        }
    }
}
