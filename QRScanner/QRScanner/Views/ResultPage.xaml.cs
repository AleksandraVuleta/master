using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace QRScanner.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultPage : ContentPage
	{
		public ResultPage ()
		{
			InitializeComponent ();
		}

        private async void ZXingScannerView_OnOnScanResult(Result result)
        {
            zxing.IsAnalyzing = true;
          //  await DisplayAlert("Scanned Barcode", result.Text, "OK");
            await Navigation.PopAsync();
        }
        private void Overlay_OnFlashButtonClicked(Button sender, EventArgs e)
        {
            zxing.IsTorchOn = !zxing.IsTorchOn;
        }
    }
}