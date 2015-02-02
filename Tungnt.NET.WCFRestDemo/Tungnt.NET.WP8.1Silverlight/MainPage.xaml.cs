using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Tungnt.NET.WP8._1Silverlight.Resources;
using Tungnt.NET.WP8._1Silverlight.WCFDemo;

namespace Tungnt.NET.WP8._1Silverlight
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnGetMessage_Click(object sender, RoutedEventArgs e)
        {
            WCFRestDemoClient client = new WCFRestDemoClient();
            client.GetMessageCompleted += client_GetMessageCompleted;
            client.GetMessageAsync();
        }

        void client_GetMessageCompleted(object sender, GetMessageCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show(e.Result);
            }
        }

        private void btnPostMessage_Click(object sender, RoutedEventArgs e)
        {
            WCFRestDemoClient client = new WCFRestDemoClient();
            client.PostMessageCompleted += client_PostMessageCompleted;
            client.PostMessageAsync("Nguyen Thanh Tung");
        }

        void client_PostMessageCompleted(object sender, PostMessageCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show(e.Result);
            }
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