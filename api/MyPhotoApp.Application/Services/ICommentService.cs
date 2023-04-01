using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Application.Dto;

namespace MyPhotoApp.Application.Services
{
    public interface ICommentService
    {
        Task<CommentDto> GetCommentByIdAsync(int id);
        Task<IEnumerable<CommentDto>> GetAllCommentsAsync();
        Task CreateCommentAsync(CommentDto comment);
        Task UpdateCommentAsync(CommentDto comment);
        Task DeleteCommentAsync(int id);
    }
}
