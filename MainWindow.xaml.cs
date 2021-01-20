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

        [System.Runtime.InteropServices.DllImport("user32.dll")]                                    // Import user32.dll
        public static extern void SetWindowText(int hWnd, String text);
        public const int MOD_ALT = 0x12;                                                            // Alt key
        public const int VK_SPACE = 0x20;                                                           // Space key


        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public void ResizeWindow()
        {
            
            // ResizeWindow()
            int main_window_width = 820;                                                            // Resize Main Window Width

            
            border_search.Width = main_window_width;                                                //Resize MainWindow Width           
            int border_search_height = 60;
            border_search.Width = main_window_width;                                                // Resize SearchBar Width
            border_search.Height = border_search_height;                                            // Resize SearchBar Height


            double button_search_height = border_search_height / 2.40;                              // Resize Search Button Height
            double button_search_width = button_search_height;                                      // Resize Search Button Width
            search_button.Width = button_search_width;                                              // Resize Search Button Height            
            search_button.Height = button_search_height;                                            // Resize Search Button Width
            double button_search_margin_right = main_window_width / 1.12;                           // Resize Search Button margins
            search_button.Margin = new Thickness(0, 10, button_search_margin_right, 10);            // Resize Search Button margins


            search_tab.Width = main_window_width;                                                   // Set search tab results Width
            search_tab.Height = 230;                                                                // Set search tab results Width
            
        }

        public string backgtext { get; private set; }                                               //Search string value

        public MainWindow()
        {
                       

            System.Windows.Forms.NotifyIcon notifyicon = new System.Windows.Forms.NotifyIcon();     // Add TorchFlow in application bar
            notifyicon.Icon = new System.Drawing.Icon("icon.ico");                                  
            notifyicon.Visible = true;
            System.Windows.Forms.ContextMenu notifyiconmenu= new System.Windows.Forms.ContextMenu();
            notifyiconmenu.MenuItems.Add("Close", new EventHandler(Close));
            notifyiconmenu.MenuItems.Add("Open", new EventHandler(Open));
            notifyicon.ContextMenu = notifyiconmenu;
            
            InitializeComponent();                                                                  // Load MainWindow()


            ResizeWindow();                                                                         // Go to "ResizeWindow() Function" 
            Topmost = true;
            // App always on top

            backgtext = "Write here to search...";                                                  // Background text textbox_search
            textbox_search.Foreground = Brushes.Gray;                                               // Add Background color text
            textbox_search.Text = backgtext;                                                        // Add Background Text

            string[] args = null;


            if (Environment.GetCommandLineArgs().Count() > 1)
            {
                // true
                args = Environment.GetCommandLineArgs();

                if (System.IO.File.Exists(args[1]))
                {
                    // true
                    if (System.IO.Path.GetExtension(args[1]) == ".tfext")
                    {
                        // True


                        /*
                         * 
                         *  code to isntall extension
                         * 
                         */
                    }
                }
                else
                {
                    // false

                    /*
                     * 
                     *  code to do something with args
                     * 
                     */
                }

                

            }


            
            /*
            // Load Config
            LoadEvents LoadConfig = new LoadEvents();
            LoadConfig.LoadConfigFile(true);


            // Load Commands
            Config CommandsData = new Config();

            foreach (Config Find in LoadEvents.ConfigList)
            {
                // for each
                if (Find.GetType() == typeof(Config))
                {
                    // true
                    if (Find.Name == "COMMANDS")
                    {
                        // true
                        LoadEvents LoadCommands = new LoadEvents();
                        LoadCommands.CheckCommandsFile(Find.FolderName, Find.FileName, Convert.ToInt32(Find.MaxValue));
                        LoadCommands.LoadCommandsFile(Find.FolderName, Find.FileName, Convert.ToInt32(Find.MaxValue), true);
                    }
                }
            }


            // Load Settings


            /*
             * 
             * load settings??? 
             * 
             * 
             */
            /*
            darker_background backg = new darker_background();                                      // Show Background window 
            backg.Show();
            */
        }
        

        private void Open(object sender, EventArgs e)                                               // Open in application bar
        {
            MainWindow mainwin = new MainWindow();
            mainwin.Show();
        }
        private void Close(object sender, EventArgs e)                                              // Close TorchFlow
        {
            Application.Current.Shutdown();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)                           
        {
            textbox_search.Foreground = Brushes.White;                                              // Set textbox color to white
            backgtext = "";                                                                         // Set background text to ""
            textbox_search.Focus();                                                                 // Click Textbox
            if ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)                        // Is Alt key pressed
            {
                if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.Space))
                {
                    darker_background backg = new darker_background();
                    App.Current.MainWindow.Hide();
                    backg.Hide();
                }
            }

        }

        private void textbox_search_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textbox_search_GotFocus(object sender, RoutedEventArgs e)
        {
            textbox_search.Text = "";                                                               // Set Textbox_search to ""
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Window_Closing(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.NotifyIcon notifyicon = new System.Windows.Forms.NotifyIcon();
            Application.Current.Shutdown();                                                         // Close all windows (exit code=0)
            notifyicon.Visible = false;                                                             // Hide notifyicon
        }

        private void textbox_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            
            
        }


    }
}
