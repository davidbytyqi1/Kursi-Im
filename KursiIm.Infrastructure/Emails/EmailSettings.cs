using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Infrastructure.Emails
{
    public class EmailSettings
    {
        public string Domain { get; set; }
        public int Port { get; set; }
        public string EamilUsername { get; set; }
        public string EmailPassword { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string CCEmail { get; set; }
        public string BCCEmail { get; set; }
        public string Subject { get; set; }
        public string EmailSignature { get; set; }

    }
}
