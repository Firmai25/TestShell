using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestShell.Pages;

namespace TestShell
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            FrameMain.Navigate(new SelectMainPage());
            App.windowMain.HotKeys(this);        
        }

        public void NextPage(Page pg)
        {
            FrameMain.Navigate(pg);
            
        }

        public void BackPage()
        {
            if(FrameMain.CanGoBack)
            {
                FrameMain.GoBack();
            }
        }

        private void ExitWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

       

        private void MoveWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        bool isWidenRight;
        private void RectangleRight_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isWidenRight = true;
        }

        private void RectangleRight_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isWidenRight = false;
            Rectangle rect = (Rectangle)sender;
            rect.ReleaseMouseCapture();
        }

        private void RectangleRight_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            if (isWidenRight)
            {
                rect.CaptureMouse();
                double newWidth = e.GetPosition(this).X + 5;
                if (newWidth > 250) 
                    this.Width = newWidth;
            }
        }

        bool isWidenLeft;
        private void RectangleLeft_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isWidenLeft = true;
        }

        private void RectangleLeft_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isWidenLeft = false;
            Rectangle rect = (Rectangle)sender;
            rect.ReleaseMouseCapture();
        }

        private void Rectangle_MouseMoveLeft(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            if (isWidenLeft)
            {
                rect.CaptureMouse();
                double newWidth = e.GetPosition(this).Y + 5;
                if (newWidth > 250)
                    this.Height = newWidth;
            }
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;
        private const int WS_MAXIMIZEBOX = 0x10000;

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            var hwnd = new WindowInteropHelper((Window)sender).Handle;
            var value = GetWindowLong(hwnd, GWL_STYLE);
            SetWindowLong(hwnd, GWL_STYLE, (int)(value & ~WS_MAXIMIZEBOX));
        }
    }
}
