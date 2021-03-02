using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Users
{
    public class UserChangePasswordModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
