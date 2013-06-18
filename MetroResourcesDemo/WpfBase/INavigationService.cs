﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfBase
{
    public interface INavigationService
    {
        void GoHome();
        void GoBack();
        void GoForward();
        void Navigate(string pageName);
        void Navigate(string pageName, object parameter);
        bool CanGoBack { get; }
        bool CanGoForward { get; }
    }
}
