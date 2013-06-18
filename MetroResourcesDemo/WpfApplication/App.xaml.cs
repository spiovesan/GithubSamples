using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;

namespace WpfApplication
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
            Page page = LoadPage();
            rootFrame.Navigate(page, null);
            mainWindow.Content = rootFrame;
            mainWindow.Show();
        }

        static public Page LoadDllMethod(string title_class, string title_void, string path, object[] parameters)
        {
            Page c = null;
            Assembly u = Assembly.LoadFile(path);
            Type t = u.GetType(title_class);
            if (t != null)
            {
                MethodInfo m = t.GetMethod(title_void);
                if (m != null)
                {
                    if (parameters.Length >= 1)
                    {
                        object[] myparam = new object[1];
                        myparam[0] = parameters;
                        m.Invoke(null, myparam);
                    }
                    else
                    {
                        c = (Page)m.Invoke(null, null);
                    }
                }
            }
            else
            {
                Exception ex = new Exception("method/class not found");
                throw ex;
            }

            return c;
        }

        public Page LoadPage()
        {
            // Carica
            Page page = null;
            object[] par = new object[] { };
            page = LoadDllMethod("WpfPlugin.PluginServiceFactory", "PluginService",
               @"D:\Lavori\GithubSamples\GithubSamples\MetroResourcesDemo\WpfPlugin\bin\Debug\WpfPlugin.dll", par);

            return page;
        }
    }
}
