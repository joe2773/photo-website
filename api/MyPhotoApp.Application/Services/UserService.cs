using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Infrastructure.Repositories;
using MyPhotoApp.Application.Dto;
using AutoMapper;

namespace MyPhotoApp.Application.Services {

    public class UserService : IUserService {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User>  userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByIdAsync(int id){
            var user = await _userRepository.GetByIdAsync(id);
            if(user == null){
                throw new ArgumentException($"User with ID {id} not found.");
            }
            return _mapper.Map<UserDto>(user);
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync(){
           var users = await _userRepository.GetAllAsync();
           return _mapper.Map<IEnumerable<UserDto>>(users);
        }
        public async Task CreateUserAsync(UserDto user){
            var userToCreate = _mapper.Map<User>(user);
            await _userRepository.AddAsync(userToCreate);
        }
        public async Task UpdateUserAsync(int id,UserDto user){
            
            var updatedUser = _mapper.Map<User>(user);
            var userToUpdate = await _userRepository.GetByIdAsync(id);
            if(userToUpdate == null){
                throw new ArgumentException($"User with ID {id} not found.");
            }

            userToUpdate.Email = updatedUser.Email;
            userToUpdate.Username = updatedUser.Username;
            userToUpdate.Photos = updatedUser.Photos;
            userToUpdate.Likes = updatedUser.Likes;
            userToUpdate.Comments = updatedUser.Comments;

            await _userRepository.UpdateAsync(userToUpdate);
        }
        public async Task DeleteUserAsync(int id){
            var userToDelete = await _userRepository.GetByIdAsync(id);
            if(userToDelete == null){
                throw new ArgumentException($"User with ID {id} not found.");
            }
            await _userRepository.DeleteAsync(id);
        }
    }
}