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
    public class ResetPasswordController : Controller
    {
        private readonly AppDbContext _context;

        public ResetPasswordController( AppDbContext context)
        {
            _context = context;
        }

        //Handles POST requests from upload page
        [HttpPost]
        [AllowAnonymous]
        [Route("verify")]
        public bool Verify(Reset reset)
        {
            Guid resetId = reset.ResetId;
            string email = "";
            string pswd = "";
            bool isReset = false;

            //Get all users from database
            var users = _context.Users.ToList();
            //Get all entries from resetTable in database
            var resets = _context.ResetTable.ToList();

            //loop through all resets in  the table
            foreach (var r in resets)
                if (r.ResetId == resetId)
                {
                    //set 'pswd' to new password and 'email' if reset id matches
                    email = r.Email;
                    pswd = r.NewPassword;
                }

            //loop through users in database
            foreach( var u in users)
                if(u.Email == email)
                {
                    //update password if corresponding email found
                    u.Password = pswd;
                    isReset = true;
                }
            _context.SaveChanges();

            return isReset;

        }
    }
}