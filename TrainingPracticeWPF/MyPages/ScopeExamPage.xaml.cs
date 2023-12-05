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
    /// Логика взаимодействия для ScopeExamPage.xaml
    /// </summary>
    public partial class ScopeExamPage : Page
    {
        public static Exam exam;
        public ScopeExamPage(Exam _exam)
        {
            InitializeComponent();
            exam = _exam;
            this.DataContext = exam;
        }

        private void ScopeBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex regexSpore = new Regex(@"[0-5]");
            if (ScoreTb.Text != null && ScoreTb.Text != "")
            {
                if (regexSpore.IsMatch(ScoreTb.Text))
                {
                    App.db.SaveChanges();
                    MessageBox.Show("Сохранено");
                    navigation.BackPage();
                }
                else
                {
                    MessageBox.Show("Некоректно введена оценка");
                }
            }
        }
    }
}
