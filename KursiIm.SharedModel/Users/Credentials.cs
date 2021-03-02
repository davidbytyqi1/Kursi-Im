using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Users
{
    public class Credentials
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public bool IsFromPortal { get; set; }
    }


    public class CredentialsValidator : AbstractValidator<Credentials>
    {
        public CredentialsValidator()
        {
            RuleFor(x => x.Account).Length(0, 150).NotEmpty();
            RuleFor(x => x.Password).Length(0, 150).NotEmpty(); //6
        }
    }
}
