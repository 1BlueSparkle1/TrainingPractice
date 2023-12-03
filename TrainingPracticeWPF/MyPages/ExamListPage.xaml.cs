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
    /// Логика взаимодействия для ExamListPage.xaml
    /// </summary>
    public partial class ExamListPage : Page
    {
        public ExamListPage()
        {
            InitializeComponent();
            IEnumerable<Exam> exams = App.db.Exam;
            foreach (var exam in exams)
            {
                ExamListWp.Children.Add(new ExamUserControl(exam));
            }
        }
        private void Refresh()
        {
            IEnumerable<Exam> exams = App.db.Exam;
            if (DateCb.SelectedIndex != 0)
            {
                if (DateCb.SelectedIndex == 1)
                {
                    exams = exams.OrderBy(x => x.DateExam);
                }
                else if (DateCb.SelectedIndex == 2)
                {
                    exams = exams.OrderByDescending(x => x.DateExam);
                }
            }
            if (AudienceCb.SelectedIndex != 0)
            {
                if (AudienceCb.SelectedIndex == 1)
                {
                    exams = exams.OrderBy(x => x.Audience);
                }
                else if (AudienceCb.SelectedIndex == 2)
                {
                    exams = exams.OrderByDescending(x => x.Audience);
                }
            }
            if (DisciplineCb.SelectedIndex != 0)
            {
                if (DisciplineCb.SelectedIndex == 1)
                {
                    exams = exams.OrderBy(x => x.Discipline.Title);
                }
                else if (DisciplineCb.SelectedIndex == 2)
                {
                    exams = exams.OrderByDescending(x => x.Discipline.Title);
                }
            }
            exams = exams.Where(x => x.Student.Surname.ToLower().Contains(StudentTb.Text.ToLower()));
            exams = exams.Where(x => x.Employee.Surname.ToLower().Contains(EducatorTb.Text.ToLower()));
            ExamListWp.Children.Clear();
            foreach (var exam in exams)
            {
                ExamListWp.Children.Add(new ExamUserControl(exam));
            }
        }

        private void DateCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void AudienceCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DisciplineCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void StudentTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void EducatorTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
