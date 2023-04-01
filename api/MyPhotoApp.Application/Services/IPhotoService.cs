using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Application.Dto;

namespace MyPhotoApp.Application.Services
{
    public interface IPhotoService
    {
        Task<PhotoDto> GetPhotoByIdAsync(int id);
        Task<IEnumerable<PhotoDto>> GetAllPhotosAsync();
        Task CreatePhotoAsync(PhotoDto photo);
        Task UpdatePhotoAsync(PhotoDto photo);
        Task DeletePhotoAsync(int id);
    }
}
