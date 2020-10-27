using OnlineBooksDesktopApp.View.Classes;
using OnlineBooksDesktopApp.View.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace OnlineBooksDesktopApp
{

    public partial class MainWindow : Window
    {
        public static event EventHandler<string> OnLanguageChanged;

        private Languages currentLanguage;
        enum Languages { PL, ENG };
        private string headerText;
        public string HeaderText
        {
            get { return headerText; }
            set
            {
                headerText = value;
                HeaderLabel.GetBindingExpression(Label.ContentProperty).UpdateTarget();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetLanguage();

            HeaderText = this.Resources["home"].ToString();

            HamburgerMenu.OnHameMenuClick += HamburgerMenu_OnHameMenuClick;
        }

        private void SetLanguage()
        {
            this.Resources.MergedDictionaries.Add(LanguageHelper.GetLanguageDictionary());

            foreach (var item in this.Resources.MergedDictionaries)
            {
                switch (Path.GetFileNameWithoutExtension(item.Source.ToString()))
                {
                    case "DictionaryPL":
                        currentLanguage = Languages.PL;
                        break;
                    case "DictionaryENG":
                        currentLanguage = Languages.ENG;
                        break;
                }
            }

            cmbItemPL.IsSelected = currentLanguage == Languages.PL;
            cmbItemENG.IsSelected = currentLanguage == Languages.ENG;
            HeaderText = this.Resources["home"].ToString();
        }

        private void HamburgerMenu_OnHameMenuClick(object sender, HamburgerMenu.HamMenuArgs e)
        {
            HeaderText = e.HeaderText;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(HamMenuGrid.GetValue(Grid.ColumnSpanProperty)) == 1)
            {
                HamMenuGrid.SetValue(Grid.ColumnSpanProperty, 2);
            }
            else
            {
                HamMenuGrid.SetValue(Grid.ColumnSpanProperty, 1);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbItemPL.IsSelected)
            {
                ChangeCurrentCulture("pl-PL");
                SetLanguage();

            }
            else if (cmbItemENG.IsSelected)
            {
                ChangeCurrentCulture("en-US");
                SetLanguage();

            }
        }

        private void ChangeCurrentCulture(string language)
        {
            this.Resources.MergedDictionaries.Remove(this.Resources.MergedDictionaries.Last());
            CultureInfo culturePL = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentCulture = culturePL;
            OnLanguageChanged?.Invoke(this, language);
        }
    }
}
