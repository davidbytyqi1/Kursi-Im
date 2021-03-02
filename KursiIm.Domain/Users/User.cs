using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.Users
{
    [Serializable]
    public partial class User : DeleteClass, IEntryEntity, IUpdateEntity
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string SaltedPassword { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IdUpdateUser { get; set; }
        public string UpdateUser { get; set; }
        public string SerialNumber { get; set; }
        public string RefreshToken { get; set; }
        public bool ChangePasswordNeeded { get; set; }
        public DateTime? LatestPasswordChangeDate { get; set; }
        public string EmailAddress { get; set; }
        public Guid? ResetPasswordToken { get; set; }
        public Guid? ConfirmationNumber { get; set; }
        public bool? WasConfirm { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public int IdentryUser { get; set; }
        public int IdEntryUser { get; set; }
        public string EntryUser { get; set; }
        public DateTime EntryDate { get; set; }
        public int? IduserDelete { get; set; }
        public string UserDelete { get; set; }
        public int IdRole { get; set; }
    }
}
