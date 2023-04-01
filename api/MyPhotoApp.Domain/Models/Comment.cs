using System;

namespace MyPhotoApp.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PhotoId { get; set; }
        public string Text { get; set; }

        public User User { get; set; }
        public Photo Photo { get; set; }

        public DateTime DateCreated {get; set;}
    }
}
