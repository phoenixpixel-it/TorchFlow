using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void ResizeWindow()
        {
            int height = 60;                                                                 // Resize Main Window Height
            int width = 820;                                                                 // Resize Main Window Width
            this.Width = width;
            this.Height = height;

            int button_search_height = height / 2;                                           // Resize Search Button Height
            int button_search_width = height / 2;                                            // Resize Search Button Width
            double button_search_margin_right = width / 1.12;
            search_button.Width = button_search_width;
            search_button.Height = button_search_height;
            search_button.Margin = new Thickness(0, 10, button_search_margin_right, 10);     // Resize Search Button margins
        }


        public MainWindow()
        {
            var dark_background_window = new Window()                                        // Finder Dark background
            {
                Background = Brushes.Black,
                Opacity = 0.4,
                AllowsTransparency = true,
                WindowStyle = WindowStyle.None,
                WindowState = WindowState.Maximized,
                Topmost = false
            };
            
            dark_background_window.Show();
            
            InitializeComponent();
            textbox_search.Focus();

            textbox_search.Text = "Write here to search...";
            


            ResizeWindow();                                                                  // Resize MainWindow at 
            Topmost = true;                                                                  // App always on top
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

    }
}
