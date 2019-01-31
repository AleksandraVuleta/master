using Plugin.Clipboard;
using Plugin.Clipboard.Abstractions;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using QRScanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace QRScanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ScanResult.IsVisible = false;
            CopyResult.IsVisible = false;
            OpenInBrowser.IsVisible = false;
        }

        public MainPage(string result)
        {
            InitializeComponent();
            if (result != null || result != "") {
                ScanResult.IsVisible = true;
                CopyResult.IsVisible = true;
                OpenInBrowser.IsVisible = true;
                ScanResult.Text = result;
            }
        }
       
        private async void ScanQR_Clicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PushModalAsync(new MainPage(result.Text));
                });
            };

            await Navigation.PushModalAsync(scanPage);
        }

        private void ScanResult_Clicked(object sender, EventArgs e)
        {

        }

        private async void CopyResult_Clicked(object sender, EventArgs e)
        {

            CrossClipboard.Current.SetText(ScanResult.Text);
            string clipboardText = await CrossClipboard.Current.GetTextAsync();

            await DisplayAlert("Copy text", "'" + clipboardText+  "'" + " copied", "CLOSE");
        }

        private void OpenInBrowser_Clicked(object sender, EventArgs e)
        {
            Uri uri;
            bool result = Uri.TryCreate(ScanResult.Text, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
            if (result)
            {
                Device.OpenUri(uri);
            }
            else
            {
                Uri googleSearch = new Uri("http://www.google.com.au/search?q=" + ScanResult.Text);
                Device.OpenUri(googleSearch);
            }
        }

        private async void GenerateQR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.GenerateQR());
        }
    }
}

