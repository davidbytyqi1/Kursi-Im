using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Domain.Administrations
{
    public class EmailInfo
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public IList<string> ToEmails { get; set; }
        public IList<string> CCEmails { get; set; }
        public bool HasAttach { get; set; }
        public IList<byte[]> Attachments { get; set; }
        public string AttachContentType { get; set; }

    }
}
