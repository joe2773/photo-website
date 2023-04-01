using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Application.Dto;
using MyPhotoApp.Infrastructure.Repositories;

namespace MyPhotoApp.Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly IRepository<Like> _likeRepository;
        private readonly IMapper _mapper;

        public LikeService(IRepository<Like> likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository ?? throw new ArgumentNullException(nameof(likeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<LikeDto> GetLikeByIdAsync(int id)
        {
            var like = await _likeRepository.GetByIdAsync(id);
            if (like == null)
            {
                return null;
            }

            var likeDto = _mapper.Map<LikeDto>(like);
            return likeDto;
        }

        public async Task<IEnumerable<LikeDto>> GetAllLikesAsync()
        {
            var likes = await _likeRepository.GetAllAsync();
            var likeDtos = _mapper.Map<IEnumerable<LikeDto>>(likes);
            return likeDtos;
        }

        public async Task CreateLikeAsync(LikeDto likeDto)
        {
            if (likeDto == null)
            {
                throw new ArgumentException("LikeDto cannot be null.");
            }

            var like = _mapper.Map<Like>(likeDto);
            await _likeRepository.AddAsync(like);
        }

        public async Task DeleteLikeAsync(int id)
        {
            var like = await _likeRepository.GetByIdAsync(id);
            if (like == null)
            {
                throw new ArgumentException($"Like with ID {id} does not exist.");
            }

            await _likeRepository.DeleteAsync(id);
        }
    }
}
