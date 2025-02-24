//using EmailConsoleApp.Interfaces;
//using MailKit;
//using MailKit.Net.Imap;
//using MailKit.Net.Smtp;
//using MailKit.Search;
//using MimeKit;
//using Org.BouncyCastle.Asn1.X509;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace EmailConsoleApp.Classes
//{
//    public class EmailService : IEmailService
//    {
//        private IMailConfig _mailConfig; 
//        //private SmtpClient _smtpClient;
//        //private ImapClient _imapClient;

//        private IMailTransport _smtpClient;
//        private IMailStore _imapClient;

//        public EmailService(IMailConfig mailConfig)
//        {
//            _mailConfig = mailConfig;
//            _smtpClient = new SmtpClient();
//            _imapClient = new ImapClient();
//        }
//        //IMAP is used to retrieve/recieve messages, and SMTP is for sending data
//        public async Task DeleteMessageAsync(int uid)
//        {
//            try
//            {
//                var folder = _imapClient.Inbox;
//                await folder.OpenAsync(FolderAccess.ReadWrite);

//                //Validating that the UID is within a valid range
//                if (uid >= folder.Count())
//                { 
//                    Console.WriteLine("Error while deleting: invalid ID");
//                    return;
//                }

//                await folder.AddFlagsAsync(uid, MessageFlags.Deleted, true);
//                await folder.ExpungeAsync();
//                Console.WriteLine("Message was successfully deleted");
//            }
//            catch(Exception ex) 
//            {
//                throw new Exception($"Something went wrong while deleting an email: {ex.Message}");
//            }
//        }

//        public async Task DisconnectRetreiveClientAsync()
//        {
//            try
//            {
//                if (_imapClient.IsConnected) 
//                {
//                    await _imapClient.DisconnectAsync(true);
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Something went wrong while trying to disconnect the IMAP client: {ex.Message}");
//            }
//            Console.WriteLine("Disconnected from IMAP client.");
//        }

//        public async Task DisconnectSendClientAsync()
//        {
//            try
//            {
//                if(_smtpClient.IsConnected)
//                {
//                    await _smtpClient.DisconnectAsync(true);
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Something went wrong while trying to disconnect the SMTP client: {ex.Message}");
//            }
//            Console.WriteLine("Disconnected from SMTP client.");
//        }

//        public async Task<IEnumerable<MimeMessage>> DownloadAllEmailsAsync()
//        {
//            try
//            {
//                await StartRetreiveClientAsync();
//                var inbox = _imapClient.Inbox;
//                await inbox.OpenAsync(FolderAccess.ReadOnly);
//                List<MimeMessage> result = new List<MimeMessage>();

//                for (int i = 0; i < inbox.Count; i++)
//                {
//                    var message = await inbox.GetMessageAsync(i);
//                    result.Add(message);
//                }
//                Console.WriteLine("Emails were successfully downloaded.");
//                return result;
//            }
//            catch(Exception ex) 
//            {
//                throw new Exception($"Something went wrong while downloading mail inbox: {ex.Message}");
//            }
//        }

//        public async Task SendMessageAsync(MimeMessage message)
//        {
//            try
//            {
//                await StartSendClientAsync();
//                await _smtpClient.SendAsync(message);
//            }
//            catch (Exception ex) 
//            {
//                throw new Exception($"Something went wrong while sending the email: {ex.Message}");
//            }
//            Console.WriteLine("Message was succesfully sent.");
//        }

//        public async Task StartRetreiveClientAsync()
//        {
//            try
//            {
//                if(!_imapClient.IsConnected)
//                {
//                    await _imapClient.ConnectAsync(_mailConfig.ReceiveHost, _mailConfig.ReceivePort, _mailConfig.ReceiveSocketOptions);
//                }
//                if (!_imapClient.IsAuthenticated)   
//                {
//                    await _imapClient.AuthenticateAsync(_mailConfig.EmailAddress, _mailConfig.Password);
//                }
//                Console.WriteLine("Connected to IMAP client.");
//            }
//            catch(Exception ex) 
//            {
//                throw new Exception($"Something went wrong while connecting or authenticating: {ex.Message}");
//            }
//        }

//        public async Task StartSendClientAsync()
//        {
//            try
//            {
//                if (!_smtpClient.IsConnected)
//                {
//                    await _smtpClient.ConnectAsync(_mailConfig.SendHost, _mailConfig.SendPort, _mailConfig.SendSocketOptions);
//                }
//                if (!_imapClient.IsAuthenticated)
//                {
//                    await _smtpClient.AuthenticateAsync(_mailConfig.EmailAddress, _mailConfig.Password);
//                }
//                Console.WriteLine("Connected to SMTP client.");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception($"Something went wrong while connecting or authenticating: {ex.Message}");
//            }
//        }
//    }
//}
