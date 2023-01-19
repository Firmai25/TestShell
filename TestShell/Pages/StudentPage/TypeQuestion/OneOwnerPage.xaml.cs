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

namespace TestShell.Pages.StudentPage.TypeQuestion
{
    /// <summary>
    /// Логика взаимодействия для OneOwnerPage.xaml
    /// </summary>
    public partial class OneOwnerPage : Page
    {
        public OneOwnerPage()
        {
            InitializeComponent();
        }

        private void rbQuestionOne_Checked(object sender, RoutedEventArgs e)
        {
            QuestionOne.FontFamily = new FontFamily("Segoe UI");
            QuestionTwo.FontFamily = new FontFamily("Segoe UI");
            QuestionThree.FontFamily = new FontFamily("Segoe UI");
            QuestionFo.FontFamily = new FontFamily("Segoe UI");
            if (rbQuestionOne.IsChecked == true)
                QuestionOne.FontFamily = new FontFamily("Segoe UI Black");
            if (rbQuestionTwo.IsChecked == true)
                QuestionTwo.FontFamily = new FontFamily("Segoe UI Black");
            if (rbQuestionThree.IsChecked == true)
                QuestionThree.FontFamily = new FontFamily("Segoe UI Black");
            if (rbQuestionFo.IsChecked == true)
                QuestionFo.FontFamily = new FontFamily("Segoe UI Black");
        }
    }
}
