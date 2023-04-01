using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Application.Dto;
using MyPhotoApp.Infrastructure.Repositories;

namespace MyPhotoApp.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentService(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentDto> GetCommentByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                throw new ArgumentException($"Comment with id {id} not found");
            }

            // map the Comment entity to CommentDto
            return new CommentDto
            {
                Id = comment.Id,
                Text = comment.Text,
                UserId = comment.UserId,
                PhotoId = comment.PhotoId,
                DateCreated = comment.DateCreated
            };
        }

        public async Task<IEnumerable<CommentDto>> GetAllCommentsAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDtos = new List<CommentDto>();
            foreach (var comment in comments)
            {
                commentDtos.Add(new CommentDto
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    UserId = comment.UserId,
                    PhotoId = comment.PhotoId,
                    DateCreated = comment.DateCreated
                });
            }

            return commentDtos;
        }

        public async Task CreateCommentAsync(CommentDto comment)
        {
            var newComment = new Comment
            {
                Text = comment.Text,
                UserId = comment.UserId,
                PhotoId = comment.PhotoId,
                DateCreated = DateTime.Now
            };

            await _commentRepository.AddAsync(newComment);
        }

        public async Task UpdateCommentAsync(CommentDto comment)
        {
            var existingComment = await _commentRepository.GetByIdAsync(comment.Id);
            if (existingComment == null)
            {
                throw new ArgumentException($"Comment with id {comment.Id} not found");
            }

            // update the properties of the existing comment entity
            existingComment.Text = comment.Text;

            await _commentRepository.UpdateAsync(existingComment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            var existingComment = await _commentRepository.GetByIdAsync(id);
            if (existingComment == null)
            {
                throw new ArgumentException($"Comment with id {id} not found");
            }

            await _commentRepository.DeleteAsync(id);
        }
    }
}
