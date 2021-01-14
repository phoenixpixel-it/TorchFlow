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
            InitializeComponent();
            
            darker_background backg = new darker_background();                               // Show Background window 
            backg.Show();

            Tab_results tabresults = new Tab_results();                                      // Show Tab Results
            tabresults.Show();

            textbox_search.Focus();
            ResizeWindow();                                                                  // Resize MainWindow at 
            Topmost = true;                                                                  // App always on top



            string[] args;

            if (Environment.GetCommandLineArgs().Count() > 1)
            {
                // true
                args = Environment.GetCommandLineArgs();


                if (System.IO.File.Exists(args[1]))
                { 
                    // true
                    if (System.IO.Path.GetExtension(args[1]) == ".tfext")
                    {
                        // true

                    }
                }
            }



            XmlDocument LoadConfig = new XmlDocument();

            try
            {
                // try
                LoadConfig.LoadXml(Properties.Resources.Config);


                /*
                 * 
                 *      carica cose dal config
                 *     che contiene info tipo percorsi e nomi di file
                 *     :)


                    ps. questo testo va rimosso in futuro ma non ora
                 * 
                 */
            }
            catch (Exception Ex)
            {
                // catch
                MessageBox.Show(Ex.Message);
            }
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

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            
        }
    }
}
