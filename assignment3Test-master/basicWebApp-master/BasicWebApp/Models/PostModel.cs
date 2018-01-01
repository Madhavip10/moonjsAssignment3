using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BasicWebApp.Models
{
    public class PostModel
    {
        [Key]
        public Guid PostId { get; set; }

        public Guid UserId { get; set; } //_id from the user table

        public string Image { get; set; } //url to image file

        public string Comment { get; set; } //poster's comment

        public int LikeCount { get; set; } //number of likes (convenience value)

        public int FeebbackCount { get; set; } //number of comments from others (convenience value)
    }
}
