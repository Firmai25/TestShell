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
    /// Логика взаимодействия для OpenQuestionPage.xaml
    /// </summary>
    public partial class OpenQuestionPage : Page
    {
        public OpenQuestionPage(Test test)
        {
            InitializeComponent();
            NameText.Text = test.Name;
            TbDescription.Text = test.Description;
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            App.windowMain.window.BackPage();
        }

        private void OpenTest_CLick(object sender, RoutedEventArgs e)
        {
            App.windowMain.window.NextPage(new QuestionPage());
        }
    }
}
