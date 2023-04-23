using MixedAssignment.Domain.Models.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedAssignment.Service.Mail
{
    public interface IMailServices
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
