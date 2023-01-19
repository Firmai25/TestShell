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
using System.Windows.Shapes;
using TestShell.Entities;

namespace TestShell.Pages.TeacherPage
{
    /// <summary>
    /// Логика взаимодействия для SelectTypeQuestionWindow.xaml
    /// </summary>
    public partial class SelectTypeQuestionWindow : Window
    {
        Cherepanov_TestingEntities db = new Cherepanov_TestingEntities();
        public SelectTypeQuestionWindow()
        {
            InitializeComponent();
            TypeQuestionList.ItemsSource = db.Type_question.ToList();

        }

        private void TestsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TypeQuestionList.SelectedIndex != -1)
                Close();
        }
    }
}
