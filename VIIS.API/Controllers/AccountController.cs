using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using VIIS.API.Account.ViewModels;
using VIIS.API.Data;
using VIIS.API.GlobalModel;
using VIIS.API.JwtBearer.Models;
using VIIS.API.JwtBearer.ViewModels;
using VIIS.API.Services;
using VIIS.Domain.Data;
using VIIS.Domain.Global;

namespace VIIS.API.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = AuthSchemes.JwtScheme)]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IEmailSender emailSender, ILogger<AccountController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            this._userManager = userManager;
            this._emailSender = emailSender;
            _logger = logger;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] VIISChangePasswordModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (model.UserName != user.UserName)
            {
                var renameResult = await _userManager.SetUserNameAsync(user, model.UserName);
                if(!renameResult.Succeeded)
                {
                    AddErrors(renameResult);
                    return BadRequest();
                }
            }
            if (result.Succeeded) return Ok();

            AddErrors(result);
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] VIISRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return Ok();
                }
                AddErrors(result);
                return BadRequest(ModelState);
            }

            // If we got this far, something failed, redisplay form
            return BadRequest();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] JwtLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return Token(new ClaimList(model.UserName), model.UserName);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Unauthorized();
                }
            }

            // If we got this far, something failed, redisplay form
            return BadRequest();
        }

        private IActionResult Token(IEnumerable<Claim> claims, string username)
        {
            var key = new SymmetricSecurityKey(new Key().Bytes);
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(new Issuer().ToString(), new Audience().ToString(), claims, DateTime.Now, DateTime.Now.AddHours(1), cred);
            _logger.LogInformation("User logged in.");
            var refresh = new RefreshToken().Value();
            if (Helpers.UserNameRefreshToken.ContainsKey(username)) Helpers.UserNameRefreshToken[username] = refresh;
            else Helpers.UserNameRefreshToken.Add(username, refresh);
            return Ok(new { AccessToken = new JwtSecurityTokenHandler().WriteToken(token), RefreshToken = refresh });
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Refresh([FromBody] RefreshViewModel model)
        {
            var handler = new JwtSecurityTokenHandler();
            SecurityToken token;
            var principal = handler.ValidateToken(model.Token, new VITokenValidParameters(new Issuer(), new Audience(), new Key()), out token);
            var username = principal.Identity.Name;
            if (!(token is JwtSecurityToken) || !((JwtSecurityToken)token).Header.Alg.Equals(SecurityAlgorithms.HmacSha256) || Helpers.UserNameRefreshToken[username] != model.RefreshToken) return Unauthorized();
            else return Token(principal.Claims, username);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded) return Ok();

            AddErrors(result);
            return BadRequest();
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _userManager.Users.Select(appUser => new DBUser(appUser, _userManager)).ToArray();
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveUser([FromBody] User user)
        {
            // ?????? ??????? ?????? ????
            try
            {
                var currentUser = await _userManager.FindByEmailAsync(httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"|| c.Type == "Sub")?.Value);
                var appUser = await _userManager.FindByNameAsync(user.ToString());
                if (currentUser.Id == appUser.Id) return BadRequest(String.Format("{0} ????????? ? ???????", user));
                await new RemovableDBUser(user, _userManager).TransferAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }




        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
