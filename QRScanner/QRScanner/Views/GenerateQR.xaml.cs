using Plugin.Messaging;
using QRScanner.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace QRScanner.Views
{
	[XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class GenerateQR : ContentPage
	{
        ZXingBarcodeImageView barcode;

        public GenerateQR ()
		{
			InitializeComponent();
            firstLayout.IsVisible = false;
            secoundLayout.IsVisible = false;
        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            if (QRValue.Text == null || QRValue.Text == "")
            {
                DependencyService.Get<IToast>().Show("Enter value for the code!");
                return;
            }

            if (qr.Content == null)
            {
                Generate();
            }
            else
            {
                var action = await DisplayActionSheet("Generate new?", "NO", "YES", "Are you sure you want to generate new code?");
                if (action == "NO") {
                    return;
                }
                else
                {
                    qr = new QRResult();
                    Generate();
                    DependencyService.Get<IToast>().Show("New code generated!");
                } 
            }
        }
        public void Generate() {

            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
            };

            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 400;
            barcode.BarcodeOptions.Height = 400;
            barcode.BarcodeOptions.Margin = 1;
            barcode.BarcodeValue = QRValue.Text;

            qr.Content = barcode;
            firstLayout.IsVisible = true;
            secoundLayout.IsVisible = true;
        }

        private void SendEmail_Clicked(object sender, EventArgs e)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (EmailAddress.Text == "" || EmailAddress.Text == null)
                return;

            if (emailMessenger.CanSendEmail)
            {
                var email = new EmailMessageBuilder()
                  .To(EmailAddress.Text)
                  .Subject("QR Code to scan")
                  .Body("Hi. This is the QR code you need to scan!")
                  .Build();

                emailMessenger.SendEmail(email);
            }
        }
    }
}