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
    public class JoinController : Controller
    {
        private readonly AppDbContext _context;

        public JoinController(AppDbContext context)
        {
            _context = context;
        }
       

        //Handles POST requests from Join page
        [HttpPost]
        [AllowAnonymous]
        [Route("postJoin")]
        public bool PostJoin( User user )
        {
            
            string email = user.Email;
            string password = user.Password;

            //Add new user to Database
            _context.Users.Add(
                new User
                {
                    UserId = Guid.NewGuid(),
                    Email = email,
                    Password = password
                });
            _context.SaveChanges();

            return true;
        }
    }
}