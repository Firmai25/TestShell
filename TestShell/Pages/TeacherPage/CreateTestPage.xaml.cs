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
    /// Логика взаимодействия для CreateTestPage.xaml
    /// </summary>
    public partial class CreateTestPage : Page
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public CreateTestPage()
        {
            InitializeComponent();
        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {
            if (TbName.Text != "")
            {
                Test test = new Test();
                test.Name = TbName.Text;
                test.id_Teacher = App.dataTeacher.id;
                test.Description = TbSpecification.Text;
                db.Tests.Add(test);
                db.SaveChanges();
                App.dataTest.id = test.Id;
                App.windowMain.window.NextPage(new CreateQuestionPage());

            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            App.windowMain.window.BackPage();
        }
    }
}
