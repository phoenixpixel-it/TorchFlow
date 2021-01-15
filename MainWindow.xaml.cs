using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using GlobalHotKey;




namespace TorchFlow
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]                             // Import user32.dll
        public static extern void SetWindowText(int hWnd, String text);                      // Import user32.dll

        public void ResizeWindow()
        {
            int main_window_height = 60;                                                     // Resize Main Window Height
            int main_window_width = 820;                                                     // Resize Main Window Width

            this.Width = main_window_width;
            this.Height = main_window_height;

            border_search.Width = main_window_width;                                         //Resize SearchBar Width

            int border_search_height = 60;
            border_search.Width = main_window_width;
            border_search.Height = border_search_height;                                     //Resize SearchBar Height
            
            int button_search_height = border_search_height / 2;                             // Resize Search Button Height
            int button_search_width = main_window_width / 2;                                 // Resize Search Button Width

            double button_search_margin_right = main_window_width / 1.12;
            search_button.Width = button_search_width;
            search_button.Height = button_search_height;
            search_button.Margin = new Thickness(0, 10, button_search_margin_right, 10);     // Resize Search Button margins

            search_tab.Width = main_window_width;                                            // Set search tab results Width
            search_tab.Height = main_window_height * 10;                                     // Set search tab results Width
        }


        public MainWindow()
        {
            InitializeComponent();
            
            darker_background backg = new darker_background();                               // Show Background window 
            backg.Show();

            textbox_search.Focus();                                                          // Click TextBox 
            ResizeWindow();                                                                  // Go to "ResizeWindow() Function" 
            Topmost = true;                                                                  // App always on top

            
            LoadConfiguration loadconfiguration = new LoadConfiguration();
            loadconfiguration.LoadConfigurationFiles();

            search_tab.Effect.();        
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void textbox_search_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textbox_search_GotFocus(object sender, RoutedEventArgs e)
        {
           

        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();                                                  // Close all windows (exit code=0)
        }
    }
}
