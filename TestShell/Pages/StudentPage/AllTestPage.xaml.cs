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

namespace TestShell.Pages.StudentPage
{
    /// <summary>
    /// Логика взаимодействия для AllTestPage.xaml
    /// </summary>
    public partial class AllTestPage : Page
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public AllTestPage()
        {
            InitializeComponent();
            TestsList.ItemsSource = db.Tests.ToList();
        }

        private void TestsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Test test = (Test)TestsList.SelectedItem;
            App.dataTest.id = test.Id;
            App.windowMain.window.NextPage(new OpenQuestionPage(test));
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            App.windowMain.window.NextPage(new SelectMainPage());
        }
    }
}
