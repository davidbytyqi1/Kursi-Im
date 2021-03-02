using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KursiIm.Domain.Administrations
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailInfo emailInfo);

    }
}
