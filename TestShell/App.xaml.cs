using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestShell.Classes;

namespace TestShell
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindowClass windowMain = new MainWindowClass();
        public static DataTeacher dataTeacher = new DataTeacher();
        public static DataTest dataTest = new DataTest();
    }
}
