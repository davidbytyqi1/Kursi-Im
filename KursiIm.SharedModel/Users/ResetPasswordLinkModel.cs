using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Users
{
    public class ResetPasswordLinkModel
    {
        public Guid Identifier { get; set; }
        public string Hash { get; set; }
    }
}
