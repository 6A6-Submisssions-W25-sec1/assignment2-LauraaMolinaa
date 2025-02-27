using EmailConsoleApp.Classes;
using MailKit.Security;
using MauiEmail.Interfaces;
using MauiEmail.Models;

namespace MauiEmail
{
    public partial class App : Application
    {
        public static MailConfig _mailConfig = new MailConfig()
        {
            EmailAddress = "laura.appdev3@gmail.com",
            Password = "fltuzvtcslduhduo",
            ReceiveHost = "imap.gmail.com",
            ReceivePort = 993,
            ReceiveSocketOptions = SecureSocketOptions.SslOnConnect,
            SendHost = "smtp.gmail.com",
            SendPort = 465,
            SendSocketOptions = SecureSocketOptions.SslOnConnect,
        }; 

        public static EmailService _emailService = new EmailService(_mailConfig); 
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
