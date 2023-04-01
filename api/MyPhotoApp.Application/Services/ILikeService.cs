using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Application.Dto;

namespace MyPhotoApp.Application.Services
{
    public interface ILikeService
    {
        Task<LikeDto> GetLikeByIdAsync(int id);
        Task<IEnumerable<LikeDto>> GetAllLikesAsync();
        Task CreateLikeAsync(LikeDto like);
        Task DeleteLikeAsync(int id);
    }
}
