using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KursiIm.Business;
using KursiIm.Domain.Administrations;
using KursiIm.SharedModel.Users;
using KursiImSource.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;

namespace KursiImSource.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
     //   private readonly IActiveDirectoryDomainService _adDomainService;
        private WebSettings _webSettings { get; }
        public UserController(IUserService userService, 
            //IActiveDirectoryDomainService adDomainService, 
            IOptions<WebSettings> webSettings)
        {
            _userService = userService;
          //  _adDomainService = adDomainService;
            _webSettings = webSettings.Value;
        }
        [HttpPost("create")]
        [SwaggerOperation(Summary = "Create User", Description = "Create User. User can be created from system or use Active Directory Account to create user. " +
            "<br/> IdUserAuthorizationType can be SystemAccount=1 or Active DirectoryAccount=2. " +
            "<br/> ResponseBody \"status\" can be Done=0, QueryError=6, AccountAlreadyExist=7 and ActiveDirectoryAccountNotExists=8")]
        [ProducesResponseType(typeof(Response<UserModel>), 200)]
        public async Task<IActionResult> Create([FromBody]CreateUserModel _) => Ok(await _userService.Create(_));

        [AllowAnonymous]
        [HttpGet("confirmAccount/{identifier}/{hash}")]
        [SwaggerOperation(Summary = "Confirm Account", Description = "This endpoint is used for automatic processes")]
        public IActionResult ConfirmAccount(Guid identifier, string hash)
        {
            if (_userService.ValidateAccountConfirmation(identifier, hash))
                return Redirect(_webSettings.SuccessConfirmationURL);
            else
                return Redirect(_webSettings.FailedConfirmationURL);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [SwaggerOperation(Summary = "Login to system", Description = "User have to be auhtorize in order to use most of the endpoints of this API. " +
            "<br/> ResponseBody \"status\" can be Done=0, ClientIdNotValid=1, ClientSecertNotValid=2 and ExpiredAccount=9")]
        [ProducesResponseType(typeof(Response<LoginResponse>), 200)]
        public IActionResult Login([FromBody]Credentials credentials) => Ok(_userService.VerifyLogInUser(credentials));

        [HttpGet("getUser/{id}")]
        [SwaggerOperation(Summary = "Get User", Description = "If you want to get user data for some reason this is the right endpoint." +
            "" +
            " Get user using his \"id\". " +
            "<br/> ResponseBody \"status\" can be Done=0")]
        [ProducesResponseType(typeof(Response<UserModel>), 200)]
        public IActionResult GetUser(int id) => Ok(_userService.GetUser(id));

        [HttpGet("getUsers")]
        [SwaggerOperation(Summary = "Get Users List", Description = "This is endpoint where you get the users list. " +
            "<br/> ResponseBody \"status\" can be Done=0")]
        [ProducesResponseType(typeof(Response<List<UserModel>>), 200)]
        public IActionResult GetUsers() => Ok(_userService.GetResponseUsers());

        [HttpPut("edit/{id}")]
        [SwaggerOperation(Summary = "Edit User", Description = "Change user data. If you change a user from ActiveDirectoryAccount to System Account then you shoud fill password field otherwise field shoud reamin null" +
            "<br/> ResponseBody \"status\" can be Done=0, and ModelIsNotValid=5")]
        [ProducesResponseType(typeof(Response<object>), 200)]
        public IActionResult Update(int id, [FromBody]EditUserModel _) => Ok(_userService.Update(id, _));
        [AllowAnonymous]
        [HttpPost("passwordReset")]
        [SwaggerOperation(Summary = "Password Reset", Description = "This is endpoint where we send an email to recovery user passowrd. " +
            "<br/> ResponseBody \"status\" can be EmailSentSuccessFully=17, EmailSentFailed=18")]
        [ProducesResponseType(typeof(Response<object>), 200)]
        public async Task<IActionResult> ResetPassword([FromBody]string email) => Ok(await _userService.SendForgotPasswordLinkEmail(email));
        [AllowAnonymous]
        [HttpPost("passwordResetChecker")]
        [SwaggerOperation(Summary = "Password Reset", Description = "This is endpoint where we check reset password link. " +
            "<br/> ResponseBody \"status\" can be EmailSentSuccessFully=17, EmailSentFailed=18")]
        [ProducesResponseType(typeof(Response<object>), 200)]
        public IActionResult ResetPasswordLinkCheck([FromBody]ResetPasswordLinkModel _) => Ok(_userService.CheckRestPasswordLink(_));
        [AllowAnonymous]
        [HttpPost("changePasswordWithResetPasswordLink")]
        [SwaggerOperation(Summary = "Password Reset", Description = "This is endpoint where we send an email to recovery user passowrd. " +
            "<br/> ResponseBody \"status\" can be EmailSentSuccessFully=17, EmailSentFailed=18")]
        [ProducesResponseType(typeof(Response<object>), 200)]
        public IActionResult ChangePasswordFromResetPassword([FromBody]ResetPasswordModel _) => Ok(_userService.ChangePasswordFromResetPasswordLink(_));
        [HttpPost("disableAllUsers")]
        [SwaggerOperation(Summary = "Disable All Users", Description = "This is the endpoint to deactive all user excpect current user. " +
            "<br/> ResponseBody \"status\" can be Done=0")]
        [ProducesResponseType(typeof(Response<object>), 200)]
        public IActionResult DisableAllUsers() => Ok(_userService.MakeAllUserPassiveButThis());

        [HttpPost("changePassword")]
        [SwaggerOperation(Summary = "Change Password", Description = "This is the endpoint to change user Password by himself. " +
            "<br/> ResponseBody \"status\" can be Done=0 and WrongOldPassword=11")]
        [ProducesResponseType(typeof(Response<object>), 200)]
        public IActionResult ChangePassword(UserChangePasswordModel _) => Ok(_userService.ChangePassword(_));
        [HttpPost("changePasswordForFirstTime")]
        [SwaggerOperation(Summary = "Change Password", Description = "This is the endpoint to change user Password by himself after first login. " +
            "<br/> ResponseBody \"status\" can be Done=0 and WrongOldPassword=11")]
        [ProducesResponseType(typeof(Response<object>), 200)]
        public IActionResult ChangePasswordForFirstTime(UserChangePasswordForFirstTimeModel _) => Ok(_userService.ChangePasswordForFirstTime(_));
        [HttpPost("changePasswordFromProfile")]
        [SwaggerOperation(Summary = "Change Password From Profile", Description = "This is the endpoint where user changes password from profile view." +
            "<br/> ResponseBody \"status\" can be Done=0 and WrongOldPassword=11")]
        [ProducesResponseType(typeof(Response<object>), 200)]
        public IActionResult ChangePasswordFromProfile([FromBody] string password) => Ok(_userService.ChangePasswordFromProfile(password));

    }
}