using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace TorchFlow
{
    /// <summary>
    /// Logica di interazione per darker_background.xaml
    /// </summary>
    public partial class darker_background : Window
    {
        public darker_background()
        {
            InitializeComponent();
            Background = Brushes.Black;                                     // Background settings
            Opacity = 0.4;
            AllowsTransparency = true;
            WindowStyle = WindowStyle.None;
            WindowState = WindowState.Maximized;
            Topmost = false;
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();                                 // Close all windows (exit code=0)
          
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt) // Is Alt key pressed
            {
                if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.Space))
                {
                    darker_background backg = new darker_background();
                    backg.Hide();
                    MainWindow mainw = new MainWindow();
                    mainw.Hide();
                }
            }
        }
    }
}
