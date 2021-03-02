using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Users
{
    public class CreateUserModel
    {
        public int IdRole { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Account { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string Password { get; set; }
        public bool WithUserAuthorization { get; set; }
        //  public int IdOrganisation { get; set; }
        public int? IdEmployee { get; set; }
        public string SerialNumber { get; set; }
    }

    public class CreateUserValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            //RuleFor(x => x.ID).Null();
            RuleFor(x => x.First).Length(3, 150).NotEmpty();
            RuleFor(x => x.Last).Length(3, 150).NotEmpty();
            RuleFor(x => x.Account).Length(0, 50).NotEmpty();
            RuleFor(x => x.EmailAddress).EmailAddress().Length(0, 150);
        }
    }
}
