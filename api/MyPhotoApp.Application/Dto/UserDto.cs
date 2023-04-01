namespace MyPhotoApp.Application.Dto{
    public class UserDto {

        public int id {get; set;}
        public string Username { get; set; }
        public string Email { get; set; }

        public ICollection<PhotoDto> Photos { get; set; }
        public ICollection<LikeDto> Likes { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public string PasswordHash { get; set; }

        public DateTime DateCreated {get; set;}
    }
}