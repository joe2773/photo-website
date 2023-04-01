namespace MyPhotoApp.Application.Dto{
    public class CommentDto {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PhotoId { get; set; }
        public string Text { get; set; }

        public DateTime DateCreated {get; set;}
    }
}