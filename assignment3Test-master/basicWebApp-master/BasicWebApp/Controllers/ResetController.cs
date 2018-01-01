using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Antiforgery;
using BasicWebApp.Models;
using BasicWebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;


namespace BasicWebApp.Controllers
{
    [Route("[controller]")]
    public class ResetController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SendMail sendMail = new SendMail();

        public ResetController(AppDbContext context)
        {
            this._context = context;
        }

        //Handles POST requests from passwordreset page
        [HttpPost]
        [AllowAnonymous]
        [Route("postReset")]
        public bool PostReset(Reset reset)
        {
            if (ModelState.IsValid)
            {
                //create new reset id and reset link for the user
                Guid resetId = Guid.NewGuid();
                string link = "http://localhost:50000/verifypassword.html?resetid=" + resetId;

                //Add new reset entry to ResetTable in Database
                _context.ResetTable.Add(
                    new Reset
                    {
                        ResetId = resetId,
                        Email = reset.Email,
                        NewPassword = reset.NewPassword
                    });
                _context.SaveChanges();

                //send reset link to the requested email id
                //sendMail.sendEmail(reset.Email, "Instagram", link);

                return true;
            }
            return false;
        }
    }
}