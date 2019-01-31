using Plugin.Clipboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace QRScanner.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
			InitializeComponent ();
		}

        public StartPage(string result)
        {
            InitializeComponent();
            //if (result != null || result != "")
            //{
            //    ScanResult.IsVisible = true;
            //    CopyResult.IsVisible = true;
            //    OpenInBrowser.IsVisible = true;
            //    ScanResult.Text = result;
            //}
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

        //    CrossClipboard.Current.SetText(ScanResult.Text);
            string clipboardText = await CrossClipboard.Current.GetTextAsync();

            await DisplayAlert("Copy text", "'" + clipboardText + "'" + " copied", "CLOSE");
        }

        private void OpenInBrowser_Clicked(object sender, EventArgs e)
        {
            //Uri uri = new Uri(ScanResult.Text);
            //Device.OpenUri(uri);
        }

        private async void GenerateQR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Views.GenerateQR());
        }
    }
}