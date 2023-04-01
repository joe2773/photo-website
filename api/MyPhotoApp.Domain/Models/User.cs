using System;
using System.Collections.Generic;

namespace MyPhotoApp.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime DateCreated {get; set;}
    }
}
