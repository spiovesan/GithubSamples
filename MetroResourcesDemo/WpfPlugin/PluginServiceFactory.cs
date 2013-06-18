using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Diagnostics;

namespace WpfPlugin
{
    public class PluginServiceFactory
    {
        static public Page PluginService()
        {
            Debug.WriteLine("PluginServiceFactory::PluginService");
            return new MainPageView();
        }
    }
}
