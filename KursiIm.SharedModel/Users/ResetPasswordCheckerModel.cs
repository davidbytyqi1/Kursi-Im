using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Users
{
    public class ResetPasswordCheckerModel
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public string Hash { get; set; }

    }
}
