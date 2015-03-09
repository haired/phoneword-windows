using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneWord.Resources;
using System.Collections.ObjectModel;

using PhoneWord.Utils;
using PhoneWord.Phone;

namespace PhoneWord.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        public ObservableCollection<WordString> WordsList;


        // Constructor
        public MainPage()
        {
            InitializeComponent();

            WordsList = new ObservableCollection<WordString>();
            WordListBox.ItemsSource = WordsList;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void ShowWordsList()
        {
            // TODO: Validate input

            // Convert the phonenumber string to an int array
            int[] tNumber = new int[PhoneNumberText.Text.Length];
            for (int i = 0; i < PhoneNumberText.Text.Length; i++)
                tNumber[i] = int.Parse(PhoneNumberText.Text.Substring(i,1));

            PhoneNumber phoneNumber = new PhoneNumber(tNumber);
            phoneNumber.FindStrings();

            WordsList.Clear();
            // Convert string to words
            for (int i = 0; i < phoneNumber.StringsList.Count; i++)
                WordsList.Add(new WordString(phoneNumber.StringsList.ElementAt<string>(i)));
            
        }

        private void PhoneNumberText_ActionIconTapped(object sender, EventArgs e)
        {
            ShowWordsList();

        }

        private void AppBarHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/HelpPage.xaml", UriKind.Relative));
        }

        private void AppBarSettings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/SettingsPage.xaml", UriKind.Relative));
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/AboutPage.xaml", UriKind.Relative));
        }

        private void AppBarClear_Click(object sender, EventArgs e)
        {

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}


        
    }
}