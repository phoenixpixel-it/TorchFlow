using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

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
        private HwndSource _source;                                                                 // Set GlobalHotKey Source
        private const int HOTKEY_ID = 9000;                                                         // Set GlobalHotKey ID

        bool enter = false;                                                                         // if the user press enter
        const int search_tab_visible = 49;                                                          // Set search_tab on "Hidden"
        public int isopened;                                                                        // Create int "Is Opened", understand if the window is open or closed        
        UserSearchToolTip[] listtooltip = new UserSearchToolTip[0];                                 // custom control



        [DllImport("User32.dll")]                                                                   // Import user32.dll for Global Shortcuts
        private static extern bool RegisterHotKey(                                                  // Create RegisterHotKey for Global Shortcuts
            [In] IntPtr hWnd,
            [In] int id,
            [In] uint fsModifiers,
            [In] uint vk);

        [DllImport("User32.dll")]                                                                   // Import user32.dll for Global Shortcuts
        private static extern bool UnregisterHotKey(                                                // Create UnregisterHotKey for Global Shortcuts  
            [In] IntPtr hWnd,
            [In] int id);

        

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


            search_tab_border.Width = main_window_width;                                                   // Set search tab results Width
            search_tab_border.Height = 230;                                                                // Set search tab results Width

            search_tab_border.Visibility = Visibility.Hidden;
        }

        public void Extensions()                                                                    // Add & Install extensions function
        {
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
        }

        public void NotifyIcon()                                                                    // Add TorchFlow in application bar
        {
            System.Windows.Forms.NotifyIcon notifyicon = new System.Windows.Forms.NotifyIcon();     
            notifyicon.Icon = new System.Drawing.Icon("icon.ico");                                  // Load Icon
            System.Windows.Forms.ContextMenu notifyiconmenu = new System.Windows.Forms.ContextMenu();
            notifyiconmenu.MenuItems.Add("Exit", new EventHandler(Close));
            notifyiconmenu.MenuItems.Add("Open Finder", new EventHandler(OpenFinder));
            notifyiconmenu.MenuItems.Add("Open Dashboard", new EventHandler(OpenDashboard));
            notifyicon.ContextMenu = notifyiconmenu;
            notifyicon.Visible = true;                                                              // Show NotifyIcon
        }

        private void OpenFinder(object sender, EventArgs e)                                         // Open Finder in application bar
        {
            this.Visibility = Visibility.Visible;
            //TextBox Search
            backgtext = "Write here to search...";                                                  // Background text textbox_search
            textbox_search.Foreground = Brushes.Gray;                                               // Add Background color text
            textbox_search.Text = backgtext;                                                        // Add Background Text

        }

        private void OpenDashboard(object sender, EventArgs e)                                      // Open Dashboard in application bar
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private void Close(object sender, EventArgs e)                                              // Close TorchFlow in application bar
        {
            Application.Current.Shutdown();
        }

        public string backgtext { get; private set; }                                               // Search string value

        
        void AddSearchToolTip(string text, string pathimage)
        {
            search_tab.Children.Clear();
            if (text.Length > 0)
            {
                Array.Resize(ref listtooltip, listtooltip.Length + 1);
                int i = listtooltip.Length - 1;
                listtooltip[i] = new UserSearchToolTip();
                listtooltip[i].ContentLabel.Content = text;

                if (pathimage != "")
                    listtooltip[i].imagepath1.Source = new BitmapImage(new Uri(pathimage));

                search_tab_border.Height = search_tab_visible;
                search_tab.Children.Add(listtooltip[i]);
                if (listtooltip.Length > 0)
                    search_tab_border.Visibility = Visibility.Visible;
                else
                    search_tab_border.Visibility = Visibility.Hidden;
            }
            else
                search_tab_border.Visibility = Visibility.Hidden;

        }

        void RemoveAllSearchToolTip()
        {
            
            Array.Resize(ref listtooltip, 0);
            search_tab_border.Visibility = Visibility.Hidden;
            search_tab_border.Height = search_tab_visible;
            search_tab.Children.Clear();
        }
        
        public MainWindow()
        {
            isopened = 1;                                                                           // Set Isopened to true

            InitializeComponent();                                                                  // Load MainWindow()
            Extensions();                                                                           // Add & Install extensions function
            ResizeWindow();                                                                         // Go to "ResizeWindow() Function" 
            NotifyIcon();                                                                           // Load NotifyIcon                                                                 
            //TextBox Search
            backgtext = "Write here to search...";                                                  // Background text textbox_search
            textbox_search.Foreground = Brushes.Gray;                                               // Add Background color text
            textbox_search.Text = backgtext;                                                        // Add Background Text

            Commands.FixCommands();
            Commands.LoadCommands();
                       
        }

        protected override void OnSourceInitialized(EventArgs e)                                    // On Source Initialized | GlobalHotKeys
        {
            base.OnSourceInitialized(e);
            var helper = new WindowInteropHelper(this);
            _source = HwndSource.FromHwnd(helper.Handle);
            _source.AddHook(HwndHook);
            RegisterHotKey();
        }

        protected override void OnClosed(EventArgs e)                                               // On Closed | GlobalHotKeys
        {
            _source.RemoveHook(HwndHook);
            _source = null;
            UnregisterHotKey();
            base.OnClosed(e);
        }

        private void RegisterHotKey()                                                               // On RegisterHotKey | GlobalHotKeys
        {
            var helper = new WindowInteropHelper(this);
            const uint MOD_CONTROL = 0x0002;
            const uint VK_SPACE = 0x20;           
            if (!RegisterHotKey(helper.Handle, HOTKEY_ID, MOD_CONTROL, VK_SPACE))
            {
                
            }
        }

        private void UnregisterHotKey()                                                             // On UnregisterHotKey | GlobalHotKeys
        {
            var helper = new WindowInteropHelper(this);
            UnregisterHotKey(helper.Handle, HOTKEY_ID);
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case HOTKEY_ID:
                            OnHotKeyPressed();                                                      // It detects keys when the application is working in background.
                            handled = true;                            
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        private void OnHotKeyPressed()                                                              // When pressed a key
        {           
           if (isopened == 0)                                                                       // If the application is in background mode
           {                
                this.Visibility = Visibility.Visible;
                isopened = 1;
           }
   
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)                           
        {
            if (Keyboard.IsKeyDown(Key.Escape))                                                     // Keys ESC
            {
                isopened = 0;                                                                       // Set isopened to 0 (Hide application)               
                this.Visibility = Visibility.Hidden;                                                // Hide Application              
            }

            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)                // Is Alt key pressed
            {
                if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.Space))              // Keys ALT + F4
                {
                    isopened = 0;                                                                   // Set isopened to 0 (Hide application)                  
                    this.Visibility = Visibility.Hidden;                                            // Hide Application              
                }
            }

            if((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)                         // Is Alt key pressed
            {
                if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.F4))                  // Keys ALT + F4
                {
                    isopened = 0;                                                                   // Set isopened to 0 (Hide application)
                    this.Visibility = Visibility.Hidden;                                            // Hide Application              
                }
            }

            textbox_search.Foreground = Brushes.White;                                              // Set textbox color to white
            backgtext = "";                                                                         // Set background text to ""
            textbox_search.Focus();                                                                 // Click Textbox 
            
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
            notifyicon.Visible = false;                                                             // Hide notifyicon
            notifyicon.Icon = null;                                                                 // Hide notifyicon icon
            notifyicon.Dispose();                                                                   // Close notifyicon

            Application.Current.Shutdown(0);                                                        // Close all windows (exit code=0)
        }

        private void textbox_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            work();                                                                                 // generate the tootips
        }

        void work ()
        {
            Command output = new Command();
            output = Commands.analysis_input(Commands.CommandsList, textbox_search.Text);           // process the input

            string contenttext = "", contentimage = "";
                        
            switch (output.ID)                                                                      // search block by id
            {
                case "-1":                                                                          // search on google
                    output.Args = textbox_search.Text;                                              // required to avoid word-removal
                    if (output.Args.Length > 0)
                        contenttext = Commands.SearchOnGoogle(output, enter);                       // this block is called if the user does not enter an args
                    break;

                case "00":                                                                          // search on google
                                                                                                    // search on file explorer
                    break;

                case "01":                                                                          // search on google
                      contenttext = Commands.SearchOnGoogle(output, enter);
                    break;

                case "02":                                                                          // search on youtube
                    contenttext = Commands.SearchOnYoutube(output, enter);
                    break;

                case "03":                                                                          // search on youtube music
                    contenttext = Commands.SearchOnYoutubeMusic(output, enter);
                    break;

                case "04":                                                                          // search on maps
                    contenttext = Commands.SearchOnMaps(output, enter);
                    break;

                case "05":                                                                          // execute cmd
                    contenttext = Commands.WindowsCmd(output, enter);
                    break;

                case "06":                                                                          // execute cmd
                    contenttext = Commands.ProgramFirefox(output, enter);
                    break;

                case "07":
                    contenttext = Commands.ProgramChrome(output, enter);                        
                    break;

                default:                                                                            // something went wrong
                    break;
            }
            AddSearchToolTip(contenttext, contentimage);

            if (enter)
            {                                                                                       // if the user type enter 
                this.Hide();                                                                        // hide the form
                isopened = 0;
            }
            if (textbox_search.Text.Length == 0)
                RemoveAllSearchToolTip();
            
        }
        
        public void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))                                                      // On enter key pressed
            {
                enter = true;                                                                       // needed to start search
                work();                                                                             // 
                enter = false;                                                                      // disable the start to search
                textbox_search.Text = "";                                                           // clear text
                RemoveAllSearchToolTip();
            }
            
        }

        private void search_tab_border_Loaded(object sender, RoutedEventArgs e)
        {
            Command output = new Command();
            output = Commands.analysis_input(Commands.CommandsList, textbox_search.Text);           // process the input
        }
    }
}
