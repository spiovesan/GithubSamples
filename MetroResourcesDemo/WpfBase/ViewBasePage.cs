using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Navigation;

namespace WpfBase
{
    public class ViewBasePage : LayoutAwarePage
    {
        private void OnLoadCompleted(object sender, NavigationEventArgs e)
        {
            var content = Content as FrameworkElement;
        }

        protected void LoadState(object navigationParameter, Dictionary<string, object> pageState)
        {
        }

        protected void SaveState(Dictionary<string, object> pageState)
        {
        }

        #region DataContextChanged handling
        // Workaround for no DataContextChanged event in WinRT
        // Set a binding for this dependency property to an empty binding and hook up a change callback handler
        // The change callback handler becomes the equivalent of a DataContextChanged event since the property will be set each time the DataContext changes
        public static readonly DependencyProperty DataContextChangedWatcherProperty =
            DependencyProperty.Register("DataContextChangedWatcher", typeof(object), typeof(ViewBasePage), 
            new PropertyMetadata(null, OnDataContextChanged));

        public object DataContextChangedWatcher
        {
            get { return (object)GetValue(DataContextChangedWatcherProperty); }
            set { SetValue(DataContextChangedWatcherProperty, value); }
        }

        private static void OnDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public ViewBasePage()
        { 
        }


        #endregion
    }
}
