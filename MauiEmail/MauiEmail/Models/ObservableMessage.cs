//using CarPlay;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Remoting;
using MailKit;

namespace MauiEmail.Models
{
    public class ObservableMessage : INotifyPropertyChanged
    {
        public MailKit.UniqueId UniqueId { get; set; }
        public DateTimeOffset? Date { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string HtmlBody { get; set; }    
        public MailboxAddress From { get; set; }
        public List<MailboxAddress> MailAddresses { get; set; }
        public bool IsRead { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableMessage(MailKit.IMessageSummary message)
        {
            IsRead = (message.Flags == MessageFlags.Seen);
            From = (MailboxAddress)message.Envelope.From[0];
            Subject = message.Envelope.Subject;
            Date = message.Envelope.Date;
            Body = null;
            HtmlBody = null; 
        }

        public ObservableMessage(MimeMessage mimeMessage, MailKit.UniqueId uniqueId)
        {
            UniqueId = uniqueId; 
            Date = mimeMessage.Date;
            Subject = mimeMessage.Subject;
            Body = mimeMessage.Body.ToString();
            HtmlBody = mimeMessage.HtmlBody;
            //From = mimeMessage.From;
            //missing MailAddress list 
            //IsRead?
        }
    }
}
