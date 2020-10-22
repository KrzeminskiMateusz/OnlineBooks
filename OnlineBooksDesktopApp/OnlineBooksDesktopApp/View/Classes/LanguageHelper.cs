using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace OnlineBooksDesktopApp.View.Classes
{
    public static class LanguageHelper
    {
        public static ResourceDictionary GetLanguageDictionary()
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (System.Threading.Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "en-US":
                    dict.Source = new Uri(@"\Resources\Languages\DictionaryENG.xaml", UriKind.Relative);
                    return dict;
                case "pl-PL":
                    dict.Source = new Uri(@"\Resources\Languages\DictionaryPL.xaml", UriKind.Relative);
                    return dict;
                default:
                    dict.Source = new Uri(@"\Resources\Languages\DictionaryPL.xaml", UriKind.Relative);
                    return dict;
            }
        }
    }
}