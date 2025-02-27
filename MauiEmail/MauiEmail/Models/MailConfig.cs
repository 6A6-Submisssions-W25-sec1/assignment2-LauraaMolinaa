using MailKit.Security;
using MauiEmail.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiEmail.Models
{
    public class MailConfig : IMailConfig
    {
        public MailConfig()
        {

        }

        // Authentication
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        // Receiving Service
        public string ReceiveHost { get; set; }
        public SecureSocketOptions ReceiveSocketOptions { get; set; }
        public int ReceivePort { get; set; }

        // Sending Service
        public string SendHost { get; set; }
        public int SendPort { get; set; }
        public SecureSocketOptions SendSocketOptions { get; set; }

        // OAuth 2.0 (optional)
        public string OAuth2ClientId { get; set; }
        public string OAuth2ClientSecret { get; set; }
        public string OAuth2RefreshToken { get; set; }

    }
}
