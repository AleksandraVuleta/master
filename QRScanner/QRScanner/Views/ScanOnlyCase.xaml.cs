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
	public partial class ScanOnlyCase : ContentPage
	{
		public ScanOnlyCase ()
		{
			InitializeComponent ();
		}

        private async void ScanQR_Clicked(object sender, EventArgs e)
        {

            try {

                var scanPage = new ZXingScannerPage();

                scanPage.OnScanResult += (result) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PushModalAsync(new MainPage(result.Text));
                    });
                };

                await Navigation.PushModalAsync(scanPage);

            } catch (Exception ex){

                throw ex;
            }
       
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}