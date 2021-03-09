using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Users
{
    public class EditUserModel
    {
        public int IdRole { get; set; }
        public string Account { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ExprieDate { get; set; }
        public bool HasExpire { get; set; }
        public int IdUserAuthorizationType { get; set; }
        // public int IdOrganisation { get; set; }
    }

    public class EditUserValidator : AbstractValidator<EditUserModel>
    {
        public EditUserValidator()
        {
            //RuleFor(x => x.ID).Null();
            RuleFor(x => x.First).Length(0, 150).NotEmpty();
            RuleFor(x => x.Last).Length(0, 150).NotEmpty();
            RuleFor(x => x.Account).Length(0, 50).NotEmpty();
            RuleFor(x => x.EmailAddress).Length(0, 50).NotEmpty();
            //RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.IdRole).GreaterThan(0);

        }
    }
}
