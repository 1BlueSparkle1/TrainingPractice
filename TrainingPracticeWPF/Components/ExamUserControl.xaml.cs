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
    /// Логика взаимодействия для ExamUserControl.xaml
    /// </summary>
    public partial class ExamUserControl : UserControl
    {
        public static Exam exam;
        public ExamUserControl(Exam _exam)
        {
            InitializeComponent();
            exam = _exam;
            DateTb.Text = exam.DateExam.ToString();
            AudienceTb.Text = exam.Audience.ToString();
            ObjectTb.Text = exam.Discipline.Title;
            StudentTb.Text = exam.Student.Surname;
            EducatorTb.Text = exam.Employee.Surname;
            ScoreTb.Text = exam.Appraisal.ToString();
        }
    }
}
