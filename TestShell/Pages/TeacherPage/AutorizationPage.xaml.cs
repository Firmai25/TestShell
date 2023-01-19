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
using TestShell.Entities;

namespace TestShell.Pages.TeacherPage
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher = db.Teachers.Where(b => b.Login == AutorizationTb.Text && b.Password == PasswordDb.Text).FirstOrDefault();
            if (teacher != null)
            {
                App.dataTeacher.id = teacher.Id;
                App.windowMain.window.NextPage(new MainTeacherPage());
            }
            else
            {
                ErrorText.Visibility = Visibility.Visible;
            }
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            App.windowMain.window.BackPage();
        }
    }
}
