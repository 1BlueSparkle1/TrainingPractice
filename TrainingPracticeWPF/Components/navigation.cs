using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TrainingPracticeWPF.Components
{
    static class navigation
    {
        public static MainWindow mainWindow;
        public static List<PageComponent> components = new List<PageComponent>();
        private static void Update(PageComponent pageComponent)
        {
            mainWindow.MainFrame.Navigate(pageComponent.Page);
            mainWindow.BackBtn.Visibility = components.Count() > 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            mainWindow.TitleTb.Text = pageComponent.Title;
          
        }
        public static void NextPage(PageComponent pageComponent)
        {
            components.Add(pageComponent);
            Update(pageComponent);
        }
        public static void BackPage()
        {
            if (components.Count > 1)
            {
                components.RemoveAt(components.Count - 1);
                Update(components[components.Count - 1]);
            }
        }
        public static void Clear()
        {
            components.Clear();
        }
        public static void show(PageComponent pageComponent)
        {
            mainWindow.MainFrame.Navigate(pageComponent.Page);
        }
    }
    public class PageComponent
    {
        public Page Page { get; set; }
        public string Title { get; set; }
        public PageComponent(Page page, string title)
        {
            Page = page;
            Title = title;
        }
    }
}
