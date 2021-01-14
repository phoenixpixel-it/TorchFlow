﻿using System;
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
            
        }
    }
}
