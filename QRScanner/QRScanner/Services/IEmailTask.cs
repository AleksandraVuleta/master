using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace QRScanner.Services
{
    public interface IEmailTask
    {
        bool CanSendEmail { get; }
        bool CanSendEmailAttachments { get; }
        bool CanSendEmailBodyAsHtml { get; }
        void SendEmail(IEmailMessage email);
        void SendEmail(string to, string subject, string message);
    }
}
