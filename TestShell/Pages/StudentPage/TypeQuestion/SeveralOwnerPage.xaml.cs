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
    /// Логика взаимодействия для SeveralOwnerPage.xaml
    /// </summary>
    public partial class SeveralOwnerPage : Page
    {
        public SeveralOwnerPage()
        {
            InitializeComponent();
        }

        private void CbQuestionOne_Checked(object sender, RoutedEventArgs e)
        {
            QuestionOne.FontFamily = new FontFamily("Segoe UI Black");
        }

        private void CbQuestionOne_Unchecked(object sender, RoutedEventArgs e)
        {
            QuestionOne.FontFamily = new FontFamily("Segoe UI");
        }

        private void CbQuestionTwo_Checked(object sender, RoutedEventArgs e)
        {
            QuestionTwo.FontFamily = new FontFamily("Segoe UI Black");
        }

        private void CbQuestionTwo_Unchecked(object sender, RoutedEventArgs e)
        {
            QuestionTwo.FontFamily = new FontFamily("Segoe UI");
        }

        private void CbQuestionThree_Checked(object sender, RoutedEventArgs e)
        {
            QuestionThree.FontFamily = new FontFamily("Segoe UI Black");
        }

        private void CbQuestionThree_Unchecked(object sender, RoutedEventArgs e)
        {
            QuestionThree.FontFamily = new FontFamily("Segoe UI");
        }

        private void CbQuestionFo_Checked(object sender, RoutedEventArgs e)
        {
            QuestionFo.FontFamily = new FontFamily("Segoe UI Black");
        }

        private void CbQuestionFo_Unchecked(object sender, RoutedEventArgs e)
        {
            QuestionFo.FontFamily = new FontFamily("Segoe UI");
        }
    }
}
