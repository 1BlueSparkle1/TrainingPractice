using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TrainingPracticeWPF.Components;

namespace TrainingPracticeWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static TrainingPractice322Entities db = new TrainingPractice322Entities();
        public static MainWindow mainWindows;
        public static string person = "Guest";
    }
}
