using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MyPhotoApp.Application.Dto;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Infrastructure.Repositories;

namespace MyPhotoApp.Application.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IRepository<Photo> _photoRepository;
        private readonly IMapper _mapper;

        public PhotoService(IRepository<Photo> photoRepository, IMapper mapper)
        {
            _photoRepository = photoRepository;
            _mapper = mapper;
        }

        public async Task<PhotoDto> GetPhotoByIdAsync(int id)
        {
            var photo = await _photoRepository.GetByIdAsync(id);

            if (photo == null)
            {
                throw new ArgumentException($"Photo with ID '{id}' not found");
            }

            return _mapper.Map<PhotoDto>(photo);
        }

        public async Task<IEnumerable<PhotoDto>> GetAllPhotosAsync()
        {
            var photos = await _photoRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<PhotoDto>>(photos);
        }

        public async Task CreatePhotoAsync(PhotoDto photo)
        {
            var newPhoto = _mapper.Map<Photo>(photo);

            await _photoRepository.AddAsync(newPhoto);
        }

        public async Task UpdatePhotoAsync(PhotoDto photo)
        {
            var existingPhoto = await _photoRepository.GetByIdAsync(photo.Id);

            if (existingPhoto == null)
            {
                throw new ArgumentException($"Photo with ID '{photo.Id}' not found");
            }

            existingPhoto.FileName = photo.FileName;
            existingPhoto.Description = photo.Description;

            await _photoRepository.UpdateAsync(existingPhoto);
        }

        public async Task DeletePhotoAsync(int id)
        {
            var existingPhoto = await _photoRepository.GetByIdAsync(id);

            if (existingPhoto == null)
            {
                throw new ArgumentException($"Photo with ID '{id}' not found");
            }

            await _photoRepository.DeleteAsync(id);
        }
    }
}
