using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using QRScanner.Controls;
using QRScanner.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace QRScanner.Droid.Renderers
{
#pragma warning disable CS0618 // Type or member is obsolete
    internal class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            CustomEntry entry = (CustomEntry)sender;
            entry.BorderColor = Color.IndianRed;

        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}