using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BasicWebApp.Models;
using BasicWebApp.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BasicWebApp.Controllers
{
    [Route("[controller]")]
    public class UploadController : Controller
    {
        private readonly RandomString rand = new RandomString();
        private readonly AppDbContext _context;

        public UploadController( AppDbContext context)
        {
            _context = context;
        }

        //Handles POST requests from upload button
        [HttpPost]
        [AllowAnonymous]
        [Route("post")]
        public  void Post(IFormFile files)
        {
            //get content type of te file and random name for file
            string type = files.ContentType;
            string fileName = rand.RandomName(8);
            string fileType;

            //switch type to set extension of the file
            switch (type)
            {
                case "image/png": fileType = "png";
                                  break;
                case "image/jpeg": fileType = "jpeg";
                                  break;
                default: fileType = " ";
                    break;
            }
            
            //create full path to save the file
            string image = "C:\\Users\\Sharfraz\\Documents\\Web Tech\\basicWebApp-master\\BasicWebApp\\wwwroot\\images\\" + fileName + "." + fileType;

            //create new stream file and copy the image
            var stream = new FileStream(image, FileMode.Create);
            files.CopyToAsync(stream);

            //Add new post to Posts table in database
            _context.Posts.Add(
                new PostModel
                {
                    PostId = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Image = "images\\" + fileName + "." + fileType,
                    Comment = fileName,
                    LikeCount = 1,
                    FeebbackCount = 2
                });
            _context.SaveChanges();

            //redirect to posts page
            Response.Redirect("http://localhost:50000/posts.html");

        }
    }


    

}