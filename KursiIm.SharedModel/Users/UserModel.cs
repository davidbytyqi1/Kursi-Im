using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Users
{
    public class UserModel
    {
        public int ID { get; set; }
        public int IDUserAuthorizationType { get; set; }
        public int IDRole { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Account { get; set; }
        public string EmailAddress { get; set; }
        //public int IdOrganisation { get; set; }
        public int? IdEmployee { get; set; }
        public bool WithUserAuthorization { get; set; }
        public bool IsActive { get; set; }
        public string SerialNumber { get; set; }
        public string Role { get; set; }
        public DateTime? ExpireDate { get; set; }

    }


    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.ID).Null();
            RuleFor(x => x.First).Length(0, 150).NotEmpty();
            RuleFor(x => x.Last).Length(0, 150).NotEmpty();
            RuleFor(x => x.Account).Length(0, 50).NotEmpty();
        }
    }
}

