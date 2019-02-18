using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRScanner.Controls
{
    public partial class CustomEntry : Entry
    {
            
        //public CustomEntry()
        //{
        //    InitializeComponent();
        //}

        private Color _borderColor;

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }


        private int _borderWidth;
        public int BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; }
        }
        public static BindableProperty BorderColorProperty = BindableProperty.Create(
              propertyName: "BorderColor",
              returnType: typeof(string),
              declaringType: typeof(CustomEntry),
              defaultValue: "",
              defaultBindingMode: BindingMode.Default,
              propertyChanged: (b, o, n) => { ((CustomEntry)b).BorderColor = (Color)n; });

        public static BindableProperty BorderWidthProperty = BindableProperty.Create(
              propertyName: "BorderWidth",
              returnType: typeof(string),
              declaringType: typeof(CustomEntry),
              defaultValue: "",
              defaultBindingMode: BindingMode.Default,
              propertyChanged: (b, o, n) => { ((CustomEntry)b).BorderWidth = (int)n; });
        }
  
   
    public enum ReturnKeyTypes : int
    {
        Default,
        Go,
        Google,
        Join,
        Next,
        Route,
        Search,
        Send,
        Yahoo,
        Done,
        EmergencyCall,
        Continue
      
    }
}