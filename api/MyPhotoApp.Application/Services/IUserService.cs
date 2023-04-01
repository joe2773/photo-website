using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyPhotoApp.Domain.Models;
using MyPhotoApp.Application.Dto;

namespace MyPhotoApp.Application.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task CreateUserAsync(UserDto user);
        Task UpdateUserAsync(int id, UserDto user);
        Task DeleteUserAsync(int id);
    }
}
