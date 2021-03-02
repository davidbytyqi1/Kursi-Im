using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Users
{
    public class UserChangePasswordForFirstTimeModel
    {
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
