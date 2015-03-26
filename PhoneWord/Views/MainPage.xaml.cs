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

        const long MAX_ALLOWED_NUMBER = 9999999999999999;

        private void ShowWordsList()
        {
            // TODO: Validate input
            try
            {
                // Test if the entered phone number is valid
                // can raise FormatException or OverflowException
                long num = Int64.Parse(PhoneNumberText.Text);
                if (num > MAX_ALLOWED_NUMBER)
                    throw new OverflowException();

                // Convert the phonenumber string to an char array
                char[] tDigits = PhoneNumberText.Text.ToCharArray();

                PhoneNumber phoneNumber = new PhoneNumber(tDigits);
                phoneNumber.FetchCharCombinations();

                WordsList.Clear();
                // Convert string to words
                for (int i = 0; i < phoneNumber.CharCombinations.Count; i++)
                    WordsList.Add(new WordString(phoneNumber.CharCombinations.ElementAt<string>(i)));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                string errMsg = "Oops..! We can not convert this.\n";
                if (ex is FormatException)
                    errMsg += "Please, consider entering a valid phone number\n";
                if (ex is OverflowException)
                    errMsg += "Check if the number you entered is not too long...\n";

                MessageBox.Show((errMsg));
            }

        }

        private void ClearWordsList()
        {
            WordsList.Clear();
        }

        private void PhoneNumberText_ActionIconTapped(object sender, EventArgs e)
        {
            ShowWordsList();

        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
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
            ClearWordsList();
            PhoneNumberText.Text = String.Empty;
        }

        private void AppBarSearch_Click(object sender, EventArgs e)
        {
            ShowWordsList();
        }

        private void PhoneNumberText_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClearWordsList();
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