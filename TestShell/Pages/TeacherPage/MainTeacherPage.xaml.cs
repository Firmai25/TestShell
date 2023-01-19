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

namespace TestShell.Pages.TeacherPage
{
    /// <summary>
    /// Логика взаимодействия для MainTeacherPage.xaml
    /// </summary>
    public partial class MainTeacherPage : Page
    {
        public MainTeacherPage()
        {
            InitializeComponent();
        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {
            App.windowMain.window.NextPage(new CreateTestPage());
        }

        private void ExitPage_Click(object sender, RoutedEventArgs e)
        {
            App.windowMain.window.NextPage(new SelectMainPage());
            App.windowMain.window.FrameMain.NavigationService.RemoveBackEntry();
        }
    }
}
