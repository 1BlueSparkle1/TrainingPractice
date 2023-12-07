using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EditExamPage.xaml
    /// </summary>
    public partial class EditExamPage : Page
    {
        public Exam exam1;
        public EditExamPage()
        {
            InitializeComponent();
            IdCb.ItemsSource = App.db.Exam.OrderBy(x=>x.Id).ToList();
            IdCb.DisplayMemberPath = "Id";
            StudentCb.ItemsSource = App.db.Students.ToList();
            StudentCb.DisplayMemberPath = "Surname";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Exam> exams = App.db.Exam;
            foreach (var exam in exams)
            {
                if (IdCb.Text == exam.Id.ToString())
                {
                    Regex regexSpore = new Regex(@"[0-5]");
                    if (IdCb.Text != "" && StudentCb.Text != "")
                    {
                        if (regexSpore.IsMatch(ScoreTb.Text))
                        {
                            Exam exam2 = exam;
                            exam2.Student.Surname = StudentCb.Text;
                            App.db.Exam.Add(exam2);
                            MessageBox.Show("Сохранено");
                            navigation.BackPage();
                        }
                        else
                        {
                            MessageBox.Show("Некоректно введена оценка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите экзамен и студента");
                    }
                }
            }
            App.db.SaveChanges();
        }

        private void IdCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IEnumerable<Exam> exams = App.db.Exam;
            foreach (var exam in exams)
            {
                if (IdCb.Text == exam.Id.ToString())
                {
                    DateTb.Text = exam.DateExam.ToString();
                    AudienceTb.Text = exam.Audience;
                    ObjectTb.Text = exam.Discipline.Title;
                    EducatorTb.Text = exam.Employee.Surname;
                    ScoreTb.Text = exam.Appraisal.ToString();
                }
            }
        }
    }
}
