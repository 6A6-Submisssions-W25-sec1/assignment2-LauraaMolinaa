using MauiEmail.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiEmail.Interfaces
{
    public interface IEmailService
    {
        // Connection and authentication
        Task StartSendClientAsync();
        Task DisconnectSendClientAsync();
        Task StartRetreiveClientAsync();
        Task DisconnectRetreiveClientAsync();

        // Emailing functionality
        Task SendMessageAsync(MimeMessage message);
        Task<IEnumerable<ObservableMessage>> DownloadAllEmailsAsync();
        Task DeleteMessageAsync(int uid);

        Task<IEnumerable<ObservableMessage>?> FetchAllMessages();
    }
}
