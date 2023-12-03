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
    /// Логика взаимодействия для SpecialtyListPage.xaml
    /// </summary>
    public partial class SpecialtyListPage : Page
    {
        public SpecialtyListPage()
        {
            InitializeComponent();
            IEnumerable<Specialty> specialties = App.db.Specialty;
            foreach(Specialty specialty in specialties)
            {
                SpecialtyWp.Children.Add(new SpecialtyUserControl(specialty));
            }
        }
    }
}
