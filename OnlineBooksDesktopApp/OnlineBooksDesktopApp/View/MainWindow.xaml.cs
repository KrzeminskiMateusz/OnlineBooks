using OnlineBooksDesktopApp.View.Classes;
using OnlineBooksDesktopApp.View.Controls;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineBooksDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            this.Resources.MergedDictionaries.Add(LanguageHelper.GetLanguageDictionary());
            HeaderText = this.Resources["home"].ToString();

            HamburgerMenu.OnHameMenuClick += HamburgerMenu_OnHameMenuClick;
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
    }
}
