using System;

namespace MyPhotoApp.Domain.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PhotoId { get; set; }

        public User User { get; set; }
        public Photo Photo { get; set; }
    }
}
