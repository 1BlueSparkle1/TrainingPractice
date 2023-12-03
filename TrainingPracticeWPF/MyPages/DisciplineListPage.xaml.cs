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
    /// Логика взаимодействия для DisciplineListPage.xaml
    /// </summary>
    public partial class DisciplineListPage : Page
    {
        public DisciplineListPage()
        {
            InitializeComponent();
            var disciplines = App.db.Discipline.ToList();
            foreach (var discipline in disciplines)
            {
                DisciplineWp.Children.Add(new DisciplineUserControl(discipline));
            }
        }
        private void Refresh()
        {
            IEnumerable<Discipline> disciplines = App.db.Discipline;
            if (ScopeCb.SelectedIndex != 0)
            {
                if (ScopeCb.SelectedIndex == 1)
                {
                    disciplines = disciplines.OrderBy(x => x.Scope);
                }
                else if (ScopeCb.SelectedIndex == 2)
                {
                    disciplines = disciplines.OrderByDescending(x => x.Scope);
                }
            }
            if (DepartmentCb.SelectedIndex != 0)
            {
                if (DepartmentCb.SelectedIndex == 1)
                {
                    disciplines = disciplines.OrderBy(x => x.ClipherDepartment);
                }
                else if (DepartmentCb.SelectedIndex == 2)
                {
                    disciplines = disciplines.OrderByDescending(x => x.ClipherDepartment);
                }
            }
            disciplines = disciplines.Where(x => x.Title.ToLower().Contains(TextTb.Text.ToLower()));
            DisciplineWp.Children.Clear();
            foreach (var discipline in disciplines)
            {
                DisciplineWp.Children.Add(new DisciplineUserControl(discipline));
            }
        }

        private void ScopeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DepartmentCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void TextTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
