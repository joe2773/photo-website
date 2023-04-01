namespace MyPhotoApp.Application.Dto{
    public class PhotoDto {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public UserDto User { get; set; }
        public ICollection<LikeDto> Likes { get; set; }
        public ICollection<CommentDto> Comments { get; set; }

        public DateTime DateCreated {get; set;}
    }
}