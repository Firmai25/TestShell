using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
using TestShell.Pages.TeacherPage.TypeQuestion;

namespace TestShell.Pages.TeacherPage
{
    /// <summary>
    /// Логика взаимодействия для CreateQuestionPage.xaml
    /// </summary>
    public partial class CreateQuestionPage : Page
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public CreateQuestionPage()
        {
            InitializeComponent();
            SelectTypeQuestionWindow win = new SelectTypeQuestionWindow();
            win.Owner = App.windowMain.window;
            win.ShowDialog();
            Type_question type_q = (Type_question)win.TypeQuestionList.SelectedItem;
            switch (type_q.name)
            {
                case "Один ответ":
                    masPage[0] = new OneOwnerPage();
                    masPage[Location].Name = "OneOwner";
                    FrameQuestion.Navigate(masPage[0]);
                    break;
                case "Несколько ответов":
                    masPage[0] = new SeveralOwnerPage();
                    masPage[Location].Name = "SeveralOwner";
                    FrameQuestion.Navigate(masPage[0]);
                    break;
            }
        }
        Page[] masPage = new Page[1];   
        int Location = 0;
        private void nextPage_Click(object sender, RoutedEventArgs e)
        {
            if (Location < masPage.Length - 1)
            {
                //page[Location] = (Page)FrameQuestion.Content;
                FrameQuestion.Navigate(masPage[Location + 1]);
                Location++;
            }
            else
            {
                Page[] masPage2 = new Page[masPage.Length + 1];
                for (int i = 0; i < masPage.Length; i++)
                {
                    masPage2[i] = masPage[i];
                }
                masPage = masPage2;
                Location++;
                SelectTypeQuestionWindow win = new SelectTypeQuestionWindow();
                win.Owner = App.windowMain.window;
                win.ShowDialog();
                Type_question type_q = (Type_question)win.TypeQuestionList.SelectedItem;
                switch (type_q.name)
                {
                    case "Один ответ":
                        masPage[Location] = new OneOwnerPage();
                        masPage[Location].Name = "OneOwner";
                        FrameQuestion.Navigate(masPage[Location]);
                        break;
                    case "Несколько ответов":
                        masPage[Location] = new SeveralOwnerPage();
                        masPage[Location].Name = "SeveralOwner";
                        FrameQuestion.Navigate(masPage[Location]);
                        break;
                }
                
            }
        }
        //Сохранения и занесение данных в бд
        private void Save()
        {
            
            for (int i = 0; i < masPage.Length; i++)
            {
                
                switch(masPage[i].Name) // По имени опредяет какая тип вопроса
                {
                    case "OneOwner":
                        OneOwnerPage pageOneOwner =(OneOwnerPage)masPage[i]; //Конвиртируем в нужный формат
                        Save_OneOwnerPage(pageOneOwner);
                        break;
                    case "SeveralOwner":
                        SeveralOwnerPage severalOwnerPage = (SeveralOwnerPage)masPage[i];
                        Save_SeveralOwnerPage(severalOwnerPage);
                        break;
                }
                
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

        private void SavePage_Click(object sender, RoutedEventArgs e)
        {
            Save();
            App.windowMain.window.NextPage(new MainTeacherPage());
            App.windowMain.window.FrameMain.NavigationService.RemoveBackEntry();
        }

        public void Save_OneOwnerPage(OneOwnerPage page)
        {
            Question question = new Question();
            question.id_type = 1;
            question.Text_question = page.QuestionDescription.Text;
            question.Id_Test = App.dataTest.id;
            db.Questions.Add(question);
            db.SaveChanges();
            int countTextbox = 1;
            foreach (TextBox textBox in page.Gr.Children.OfType<TextBox>())
            {
                if (((SolidColorBrush)textBox.BorderBrush).Color == Colors.Green)
                {
                    Answer answer = new Answer();
                    answer.Text_Answer = textBox.Text;
                    answer.Number = countTextbox;
                    answer.Correct = 1;
                    db.Answers.Add(answer);
                    Question_Answer question_Answer = new Question_Answer();
                    question_Answer.Id_Answer = answer.Id;
                    question_Answer.Id_question = question.Id;
                    db.Question_Answer.Add(question_Answer);
                    db.SaveChanges();
                    countTextbox++;

                }
                else
                {
                    Answer noAnswer = new Answer();
                    noAnswer.Text_Answer = textBox.Text;
                    noAnswer.Number = countTextbox;
                    noAnswer.Correct = 0;
                    db.Answers.Add(noAnswer);
                    Question_Answer question_NoAnswer = new Question_Answer();
                    question_NoAnswer.Id_Answer = noAnswer.Id;
                    question_NoAnswer.Id_question = question.Id;
                    db.Question_Answer.Add(question_NoAnswer);
                    db.SaveChanges();
                    countTextbox++;
                }
            }
        }

        public void Save_SeveralOwnerPage(SeveralOwnerPage page)
        {
            Question question = new Question();
            question.id_type = 2;
            question.Text_question = page.QuestionDescription.Text;
            question.Id_Test = App.dataTest.id;
            db.Questions.Add(question);
            db.SaveChanges();
            int countTextbox = 1;
            foreach (TextBox textBox in page.Gr.Children.OfType<TextBox>())
            {
                if (((SolidColorBrush)textBox.BorderBrush).Color == Colors.Green)
                {
                    Answer answer = new Answer();
                    answer.Text_Answer = textBox.Text;
                    answer.Number = countTextbox;
                    answer.Correct = 1;
                    db.Answers.Add(answer);
                    Question_Answer question_Answer = new Question_Answer();
                    question_Answer.Id_Answer = answer.Id;
                    question_Answer.Id_question = question.Id;
                    db.Question_Answer.Add(question_Answer);
                    db.SaveChanges();
                    countTextbox++;

                }
                else
                {
                    Answer noAnswer = new Answer();
                    noAnswer.Text_Answer = textBox.Text;
                    noAnswer.Number = countTextbox;
                    noAnswer.Correct = 0;
                    db.Answers.Add(noAnswer);
                    Question_Answer question_NoAnswer = new Question_Answer();
                    question_NoAnswer.Id_Answer = noAnswer.Id;
                    question_NoAnswer.Id_question = question.Id;
                    db.Question_Answer.Add(question_NoAnswer);
                    db.SaveChanges();
                    countTextbox++;
                }
            }
        }
    }
}
