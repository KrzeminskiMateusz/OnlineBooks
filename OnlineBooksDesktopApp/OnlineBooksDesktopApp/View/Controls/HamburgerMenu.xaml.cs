using OnlineBooksDesktopApp.View.Classes;
using OnlineBooksDesktopApp.View.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineBooksDesktopApp.View.Controls
{
    /// <summary>
    /// Interaction logic for HamburgerMenu.xaml
    /// </summary>
    public partial class HamburgerMenu : UserControl
    {
        public static event EventHandler<HamMenuArgs> OnHameMenuClick;

        public struct HamMenuArgs
        {
            public string HeaderText { get; set; }
        }

        public HamburgerMenu()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries.Add(LanguageHelper.GetLanguageDictionary());
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            OnHameMenuClick?.Invoke(this, new HamMenuArgs { HeaderText = HomeTextBlock.Text});
        }

        private void AuthorsButton_Click(object sender, RoutedEventArgs e)
        {
            OnHameMenuClick?.Invoke(this, new HamMenuArgs { HeaderText = AuthorsTextBlock.Text });
        }

        private void BooksName_Click(object sender, RoutedEventArgs e)
        {
            OnHameMenuClick?.Invoke(this, new HamMenuArgs { HeaderText = BooksTextBlock.Text });
        }

        private void SettingsName_Click(object sender, RoutedEventArgs e)
        {
            OnHameMenuClick?.Invoke(this, new HamMenuArgs { HeaderText = SettingsTextBlock.Text });
        }
    }
}
