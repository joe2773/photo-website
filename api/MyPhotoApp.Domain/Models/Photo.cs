using System;
using System.Collections.Generic;

namespace MyPhotoApp.Domain.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }

        public User User { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime DateCreated {get; set;}
    }
}
