using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiEmail.Interfaces
{
    public interface IMailConfig
    {
        // Authentication
        string EmailAddress { get; set; }
        string Password { get; set; }

        // Receiving Service
        string ReceiveHost { get; set; }
        SecureSocketOptions ReceiveSocketOptions { get; set; }
        int ReceivePort { get; set; }

        // Sending Service
        string SendHost { get; set; }
        int SendPort { get; set; }
        SecureSocketOptions SendSocketOptions { get; set; }

        // OAuth 2.0 (optional)
        string OAuth2ClientId { get; set; }
        string OAuth2ClientSecret { get; set; }
        public string OAuth2RefreshToken { get; set; }
    }
}
