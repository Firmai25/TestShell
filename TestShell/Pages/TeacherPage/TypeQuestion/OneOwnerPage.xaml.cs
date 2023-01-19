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

namespace TestShell.Pages.TeacherPage.TypeQuestion
{
    /// <summary>
    /// Логика взаимодействия для OneOwnerPage.xaml
    /// </summary>
    public partial class OneOwnerPage : Page
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public OneOwnerPage()
        {
            InitializeComponent();
        }

        private void rbQuestionOne_Checked(object sender, RoutedEventArgs e)
        {
            QuestionOne.BorderBrush = new SolidColorBrush(Colors.Red);
            QuestionTwo.BorderBrush = new SolidColorBrush(Colors.Red);
            QuestionThree.BorderBrush = new SolidColorBrush(Colors.Red);
            QuestionFo.BorderBrush = new SolidColorBrush(Colors.Red);
            if (rbQuestionOne.IsChecked == true)
                QuestionOne.BorderBrush = new SolidColorBrush(Colors.Green);
            if (rbQuestionTwo.IsChecked == true)
                QuestionTwo.BorderBrush = new SolidColorBrush(Colors.Green);
            if (rbQuestionThree.IsChecked == true)
                QuestionThree.BorderBrush = new SolidColorBrush(Colors.Green);
            if (rbQuestionFo.IsChecked == true)
                QuestionFo.BorderBrush = new SolidColorBrush(Colors.Green);

        }

    }
}
