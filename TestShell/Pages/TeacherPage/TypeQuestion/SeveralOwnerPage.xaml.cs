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

namespace TestShell.Pages.TeacherPage.TypeQuestion
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
            QuestionOne.BorderBrush = new SolidColorBrush(Colors.Green);

        }

        private void CbQuestionOne_Unchecked(object sender, RoutedEventArgs e)
        {
            QuestionOne.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void CbQuestionTwo_Checked(object sender, RoutedEventArgs e)
        {

                QuestionTwo.BorderBrush = new SolidColorBrush(Colors.Green);
        }

        private void CbQuestionTwo_Unchecked(object sender, RoutedEventArgs e)
        {
            QuestionTwo.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void CbQuestionThree_Checked(object sender, RoutedEventArgs e)
        {
            QuestionThree.BorderBrush = new SolidColorBrush(Colors.Green);            
        }

        private void CbQuestionThree_Unchecked(object sender, RoutedEventArgs e)
        {
            QuestionThree.BorderBrush = new SolidColorBrush(Colors.Red);
        }

        private void CbQuestionFo_Checked(object sender, RoutedEventArgs e)
        {
            QuestionFo.BorderBrush = new SolidColorBrush(Colors.Green);
        }

        private void CbQuestionFo_Unchecked(object sender, RoutedEventArgs e)
        {
            QuestionFo.BorderBrush = new SolidColorBrush(Colors.Red);
        }
    }
}
