using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyWindowsFromControlInWpfApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            Window mainWindow = new MainWindow();
            Frame rootFrame = new Frame();
            // Plugin
            Page page = new Page1();
            rootFrame.Navigate(page, null);
            mainWindow.Content = rootFrame;
            mainWindow.Show();
        }
    }
}
