using System;
using System.Collections.Generic;
using System.Text;

namespace QRScanner.Services
{
    public interface IToast
    {
        void Show(string message);
    }
}
