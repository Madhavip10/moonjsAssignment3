using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BasicWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BasicWebApp.Controllers
{
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController( AppDbContext context )
        {
            _context = context;
            
        }

        //Handles POST requests from Posts page
        [HttpPost]
        [AllowAnonymous]
        [Route("add")]
        public ActionResult Add()
        {
            //get all posts entries from Posts table in database
            var posts = _context.Posts.ToList();
            
            //return all posts as Json
            return Json(posts);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("incrLike")]
        public ActionResult IncrLike(PostModel post)
        {
            Guid postid = post.PostId;
            var posts = _context.Posts.ToList();

            foreach (var p in posts)
                if (p.PostId == postid)
                {
                    p.LikeCount++;
                }


            return Json(posts);
        }
    }
}
