using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Users
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string FirstLast { get; set; }
        public string Username { get; set; }
        public int ValidTokenTimeInMinutes { get; set; }
        public DateTime ValidDateTimeToken { get; set; }
        public bool WithUserAuthorization { get; set; }
        public bool ChangePasswordNeeded { get; set; }
        public int? IdEmployee { get; set; }
        public string Gender { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}
