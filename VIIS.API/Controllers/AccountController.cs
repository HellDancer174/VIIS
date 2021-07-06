using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using VIIS.API.Account.ViewModels;
using VIIS.API.Data;
using VIIS.API.JwtBearer.Models;
using VIIS.API.JwtBearer.ViewModels;
using VIIS.API.Services;

namespace VIIS.API.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IEmailSender emailSender, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            this._userManager = userManager;
            this._emailSender = emailSender;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToPage("/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
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
            return Created("", new { token = new JwtSecurityTokenHandler().WriteToken(token), exp = token.ValidTo, refresh });
        }

        [HttpPost]
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


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
