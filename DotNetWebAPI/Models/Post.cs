﻿using System.ComponentModel.DataAnnotations;

namespace DotNetWebAPI.Models
{
    public class Post
    {
       public int Id { get; set; }
        [Required(ErrorMessage ="Please enter title")]
        public string Title { get; set; }
        [Required(ErrorMessage =("Please enter description"))]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
