using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Tungnt.NET.WP8._1StoreApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void btnGetMessage_Click(object sender, RoutedEventArgs e)
        {
            string result = await WCFRESTServiceCall("GET", "GetMessage");
            var dialog = new MessageDialog(result);
            await dialog.ShowAsync();
        }

        private async void btnPostMessage_Click(object sender, RoutedEventArgs e)
        {
            string result = await WCFRESTServiceCall("POST", "PostMessage","\"Nguyen Thanh Tung\"");
            var dialog = new MessageDialog(result);
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Utility function to get/post WCFRESTService
        /// </summary>
        /// <param name="methodRequestType">RequestType:GET/POST</param>
        /// <param name="methodName">WCFREST Method Name To GET/POST</param>
        /// <param name="bodyParam">Parameter of POST Method (Need serialize to JSON before passed in)</param>
        /// <returns>Created by tungnt.net - 1/2015</returns>
        private async Task<string> WCFRESTServiceCall(string methodRequestType, string methodName, string bodyParam = "")
        {
            string ServiceURI = "http://localhost:34826/WCFRestDemo.svc/rest/" + methodName;
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(methodRequestType == "GET" ? HttpMethod.Get : HttpMethod.Post, ServiceURI);
            if (!string.IsNullOrEmpty(bodyParam))
            {
                request.Content = new StringContent(bodyParam, Encoding.UTF8, "application/json"); 
            }
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string returnString = await response.Content.ReadAsStringAsync();
            return returnString;
        }
    }
}
