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

        public ObservableMessage(IMessageSummary message)
        {
            UniqueId = message.UniqueId;
            Date = message.Envelope.Date;
            Subject = message.Envelope.Subject;
            Body = null;
            HtmlBody = null;
            From = (MailboxAddress)message.Envelope.From[0];
            MailAddresses = new List<MailboxAddress>();
            IsRead = (message.Flags == MessageFlags.Seen);
        }

        public ObservableMessage(MimeMessage mimeMessage, MailKit.UniqueId uniqueId)
        {
            UniqueId = uniqueId; 
            Date = mimeMessage.Date;
            Subject = mimeMessage.Subject;
            Body = mimeMessage.Body.ToString();
            HtmlBody = mimeMessage.HtmlBody;
            From = (MailboxAddress)mimeMessage.From[0]; //?
            MailAddresses = new List<MailboxAddress>();
            //IsRead?
        }

        //public MimeMessage ToMime()
        //{

        //}

        //public Email GetForward()
        //{

        //}
    }
}
