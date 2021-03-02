using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Domain.Administrations
{
    public class WebSettings
    {
        public string URL { get; set; }
        public string SuccessConfirmationURL { get; set; }
        public string FailedConfirmationURL { get; set; }
        public string PasswordResetURL { get; set; }

    }
}
