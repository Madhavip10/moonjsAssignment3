/* Web App - Assignment 2
 * 
 * Revision History
 *      Sharfaraz Ahamed,
 *      Anju Mathew,
 *      Madhavi Ben Patel,
 *      12/09/2017: Created
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

namespace BasicWebApp.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }


        //Handles POST requests from Login page
        [HttpPost]
        [AllowAnonymous]
        [Route("postLogin")]
        public bool PostLogin(User user)
        {
            bool isValid = false;
            string email = user.Email;
            string password = user.Password;

            //get all users from database
            var users = _context.Users.ToList();

            //loop through each users
            foreach(var usr in users)
            {
                if (usr.Email == email && usr.Password == password)
                    isValid = true;
            }

            //return true if email and passwords match
            return isValid;
        }

    }
}