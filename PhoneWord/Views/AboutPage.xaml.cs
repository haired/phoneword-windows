using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace PhoneWord.Views
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();

            DataContext = this.DataContext;

            Assembly asm = Assembly.GetExecutingAssembly();
            _appTitle = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyTitleAttribute))).Title;

        }


        private string _appTitle;
        public string AppTitle 
        {
            get { return _appTitle; }
        }

        private void RateButton_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask rev = new MarketplaceReviewTask();
            rev.Show();
        }

    }
}