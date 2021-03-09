using AutoMapper;
using KursiIm.Business;
using KursiIm.Domain.Administrations;
using KursiIm.Domain.KursiIm;
using KursiIm.Domain.Logs;
using KursiIm.Domain.Users;
using KursiIm.Infrastructure.JwtAuthentication.Abstractions;
using KursiIm.SharedModel.General;
using KursiIm.SharedModel.Users;
using KursiImSource.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KursiImSource.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepoService _repository;
        private readonly ILogService _logService;
        private readonly IGeneralUpdateService<User> _generalUpdateService;
        //private readonly IGeneralUpdateService<Hierarchy> _hierarchyAddUpdateService;

        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IEmailSender _emailSender;
        private readonly ISaveLog _saveLog;
        private readonly WebSettings _webSettings;
        private readonly ApiSettings _apiSettings;
        private readonly Token _token;

        public UserService(IUserRepoService repository,
                           ILogService logService,
                           IGeneralUpdateService<User> generalUpdateService,
                           IMapper mapper,
                           IHttpContextAccessor contextAccessor,
                           //IGeneralUpdateService<Hierarchy> hierarchyAddUpdateService,
                           IJwtTokenGenerator jwtTokenGenerator,
                           IEmailSender emailSender,
                           ISaveLog saveLog,
                           IOptions<WebSettings> webSettings,
                           IOptions<ApiSettings> apiSettings,
                           IOptions<Token> token
                      )
        {
            _repository = repository;
            _logService = logService;
            _generalUpdateService = generalUpdateService;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _jwtTokenGenerator = jwtTokenGenerator;
            _emailSender = emailSender;
            _saveLog = saveLog;
            _token = token.Value;
            _apiSettings = apiSettings.Value;
            _webSettings = webSettings.Value;

        }
        public async Task<Response<UserModel>> Create(CreateUserModel _)
        {
            try
            {
                var newUser = _repository.GetUserByUsername(_.Account);

                if (newUser != null)
                {
                    _saveLog.LogInformation("Account already exist! Account :" + _.Account);
                    return new Response<UserModel>(PublicResultStatusCodes.AccountAlreadyExists);
                }

                //if (_.IdUserAuthorizationType == (int)UserAuthorizationTypeIds.SystemAccount && !PasswordHelper.ValidatePassword(_.Password))
                //{
                //    _saveLog.LogInformation("Trying creating account but password break pattern. Account:" + _.Account);
                //    return new Response<UserModel>(PublicResultStatusCodes.ModelIsNotValid);
                //}

                var user = _mapper.Map<User>(_);
                HashNewUserPassword(ref user, _contextAccessor.HttpContext.User.Identity.Name);

                //if (user.IdActiveDirectoryDomain.HasValue && !DoesADUserExist(user.Account, user.IdActiveDirectoryDomain.Value))
                //{
                //    _saveLog.LogInformation("Account Do not exist in Active Directory with Id = \"" + _.IdActiveDirectoryDomain + "\" and with Account = \"" + _.Account + "\"");
                //    return new Response<UserModel>(PublicResultStatusCodes.ActiveDirectoryAccountNotExists);
                //}

                //if (!user.IdActiveDirectoryDomain.HasValue)
                    user.ChangePasswordNeeded = true;

                var serials = ConvertToBinaryHelper<User>.SerializeAndConvert(null, user);

                _generalUpdateService.InsertAddLogDataChange(user, serials.Item1, serials.Item2);
                //var list = new List<UserAuthorization>();
                var idEntry = int.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var entryUser = _contextAccessor.HttpContext.User?.Identity?.Name;
                //if (_.UserAuthorization != null)
                //    foreach (var item in _.UserAuthorization)
                //    {
                //        list.Add(new UserAuthorization()
                //        {
                //            IdModule = item.IdModule,
                //            IdRoleAuthorizationType = item.IdRoleAuthorizationType,
                //            IdUser = user.Id,
                //            EntryDate = DateTime.Now,
                //            IdEntryUser = idEntry,
                //            EntryUser = entryUser
                //        });
                //    }
                //_repository.AddRangeRoleAuthorization(list);

                //if (!string.IsNullOrWhiteSpace(user.SerialNumber))
                //{
                    //var deviceUser = new DeviceUsers()
                    //{
                    //    IdUser = user.Id,
                    //    IdDevice = _deviceRepository.GetDevices().FirstOrDefault().Id
                    //};
                    //_deviceRepository.AddDeviceUser(deviceUser);
                //}

                var body = "I/E nderuar, <br/>" +
                    "Nje llogari eshte krijuar me email-in tend. <br/>" +
                    "Ju mund te kyceni permes ktyre te dhenave:<br/>" +
                    "<b>Account:</b> " + _.Account + " <br/>" +
                    "<b>Password:</b> " + _.Password + " <br/>" +
                    "Klikoni ne kete {[vegez]} per te vazhduar.";

                var info = new EmailInfo
                {
                    Subject = $"Llogari e krijuar",
                    Body = body,
                    ToEmails = new List<string> { _.EmailAddress }
                };

                await _emailSender.SendEmailAsync(info);



                return new Response<UserModel>(PublicResultStatusCodes.Done, _mapper.Map<UserModel>(user));

            }
            catch (Exception) { return new Response<UserModel>(PublicResultStatusCodes.QueryHasError); }
        }

        public bool IsValidUser(string username, string password, bool isFromPortal)
        {
            var user = _repository.GetUserByUsername(username);

            if (user == null && !user.IsActive)
                return false;

            return HashHelper.Verify(user.SaltedPassword, user.Password, password);
        }

        public Response<LoginResponse> VerifyLogInUser(Credentials credentials)
        {
            var user =  _repository.GetUserByUsername(credentials.Account);

            var validUsername = false;

            if (user != null && user.IsActive)
                validUsername = true;


            if (validUsername)
            {
                if (user.ExpireDate.HasValue && user.ExpireDate.Value.Date < DateTime.Now.Date)
                {
                    _saveLog.LogInformation("No Login Access because Account has Expired, Account = \"" + credentials.Account + "\"");
                    return new Response<LoginResponse>(PublicResultStatusCodes.ExpiredAccount);
                }

                if (( IsValidUser(credentials.Account, credentials.Password, credentials.IsFromPortal)))
                {
                    _contextAccessor.HttpContext = IdentityHelper.SetIdentity(_contextAccessor.HttpContext, user);
                    var accessTokenResult = _jwtTokenGenerator.GenerateAccessTokenWithClaimsPrincipal(credentials.Account, AddMyClaims(user));
                 //   _logService.AddLogUserAuthorization((int)UserAuthorizationStatus.SignIn, credentials.IsFromPortal);

                  
                    //isChangePassword = user.ChangePasswordNeeded ? true : isChangePassword;

                  

                    var response = new LoginResponse
                    {
                        Id = user.Id,
                        Token = accessTokenResult.AccessToken,
                        RefreshToken = user.RefreshToken,
                        ValidTokenTimeInMinutes = _token.ValidTimeInMinutes,
                        ValidDateTimeToken = DateTime.Now.AddMinutes(_token.ValidTimeInMinutes),
                        FirstLast = user.First + " " + user.Last,
                        Username = user.Account,                
                        ChangePasswordNeeded = true
                    };

                    return new Response<LoginResponse>(PublicResultStatusCodes.Done, response);
                }
            }

            PublicResultStatusCodes status; string message;

            _logService.AddLogFailedAuthentication(credentials.Account);

            if (validUsername)
            {
                status = PublicResultStatusCodes.ClientSecertNotValid;
                message = "User Verification failed (SecretNotValid) --account:" + credentials.Account;
            }
            else
            {
                status = PublicResultStatusCodes.ClientIdNotValid;
                message = "User Verification failed (ClientIdNotValid) --accountProvided:" + credentials.Account;
            }
            _saveLog.LogInformation(message);
            return new Response<LoginResponse>(status);
        }

        public Response<UserModel> GetUser(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
                return new Response<UserModel>();
            var modelUser = _mapper.Map<UserModel>(user);
            return new Response<UserModel>(PublicResultStatusCodes.Done, modelUser);
        }

        public User GetUserByUsername(string username) => _repository.GetUserByUsername(username);
        public User GetUserById(int id) => _repository.GetUserById(id);

        private void HashNewUserPassword(ref User user, string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var currentUser = _repository.GetUserByUsername(username);
                user.IdentryUser = currentUser.IdentryUser;
                user.EntryUser = currentUser.Account;
            }
            user.EntryDate = DateTime.Now;
            user.IsActive = true;
            user.RefreshToken = RefreshTokenHelper.GenerateRefreshToken();
            user.Password = string.IsNullOrWhiteSpace(user.Password) ? user.Password : "";
            var hashHelper = new HashHelper(user.Password);
            user.Password = hashHelper.Hash;
            user.SaltedPassword = hashHelper.Salt;
            user.LatestPasswordChangeDate = DateTime.Now;
        }

        public Response<UserModel> Update(int id, EditUserModel _)
        {
            var entryUser = _repository.GetUserByUsername(_contextAccessor.HttpContext.User?.Identity?.Name);

            var user = _repository.GetUserById(id);
            if (user == null)
            {
                _saveLog.LogInformation("Failed to Update User because user with Id=\"" + id + "\" does not exist");
                return new Response<UserModel>(PublicResultStatusCodes.ModelIsNotValid);
            }

            var beforeUser = CloneObject.Clone(user);
                if (!string.IsNullOrWhiteSpace(_.Password))
                {
                    var hashHelper = new HashHelper(_.Password);
                    user.Password = hashHelper.Hash;
                    user.SaltedPassword = hashHelper.Salt;
                    user.LatestPasswordChangeDate = DateTime.Now;
                }

            user.Account = _.Account;
            user.First = _.First;
            user.Last = _.Last;
            user.IsActive = _.IsActive;
            user.ExpireDate = _.ExprieDate;
            user.Idrole = _.IdRole;
            user.EmailAddress = _.EmailAddress;
            user.IduserAuthorizationType = _.IdUserAuthorizationType;
            //user.WithUserAuthorization = _.WithUserAuthorization;
           // user.SerialNumber = _.SerialNumber;
            //user.IdEmployee = _.IdEmployee;
            EntryUpdateUserHelper.FillUpdateData(ref user);


            var serials = ConvertToBinaryHelper<User>.SerializeAndConvert(beforeUser, user);

            _generalUpdateService.UpdateAddLogDataChange(user, serials.Item1, serials.Item2);

            return new Response<UserModel>(PublicResultStatusCodes.Done);
        }

        public async Task<Response<object>> SendForgotPasswordLinkEmail(string email)
        {
            var user = _repository.GetUserByEmail(email);
          //  if (user != null && user.IdUserAuthorizationType != (int)UserAuthorizationTypeIds.ActiveDirectoryAccount)
           // {
                try
                {
                    user.ResetPasswordToken = Guid.NewGuid();
                    _repository.UpdateUser(user);
                }
                catch (Exception ex)
                {
                    return new Response<object>(PublicResultStatusCodes.EmailSentFailed);
                }
                var hash = HashHelper.GetSha256FromString(user.Id + " " + user.Account);

            //    var bodyHTML = _settingsDictonaryService.GetDictonariesByKeyAndGroup("PasswordResetEmail", 2).FirstOrDefault().ValueSq;
                var url = _contextAccessor.HttpContext.Request.Headers["sender-url"];

                var body = Regex.Unescape("").Replace("{[     ]}", "Human Resource Management").Replace("{[PasswordResetLink]}", url + _webSettings.PasswordResetURL + user.ResetPasswordToken.ToString() + "/" + hash);

                var info = new EmailInfo
                {
                    Subject = $"Kërkesë për ndryshim fjalëkalimi",
                    Body = body,
                    ToEmails = new List<string> { email }
                };

                try
                {
                    await _emailSender.SendEmailAsync(info);
                }
                catch (Exception ex)
                {
                    return new Response<object>(PublicResultStatusCodes.EmailSentFailed);
                }

                return new Response<object>(PublicResultStatusCodes.EmailSentSuccessfully);
           // }
            //fake return
            return new Response<object>(PublicResultStatusCodes.EmailSentSuccessfully);
        }

        public Response<ResetPasswordCheckerModel> CheckRestPasswordLink(ResetPasswordLinkModel _)
        {
            var user = _repository.GetUsersWithCriteria(u => u.ResetPasswordToken == _.Identifier).FirstOrDefault();
            if (user != null)
            {
                var hash = HashHelper.GetSha256FromString(user.Id + " " + user.Account);

                if (!hash.Equals(_.Hash))
                    return new Response<ResetPasswordCheckerModel>(PublicResultStatusCodes.Done, new ResetPasswordCheckerModel());

                var result = new ResetPasswordCheckerModel();
                result.IsValid = true;
                result.Id = user.Id;

                var returnHash = HashHelper.GetSha256FromString(user.Account + " " + user.Id + "$aa$" + user.EntryDate);
                result.Hash = returnHash;

                return new Response<ResetPasswordCheckerModel>(PublicResultStatusCodes.Done, result);
            }
            return new Response<ResetPasswordCheckerModel>(PublicResultStatusCodes.Done, new ResetPasswordCheckerModel());
        }

        public Response<object> ChangePasswordFromResetPasswordLink(ResetPasswordModel _)
        {
            var user = _repository.GetUserById(_.Id);
            var userBefore = CloneObject.Clone(user);
            //EntryUpdateUserHelper.FillUpdateData(ref user);

            if (user != null)
            {
                var hash = HashHelper.GetSha256FromString(user.Account + " " + user.Id + "$aa$" + user.EntryDate);
                if (!hash.Equals(_.Hash))
                    return new Response<object>(PublicResultStatusCodes.ModelIsNotValid);

                var hashHelper = new HashHelper(_.Password);
                user.Password = hashHelper.Hash;
                user.SaltedPassword = hashHelper.Salt;
                user.LatestPasswordChangeDate = DateTime.Now;
                user.ResetPasswordToken = Guid.NewGuid();

                var serials = ConvertToBinaryHelper<User>.SerializeAndConvert(userBefore, user);

                _generalUpdateService.UpdateAddLogDataChange(user, serials.Item1, serials.Item2);

                return new Response<object>(PublicResultStatusCodes.Done);
            }

            return new Response<object>(PublicResultStatusCodes.ModelIsNotValid);
        }
        public Response<object> ChangePassword(UserChangePasswordModel _)
        {
            var user = _repository.GetUserByUsername(_contextAccessor.HttpContext.User.Identity.Name);
            var userBefore = CloneObject.Clone(user);

            //if (user.IdUserAuthorizationType != (int)UserAuthorizationTypeIds.SystemAccount)
            //{
            //    _saveLog.LogInformation("User with Active Directory cannot change password from this system!");
            //    return new Response<object>(PublicResultStatusCodes.NotAllowedOperation);
            //}

            var checkPassword = HashHelper.Verify(user.SaltedPassword, user.Password, _.OldPassword);

            if (checkPassword)
            {
                var hashHelper = new HashHelper(_.NewPassword);
                user.Password = hashHelper.Hash;
                user.SaltedPassword = hashHelper.Salt;
                user.LatestPasswordChangeDate = DateTime.Now;

                var serials = ConvertToBinaryHelper<User>.SerializeAndConvert(userBefore, user);

                _generalUpdateService.UpdateAddLogDataChange(user, serials.Item1, serials.Item2);

                return new Response<object>(PublicResultStatusCodes.Done);
            }
            _saveLog.LogInformation("Password do not match with data in Database!");
            return new Response<object>(PublicResultStatusCodes.WrongOldPassword);
        }

        public Response<object> ChangePasswordForFirstTime(UserChangePasswordForFirstTimeModel _)
        {
            var user = _repository.GetUserByUsername(_contextAccessor.HttpContext.User.Identity.Name);
            var userBefore = CloneObject.Clone(user);

            //if (user.IdUserAuthorizationType != (int)UserAuthorizationTypeIds.SystemAccount)
            //{
            //    _saveLog.LogInformation("User with Active Directory cannot change password from this system!");
            //    return new Response<object>(PublicResultStatusCodes.NotAllowedOperation);
            //}

            var checkPassword = PasswordHelper.ValidatePassword(_.NewPassword);

            if (checkPassword)
            {
                var hashHelper = new HashHelper(_.NewPassword);
                user.Password = hashHelper.Hash;
                user.SaltedPassword = hashHelper.Salt;
                user.LatestPasswordChangeDate = DateTime.Now;
                user.ChangePasswordNeeded = false;

                var serials = ConvertToBinaryHelper<User>.SerializeAndConvert(userBefore, user);

                _generalUpdateService.UpdateAddLogDataChange(user, serials.Item1, serials.Item2);

                return new Response<object>(PublicResultStatusCodes.Done);
            }
            _saveLog.LogInformation("Password must have at least six characters, one upperCase and one number!");
            return new Response<object>(PublicResultStatusCodes.ModelIsNotValid);
        }

        public Response<object> ChangePassword(AdminChangePasswordModel _)
        {
            var user = _repository.GetUserById(_.IdUser);
            var userBefore = CloneObject.Clone(user);

            //if (user.IdUserAuthorizationType != (int)UserAuthorizationTypeIds.SystemAccount)
            //{
            //    _saveLog.LogInformation("User with Active Directory cannot change password from this system!");
            //    return new Response<object>(PublicResultStatusCodes.NotAllowedOperation);
            //}
            var hashHelper = new HashHelper(_.NewPassword);
            user.Password = hashHelper.Hash;
            user.SaltedPassword = hashHelper.Salt;
            user.LatestPasswordChangeDate = DateTime.Now;

            var serials = ConvertToBinaryHelper<User>.SerializeAndConvert(userBefore, user);

            _generalUpdateService.UpdateAddLogDataChange(user, serials.Item1, serials.Item2);

            return new Response<object>(PublicResultStatusCodes.Done);
        }

        public Response<object> ChangePasswordFromProfile(string password)
        {
            var userId = int.Parse(NetworkHelper._contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _repository.GetUserById(userId);

            var userBefore = CloneObject.Clone(user);

            //if (user.IdUserAuthorizationType != (int)UserAuthorizationTypeIds.SystemAccount)
            //{
            //    _saveLog.LogInformation("User with Active Directory cannot change password from this system!");
            //    return new Response<object>(PublicResultStatusCodes.NotAllowedOperation);
            //}

            var hashHelper = new HashHelper(password);
            user.Password = hashHelper.Hash;
            user.SaltedPassword = hashHelper.Salt;
            user.LatestPasswordChangeDate = DateTime.Now;

            var serials = ConvertToBinaryHelper<User>.SerializeAndConvert(userBefore, user);

            _generalUpdateService.UpdateAddLogDataChange(user, serials.Item1, serials.Item2);

            return new Response<object>(PublicResultStatusCodes.Done);
        }

        public Response<UserModel> GetResponseUsers() => new Response<UserModel>(PublicResultStatusCodes.Done, GetUsers().ToList());



        public IEnumerable<UserModel> GetUsers()
        {
            return _mapper.Map<IList<UserModel>>(_repository.GetUsers());
        }

        public Response<object> MakeAllUserPassiveButThis()
        {
            var currentUserID = int.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var users = _repository.GetUsersWithCriteria(_ => _.Id != currentUserID);
            foreach (var user in users)
            {
                user.IsActive = false;
                _repository.UpdateUser(user);
            }

            return new Response<object>(PublicResultStatusCodes.Done);
        }
        public string GetUserRefreshToken(string username) => _repository.GetUserByUsername(username).RefreshToken;

        public void SaveUserRefreshToken(string username, string newRefreshToken)
        {
            var user = _repository.GetUserByUsername(username);
            user.RefreshToken = newRefreshToken;

            _repository.UpdateUser(user);
        }



        public bool ValidateAccountConfirmation(Guid confirmationNumber, string hash)
        {
            var user = _repository.GetUsersWithCriteria(_ => _.ConfirmationNumber == confirmationNumber && !_.WasConfirm.Value && !_.IsDeleted).FirstOrDefault();

            if (user == null)
                return false;

            var unhashed = user.Id + " " + user.Account;

            var hashDb = HashHelper.GetSha256FromString(unhashed);

            if (!hashDb.Equals(hash))
                return false;

            user.IsActive = true;
            user.WasConfirm = true;
            user.ConfirmationNumber = null;
            user.ConfirmationDate = DateTime.Now;

            _repository.UpdateUser(user);
            return true;
        }

        private static IEnumerable<Claim> AddMyClaims(User user)
        {
            var myClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.First),
                new Claim(ClaimTypes.Surname, user.Last),
            };

            return myClaims;
        }


    }
}
