using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Users
{
    public class AdminChangePasswordModel
    {
        public int IdUser { get; set; }
        public string NewPassword { get; set; }

    }
}
