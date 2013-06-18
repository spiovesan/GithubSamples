using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Controls;

namespace WpfBase
{
    public class NavigationService : INavigationService
    {
        private static NavigationService _Instance;
        private static Dictionary<Type, object> viewList = new Dictionary<Type, object>();
        public static Dictionary<string, Type> viewTypeList = new Dictionary<string, Type>();

        public static INavigationService Current
        {
            get
            {
                if (_Instance == null) _Instance = new NavigationService();
                return _Instance;
            }
        }

        public static Frame Frame { get; set; }       

        public static string ViewNamespace { get; set; }

        public void GoHome()
        {
            if (Frame != null)
            {
                while (Frame.CanGoBack) Frame.GoBack();
            }
        }

        public void GoBack()
        {
            if (Frame != null && Frame.CanGoBack) Frame.GoBack();
        }

        public void GoForward()
        {
            if (Frame != null && Frame.CanGoForward) Frame.GoForward();
        }

        public void Navigate(string pageName)
        {
            Navigate(pageName, null);
        }

        public void Navigate(string pageName, object parameter)
        {
            Type viewType = null;
            if (viewTypeList.ContainsKey(pageName))
                viewType = viewTypeList[pageName];

            if (viewType == null)
            {
                string viewTypeName;
                if (string.IsNullOrEmpty(ViewNamespace))
                    viewTypeName = String.Format("{0}.{1}", typeof(NavigationService).Namespace, pageName);
                else
                    viewTypeName = String.Format("{0}.{1}", ViewNamespace, pageName);
                viewType = Type.GetType(viewTypeName);
            }

            // Container
            object obj = null;
            if (viewType != null && Container != null)
            {
                obj = Container.Resolve(viewType);
            }
            else if (viewType != null)
            {
                
                if (viewList.ContainsKey(viewType))
                    obj = viewList[viewType];
                else
                {
                    obj = Activator.CreateInstance(viewType);
                    if (obj != null)
                        viewList.Add(viewType, obj);
                }
            }
            if (obj != null)
                Frame.Navigate(obj, parameter);
        }

        public bool CanGoBack
        {
            get { return Frame.CanGoBack; }
        }

        public bool CanGoForward
        {
            get { return Frame.CanGoForward; }
        }
    }
}
