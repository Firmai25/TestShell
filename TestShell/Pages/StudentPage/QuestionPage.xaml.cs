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
using System.Windows.Threading;
using TestShell.Entities;
using TestShell.Pages.StudentPage.TypeQuestion;

namespace TestShell.Pages.StudentPage
{
    /// <summary>
    /// Логика взаимодействия для QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public DataGrid dgAnswers = new DataGrid();
        public QuestionPage()
        {
            InitializeComponent();          
            Test test = new Test();
            test = db.Tests.Where(b => b.Id == App.dataTest.id).FirstOrDefault();         
            dgAnswers.ItemsSource = db.Questions.Where(b => b.Id_Test == App.dataTest.id).ToList();
            masPage = new Page[db.Questions.Where(b => b.Id_Test == App.dataTest.id).Count()];
            correct_answer = new string[db.Questions.Where(b => b.Id_Test == App.dataTest.id).Count(),4];
            Generation_Test();
        }
        int countP = 0;
        Page[] masPage;
        string[,] correct_answer;
        int CountC = 0;

        public void Generation_Test()
        {
            for (int i = 0; i< db.Questions.Where(b => b.Id_Test == App.dataTest.id).Count(); i++)
            {
                dgAnswers.SelectedIndex = countP;
                Question question = (Question)dgAnswers.SelectedItem;
                switch (question.id_type)
                {
                    case 1:
                        OneOwnerPage oneOwnerPage = new OneOwnerPage();
                        Generation_OneOwnew(oneOwnerPage, question);
                        break;
                    case 2:
                        SeveralOwnerPage severalOwnerPage = new SeveralOwnerPage();
                        Generation_SeveralOwnew(severalOwnerPage, question);
                        break;
                }
                countP++;
            }
            FrameQuestion.Navigate(masPage[0]);
        }

        public void Generation_OneOwnew(OneOwnerPage page, Question question)
        {
            page.QuestionDescription.Text = question.Text_question;
            page.Name = "OneOwnerPage";
            DataGrid dgdOne = new DataGrid();
            dgdOne.ItemsSource = db.Question_Answer.Where(b => b.Id_question == question.Id).ToList();
            int countI = 0;
            foreach (TextBlock textBox in page.Gr.Children.OfType<TextBlock>())
            {
                dgdOne.SelectedIndex = countI;
                Question_Answer qu_an = (Question_Answer)dgdOne.SelectedItem;
                Answer answer = db.Answers.Where(b => b.Id == qu_an.Id_Answer).FirstOrDefault();
                textBox.Text = answer.Text_Answer;
                if (answer.Correct == 1)
                {
                    correct_answer[CountC,0] = answer.Text_Answer;
                    CountC++;
                }
                countI++;
            }
            masPage[countP] = page;
        }

        public void Generation_SeveralOwnew(SeveralOwnerPage page, Question question)
        {
            page.QuestionDescription.Text = question.Text_question;
            page.Name = "severalOwnerPage";
            DataGrid dgdOne = new DataGrid();
            dgdOne.ItemsSource = db.Question_Answer.Where(b => b.Id_question == question.Id).ToList();
            int countI = 0;
            int CountS = 0;
            foreach (TextBlock textBox in page.Gr.Children.OfType<TextBlock>())
            {
                dgdOne.SelectedIndex = countI;
                Question_Answer qu_an = (Question_Answer)dgdOne.SelectedItem;
                Answer answer = db.Answers.Where(b => b.Id == qu_an.Id_Answer).FirstOrDefault();
                textBox.Text = answer.Text_Answer;
                if (answer.Correct == 1)
                {
                    correct_answer[CountC, CountS] = answer.Text_Answer;
                    CountS++;
                }
                countI++;
            }
            CountC++;
            masPage[countP] = page;
        }

        int Location = 0;
        private void nextPage_Click(object sender, RoutedEventArgs e)
        {
            if (Location < masPage.Length - 1)
            {
                FrameQuestion.Navigate(masPage[Location + 1]);
                Location++;
            }
        }

        private void baclPage_Click(object sender, RoutedEventArgs e)
        {
            if (Location > 0)
            {
                FrameQuestion.Navigate(masPage[Location - 1]);
                Location--;
            }
        }
        double countOwnew = 0;
        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            countOwnew = 0;
            for (int i = 0; i< db.Questions.Where(b => b.Id_Test == App.dataTest.id).Count(); i++)
            {
                switch (masPage[i].Name)
                {
                    case "OneOwnerPage":
                        OneOwnerPage oneOwnerPage = (OneOwnerPage)masPage[i];
                        foreach (TextBlock textBox in oneOwnerPage.Gr.Children.OfType<TextBlock>())
                        {
                            if(textBox.FontFamily.ToString() == "Segoe UI Black")
                            {
                                if (correct_answer[i,0] == textBox.Text)
                                    countOwnew++;
                            }
                        }
                        break;
                    case "severalOwnerPage":
                        SeveralOwnerPage severalOwnerPage = (SeveralOwnerPage)masPage[i];
                        double countOw = 0;
                        for (int j = 0; j < 4; j++)
                        {
                            if (correct_answer[i, j] != null)
                                countOw++;
                        }
                        double countOwe = countOw + 1;
                        foreach (TextBlock textBox in severalOwnerPage.Gr.Children.OfType<TextBlock>())
                        {
                            
                            for (int j =0; j<4; j++)
                            {
                                if (correct_answer[i, j] != null)
                                {
                                    if (textBox.FontFamily.ToString() == "Segoe UI Black")
                                    {
                                        if (correct_answer[i, j] == textBox.Text)
                                            countOwe--;
                                    }
                                }
                                
                            }
                            
                        }

                        if(countOwe != countOw + 1)
                        {
                            double sum = 1 / countOwe;
                            countOwnew = countOwnew + sum;
                        }                                               
                        
                        break;
                }
            }
            MessageBox.Show("Количество баллов: " + countOwnew.ToString());
            App.windowMain.window.NextPage(new AllTestPage());
        }
    }
}
