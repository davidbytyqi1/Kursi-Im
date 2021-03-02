using KursiIm.Business;
using KursiIm.Domain.Users;
using KursiIm.SharedModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiImSource.Interfaces
{
    public interface IUserService
    {
        Task<Response<UserModel>> Create(CreateUserModel _);
        bool IsValidUser(string username, string password, bool isFromPortal);
        Response<LoginResponse> VerifyLogInUser(Credentials credentials);
        Response<UserModel> Update(int id, EditUserModel _);
        Task<Response<object>> SendForgotPasswordLinkEmail(string email);
        Response<ResetPasswordCheckerModel> CheckRestPasswordLink(ResetPasswordLinkModel _);
        Response<object> ChangePasswordFromResetPasswordLink(ResetPasswordModel _);
        Response<UserModel> GetUser(int id);
        Response<UserModel> GetResponseUsers();
        IEnumerable<UserModel> GetUsers();
        User GetUserByUsername(string username);
        User GetUserById(int id);
        Response<object> MakeAllUserPassiveButThis();
        string GetUserRefreshToken(string username);
        void SaveUserRefreshToken(string username, string newRefreshToken);
        Response<object> ChangePassword(UserChangePasswordModel _);
        Response<object> ChangePassword(AdminChangePasswordModel _);
        Response<object> ChangePasswordFromProfile(string password);
        Response<object> ChangePasswordForFirstTime(UserChangePasswordForFirstTimeModel _);
        bool ValidateAccountConfirmation(Guid confirmationNumber, string hash);
    }
}
