using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasicWebApp.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections;
using JWT;
using JWT.Serializers;
using JWT.Algorithms;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using BasicWebApp.Services;
using Microsoft.Extensions.Logging;

namespace BasicWebApp.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHostingEnvironment env,
            IEmailSender emailSender,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return File(@"signin.htm", "text/html");
        }

        public class JsonCred
        {
            public string Username { get; set; }
            public string password { get; set; }
        }

        public class SigninResponse
        {
            public bool IsValid { get; set; }
            public string Message { get; set; }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<SigninResponse> Signin([FromBody] JsonCred jc)
        {
            SigninResponse sr = new SigninResponse
            {
                IsValid = false,
                Message = ""
            };

            Microsoft.AspNetCore.Identity.SignInResult result = new Microsoft.AspNetCore.Identity.SignInResult();
            try
            {
                result = await _signInManager.PasswordSignInAsync(jc.Username, jc.password, false, false);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                sr.IsValid = true;
                sr.Message = "Successful login";
            }
            else
            {
                _logger.LogInformation("Invalid login attempt");
                sr.Message = "Invalid login attempt.";
            }
            return sr;
        }
    }
}